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
    public class CreateLanguageTechnologyCommand : IRequest<CreatedLanguageTechnologyDto>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand, CreatedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public CreateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {


                LanguageTechnology mappedTechnology = _mapper.Map<LanguageTechnology>(request);
                LanguageTechnology createdlanguageTechnology = await _languageTechnologyRepository.AddAsync(mappedTechnology);
                CreatedLanguageTechnologyDto createLanguageTechnologyDto = _mapper.Map<CreatedLanguageTechnologyDto>(createdlanguageTechnology);

                return createLanguageTechnologyDto;

            }
        }
    }
}
