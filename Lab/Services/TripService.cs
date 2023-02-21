using Lab.DTOs;
using Lab.Interfaces.Repositories;
using Lab.Interfaces.Services;
using Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository<Trip> _tripRepository;

        public TripService(IRepository<Trip> tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public List<TripGetDTO> ListAll()
        {
            return AutoMapperExpression.AutoMapTripGetDTO(_tripRepository.GetListResultSpec(x => x)
                .Include(x => x.Transport).ThenInclude(x => x.Kind)
                .Include(x => x.User));
        }

        public void Create(TripDTO data)
        {
            var trip = new Trip
            {
                UserId = data.UserId,
                TransportId = data.TransportId,
                Price = data.Price
            };

            _tripRepository.Create(trip);
        }
    }
}
