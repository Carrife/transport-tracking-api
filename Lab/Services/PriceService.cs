using Lab.DTOs;
using Lab.Interfaces.Repositories;
using Lab.Interfaces.Services;
using Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.Services
{
    public class PriceService : IPriceService
    {
        private readonly IRepository<Price> _priceRepository;
        
        public PriceService(IRepository<Price> priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public List<PriceGetDTO> ListAll()
        {
            return AutoMapperExpression.AutoMapPriceGetDTO(_priceRepository.GetListResultSpec(x => x)
                   .Include(x => x.Kind));
        }

        public bool IsExists(int kindId) => _priceRepository.GetResultSpec(x => x.Any(p => p.KindId == kindId));

        public void Create(PriceDTO data)
        {
            var price = new Price
            {
                KindId = data.KindId,
                TripPrice = data.TripPrice
            };

            _priceRepository.Create(price);
        }

        public bool IsExistsData(int id) => _priceRepository.GetResultSpec(x => x.Any(p => p.Id == id));

        public void Update(PriceDTO model)
        {
            var data = _priceRepository.GetById(model.Id);

            if (data != null)
            {
                data.TripPrice = model.TripPrice;
            
                _priceRepository.Update(data);
            }
        }

        public void Delete(int id)
        {
            _priceRepository.Delete(_priceRepository.GetResultSpec(x => x.Where(p => p.Id == id)).First());
        }
    }
}
