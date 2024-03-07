using AutoMapper;
using DC_REST.DTOs.Request;
using DC_REST.DTOs.Response;
using DC_REST.Entities;
using DC_REST.Repositories;
using DC_REST.Services.Interfaces;

namespace DC_REST.Services
{
    public class UserService : IUserService
	{
		private readonly IRepository<User> _userRepository;
		private readonly IMapper _mapper;

		public UserService(IRepository<User> userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public UserResponseTo CreateUser(UserRequestTo userRequestDto)
		{
			var user = _mapper.Map<User>(userRequestDto);
			var createdUser = _userRepository.Add(user);
			var responseDto = _mapper.Map<UserResponseTo>(createdUser);

			return responseDto;
		}

		public UserResponseTo GetUserById(int id)
		{
			var user = _userRepository.GetById(id);
			var userDto = _mapper.Map<UserResponseTo>(user);

			return userDto;
		}

		public IEnumerable<UserResponseTo> GetAllUsers()
		{
			var users = _userRepository.GetAll();
			var userDtos = _mapper.Map<IEnumerable<UserResponseTo>>(users);

			return userDtos;
		}

		public UserResponseTo UpdateUser(int id, UserRequestTo userRequestDto)
		{
			var existingUser = _userRepository.GetById(id);
			if (existingUser == null)
			{
				// Обработка ситуации, когда пользователь не найден
				return null;
			}

			_mapper.Map(userRequestDto, existingUser);
			var updatedUser = _userRepository.Update(id, existingUser);
			var responseDto = _mapper.Map<UserResponseTo>(updatedUser);

			return responseDto;
		}

		public bool DeleteUser(int id)
		{
			var userToDelete = _userRepository.GetById(id);
			if (userToDelete == null)
			{
				// Обработка ситуации, когда пользователь не найден
				return false;
			}

			_userRepository.Delete(id);
			return true;
		}
	}

}
