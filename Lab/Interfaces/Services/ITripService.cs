using Lab.DTOs;

namespace Lab.Interfaces.Services
{
    public interface ITripService
    {
        List<TripGetDTO> ListAll();
        void Create(TripDTO data);
    }
}
