using Lab.DTOs;

namespace Lab.Interfaces.Services
{
    public interface ITransportService
    {
        List<TransportGetDTO> ListAll();
        bool IsExists(TransportDTO model);
        void Create(TransportDTO data);
        bool IsExistsData(int id);
        void Update(TransportDTO model);
        void Delete(int id);
    }
}
