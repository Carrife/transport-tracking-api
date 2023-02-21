using Lab.DTOs;

namespace Lab.Interfaces.Services
{
    public interface IUserTransportChoiceService
    {
        List<UserTransportChoiceGetDTO> ListAll();
        bool IsExists(UserTransportChoiceDTO model);
        void Create(UserTransportChoiceDTO data);
        bool IsExistsData(int id);
        void Delete(int id);
    }
}
