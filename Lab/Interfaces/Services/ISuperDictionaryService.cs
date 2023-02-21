using Lab.DTOs;

namespace Lab.Interfaces.Services
{
    public interface ISuperDictionaryService
    {
        List<SuperDictionaryDTO> ListAll();
        bool IsExists(SuperDictionaryDTO model);
        void Create(SuperDictionaryDTO data);
        bool IsExistsData(int id);
        void Update(SuperDictionaryDTO model);
        void Delete(int id);
    }
}
