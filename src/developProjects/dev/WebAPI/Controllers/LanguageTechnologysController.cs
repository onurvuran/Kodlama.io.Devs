using Application.Features.Technology.Commands;
using Application.Features.Technology.Dtos;
using Application.Features.Technology.Models;
using Application.Features.Technology.Queries.GetListLanguageTechnology;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LanguageTechnologysController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechnologyQuery getListLanguageTechnologyQuery = new GetListLanguageTechnologyQuery { PageRequest = pageRequest };
            LanguageTechnologyListModel result = await Mediator.Send(getListLanguageTechnologyQuery);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
        {
            CreatedLanguageTechnologyDto result = await Mediator.Send(createLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(deleteLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLanguageTechnologyCommand updateLAnguageTechnologyCommand)
        {
            var result = await Mediator.Send(updateLAnguageTechnologyCommand);
            return Ok(result);
        }
        //
    }
}
