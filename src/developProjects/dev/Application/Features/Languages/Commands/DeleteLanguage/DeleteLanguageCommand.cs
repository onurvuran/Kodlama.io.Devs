using Application.Features.Languages.Dtos;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeleteLanguageDto>
    {
        public int Id { get; set; }


        public class DeleteLanguageHandler : IRequestHandler<DeleteLanguageCommand, DeleteLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;


            public DeleteLanguageHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;

            }

            public async Task<DeleteLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {



                Language mappedLanguage = _mapper.Map<Language>(request);
                Language deleteLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
                DeleteLanguageDto deleteLanguageDto = _mapper.Map<DeleteLanguageDto>(deleteLanguage);
                return deleteLanguageDto;
            }


        }
    }
}
