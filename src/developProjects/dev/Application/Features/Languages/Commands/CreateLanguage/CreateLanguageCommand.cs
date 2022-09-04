using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<CreatedLanguageDto>
    {
        public string Name { get; set; }

        public class CreatedLanguageHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinnesRules;

            public CreatedLanguageHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinnesRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinnesRules = languageBusinnesRules;
            }

            public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinnesRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);


                Language mappedLanguage = _mapper.Map<Language>(request);
                Language createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
                CreatedLanguageDto createLanguageDto = _mapper.Map<CreatedLanguageDto>(createdLanguage);
                return createLanguageDto;
            }
        }

    }
}
