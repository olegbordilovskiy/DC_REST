using AutoMapper;
using DC_REST.DTOs.Request;
using DC_REST.DTOs.Response;
using DC_REST.Entities;
using DC_REST.Services;
using DC_REST.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DC_REST.Controllers
{
	[Route("/api/v1.0/issues")]
	[ApiController]
	public class IssueController : ControllerBase
	{
		private readonly IIssueService _issueService;
		private readonly IMapper _mapper;

		public IssueController(IIssueService issueService, IMapper mapper)
		{
			_issueService = issueService;
			_mapper = mapper;
		}

		[HttpPost]
		public IActionResult CreateIssue(IssueRequestTo issueRequestDto)
		{
			var issueResponseDTO = _issueService.CreateIssue(issueRequestDto); 
			//return Ok(issueResponseDTO); // Возврат созданного объекта responseDto
			return StatusCode(201, issueResponseDTO);
		}

		[HttpGet]
		public IActionResult GetAllIssues()
		{
			var issuesResponseDTO = _issueService.GetAllIssues();
			return Ok(issuesResponseDTO);
		}

		[HttpGet("{id}")]
		public IActionResult GetIssueById(int id)
		{
			var issuerResponseDTO = _issueService.GetIssueById(id);

			if (issuerResponseDTO == null)
				return NotFound();

			return Ok(issuerResponseDTO);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateIssue(int id, IssueRequestTo issueRequestDto)
		{
			var issuerResponseDTO = _issueService.UpdateIssue(id, issueRequestDto);

			if (issuerResponseDTO == null)
				return NotFound();

			return Ok(issuerResponseDTO);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteIssue(int id)
		{
			var isDeleted = _issueService.DeleteIssue(id);

			if (!isDeleted)
				return NotFound();

			return NoContent();
		}
	}

}
