using AutoMapper;
using DC_REST.DTOs.Request;
using DC_REST.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DC_REST.Controllers
{
	[Route("/api/v1.0/users")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UserController(IUserService issueService, IMapper mapper)
		{
			_userService = issueService;
			_mapper = mapper;
		}

		[HttpPost]
		public IActionResult CreateUser(UserRequestTo userRequestDto)
		{
			var userResponseDTO = _userService.CreateUser(userRequestDto); 
			return StatusCode(201, userResponseDTO);
		}

		[HttpGet]
		public IActionResult GetAllUsers()
		{
			var usersResponseDTO = _userService.GetAllUsers();
			return Ok(usersResponseDTO);
		}

		[HttpGet("{id}")]
		public IActionResult GetUserById(int id)
		{
			var userResponseDTO = _userService.GetUserById(id);

			if (userResponseDTO == null)
				return NotFound();

			return Ok(userResponseDTO);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateIssue(int id, UserRequestTo userRequestDto)
		{
			var userResponseDTO = _userService.UpdateUser(id, userRequestDto);

			if (userResponseDTO == null)
				return NotFound();

			return Ok(userResponseDTO);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteUser(int id)
		{
			var isDeleted = _userService.DeleteUser(id);

			if (!isDeleted)
				return NotFound();

			return NoContent();
		}
	}
}
