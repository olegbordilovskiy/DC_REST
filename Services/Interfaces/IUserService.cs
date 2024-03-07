using DC_REST.DTOs;

namespace DC_REST.Services.Interfaces
{
	public interface IUserService
	{
		UserDTO CreateUser(UserDTO userRequestDto);
		UserDTO GetUserById(int id);
		IEnumerable<UserDTO> GetAllUsers();
		UserDTO UpdateUser(int id, UserDTO userRequestDto);
		bool DeleteUser(int id);
	}
}
