using Lab.DTOs;
using Lab.Interfaces.Repositories;
using Lab.Interfaces.Services;
using Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.Services
{
    public class UserTransportChoiceService : IUserTransportChoiceService
    {
        private readonly IRepository<UserTransportChoice> _userTransportChoiceRepository;

        public UserTransportChoiceService(IRepository<UserTransportChoice> userTransportChoiceRepository)
        {
            _userTransportChoiceRepository = userTransportChoiceRepository;
        }

        public List<UserTransportChoiceGetDTO> ListAll()
        {
            return AutoMapperExpression.AutoMapUserTransportChoiceGetDTO(_userTransportChoiceRepository.GetListResultSpec(x => x)
                .Include(x => x.Transport).ThenInclude(x => x.Kind));
        }

        public bool IsExists(UserTransportChoiceDTO model) => _userTransportChoiceRepository.GetResultSpec(x => x.Any(p => p.UserId == model.UserId && p.TransportId == model.TransportId));

        public void Create(UserTransportChoiceDTO data)
        {
            var userTransportChoice = new UserTransportChoice
            {
                UserId = data.UserId,
                TransportId = data.TransportId
            };

            _userTransportChoiceRepository.Create(userTransportChoice);
        }

        public bool IsExistsData(int id) => _userTransportChoiceRepository.GetResultSpec(x => x.Any(p => p.Id == id));

        public void Delete(int id)
        {
            _userTransportChoiceRepository.Delete(_userTransportChoiceRepository.GetResultSpec(x => x.Where(p => p.Id == id)).First());
        }
    }
}
