using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;

        public AuthService(
            IUserOperationClaimReadRepository userOperationClaimReadRepository,
            ITokenHelper tokenHelper, IRefreshTokenWriteRepository refreshTokenWriteRepository
            )
        {
            _userOperationClaimReadRepository = userOperationClaimReadRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken) => await _refreshTokenWriteRepository.AddAsync(refreshToken);

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                await _userOperationClaimReadRepository.GetListAsync(
                    userOperationClaim => userOperationClaim.UserId.Equals(user.Id),
                    include: userOperationClaim => userOperationClaim.Include(x => x.OperationClaim));

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(
                userOperationClaim => new OperationClaim
                {
                    Id = userOperationClaim.OperationClaim.Id,
                    Name = userOperationClaim.OperationClaim.Name
                }).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, String ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }
    }
