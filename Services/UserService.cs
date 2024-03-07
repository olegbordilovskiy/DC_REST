using AutoMapper;
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

		public UserResponseTo CreateUser(UserRequestDto userRequestDto)
		{
			var user = _mapper.Map<User>(userRequestDto);
			var createdUser = _userRepository.Add(user);
			var responseDto = _mapper.Map<UserDto>(createdUser);

			return responseDto;
		}

		public UserDto GetUserById(int id)
		{
			var user = _userRepository.GetById(id);
			var userDto = _mapper.Map<UserDto>(user);

			return userDto;
		}

		public IEnumerable<UserDto> GetAllUsers()
		{
			var users = _userRepository.GetAll();
			var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

			return userDtos;
		}

		public UserDto UpdateUser(int id, UserRequestDto userRequestDto)
		{
			var existingUser = _userRepository.GetById(id);
			if (existingUser == null)
			{
				// Обработка ситуации, когда пользователь не найден
				return null;
			}

			_mapper.Map(userRequestDto, existingUser);
			var updatedUser = _userRepository.Update(existingUser);
			var responseDto = _mapper.Map<UserDto>(updatedUser);

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
