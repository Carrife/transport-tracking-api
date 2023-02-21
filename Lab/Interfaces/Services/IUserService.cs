using Lab.DTOs;

namespace Lab.Interfaces.Services
{
    public interface IUserService
    {
        List<UserDTO> ListAll();
        void Create(UserDTO data);
        bool IsExistsData(int id);
        void Update(UserDTO model);
        void Delete(int id);
    }
}
