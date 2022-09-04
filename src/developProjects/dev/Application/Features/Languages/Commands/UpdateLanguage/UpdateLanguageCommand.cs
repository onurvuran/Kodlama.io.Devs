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

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdateLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageHandler : IRequestHandler<UpdateLanguageCommand, UpdateLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;


            public UpdateLanguageHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;

            }

            public async Task<UpdateLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {



                Language mappedLanguage = _mapper.Map<Language>(request);
                Language updateLanguage = await _languageRepository.UpdateAsync(mappedLanguage);
                UpdateLanguageDto updateLanguageDto = _mapper.Map<UpdateLanguageDto>(updateLanguage);
                return updateLanguageDto;
            }
        }
    }
}
