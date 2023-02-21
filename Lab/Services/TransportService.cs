using Lab.DTOs;
using Lab.Interfaces.Repositories;
using Lab.Interfaces.Services;
using Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.Services
{
    public class TransportService: ITransportService
    {
        private readonly IRepository<Transport> _transportRepository;

        public TransportService(IRepository<Transport> transportRepository)
        {
            _transportRepository = transportRepository;
        }

        public List<TransportGetDTO> ListAll()
        {
            return AutoMapperExpression.AutoMapTransportGetDTO(_transportRepository.GetListResultSpec(x => x)
                .Include(x => x.Price));
        }

        public bool IsExists(TransportDTO model) => _transportRepository.GetResultSpec(x => x.Any(p => p.KindId == model.KindId && p.Number == model.Number));

        public void Create(TransportDTO data)
        {
            var transport = new Transport
            {
                KindId = data.KindId,
                Number = data.Number,
                Route = data.Route,
                PriceId = data.PriceId
            };

            _transportRepository.Create(transport);
        }

        public bool IsExistsData(int id) => _transportRepository.GetResultSpec(x => x.Any(p => p.Id == id));

        public void Update(TransportDTO model)
        {
            var data = _transportRepository.GetById(model.Id);

            if (data != null)
            {
                data.Route = model.Route;
                data.PriceId = model.PriceId;

                _transportRepository.Update(data);
            }
        }

        public void Delete(int id)
        {
            _transportRepository.Delete(_transportRepository.GetResultSpec(x => x.Where(p => p.Id == id)).First());
        }
    }
}
