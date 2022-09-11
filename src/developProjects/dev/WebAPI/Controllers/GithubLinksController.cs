using Application.Features.GitHubLinks.Commands;
using Application.Features.GitHubLinks.Dtos;
using Application.Features.GitHubLinks.Models;
using Application.Features.GitHubLinks.Queries;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GithubLinksController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGitHubLinkCommand createGitHubListCommand)
        {
            CreatedGitHubLinkDto result = await Mediator.Send(createGitHubListCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGitHubLinkQuery getListGitHubLinkQuery = new() { PageRequest = pageRequest };
            GitHubLinkListModel result = await Mediator.Send(getListGitHubLinkQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGitHubLinkCommand updateGitHubLinkCommand)
        {
            UpdatedGitHubLinkDto result = await Mediator.Send(updateGitHubLinkCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGitHubLinkCommand deleteGitHubLinkCommand)
        {
            DeletedGitHubLinkDto result = await Mediator.Send(deleteGitHubLinkCommand);
            return Ok(result);
        }
    }
}
