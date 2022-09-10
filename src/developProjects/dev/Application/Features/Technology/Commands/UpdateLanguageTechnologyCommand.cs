using Application.Features.Technology.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Commands
{
    public class UpdateLanguageTechnologyCommand : IRequest<UpdatedLanguageTechnologyDto>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int LanguageId { get; set; }

        public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand, UpdatedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public UpdateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<UpdatedLanguageTechnologyDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {


                LanguageTechnology UpdateLanguageTechnology = _mapper.Map<LanguageTechnology>(request);
                LanguageTechnology deletedlanguageTechnology = await _languageTechnologyRepository.UpdateAsync(UpdateLanguageTechnology);
                UpdatedLanguageTechnologyDto updatedLanguageTechnologyDto = _mapper.Map<UpdatedLanguageTechnologyDto>(deletedlanguageTechnology);

                return updatedLanguageTechnologyDto;

            }
        }
    }
}
