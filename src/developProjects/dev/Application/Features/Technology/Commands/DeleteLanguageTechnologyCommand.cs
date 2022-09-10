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
    public class DeleteLanguageTechnologyCommand : IRequest<DeletedLanguageTechnologyDto>
    {

        public int Id { get; set; }

        public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public DeleteLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {



                LanguageTechnology languageTechnology = await _languageTechnologyRepository.GetAsync(t => t.Id == request.Id);
                LanguageTechnology deleteLanguageTechnology = await _languageTechnologyRepository.DeleteAsync(languageTechnology);

                DeletedLanguageTechnologyDto deleteLanguageTechnologyDto = _mapper.Map<DeletedLanguageTechnologyDto>(deleteLanguageTechnology);

                return deleteLanguageTechnologyDto;

            }
        }
    }
}
