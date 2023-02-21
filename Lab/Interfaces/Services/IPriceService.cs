using Lab.DTOs;

namespace Lab.Interfaces.Services
{
    public interface IPriceService
    {
        List<PriceGetDTO> ListAll();
        bool IsExists(int kindId);
        void Create(PriceDTO data);
        bool IsExistsData(int id);
        void Update(PriceDTO model);
        void Delete(int id);
    }
}
