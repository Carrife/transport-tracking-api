using Lab.DTOs;
using Lab.Interfaces.Repositories;
using Lab.Interfaces.Services;
using Lab.Models;

namespace Lab.Services
{
    public class SuperDictionaryService : ISuperDictionaryService
    {
        private readonly IRepository<SuperDictionary> _superDictionaryRepository;

        public SuperDictionaryService(IRepository<SuperDictionary> superDictionaryRepository)
        {
            _superDictionaryRepository = superDictionaryRepository;
        }

        public List<SuperDictionaryDTO> ListAll()
        {
            return AutoMapperExpression.AutoMapSuperDictionaryDTO(_superDictionaryRepository.GetListResultSpec(x => x));
        }

        public bool IsExists(SuperDictionaryDTO model) => _superDictionaryRepository.GetResultSpec(x => x.Any(p => p.Name == model.Name && p.DictionaryId == model.DictionaryId));

        public void Create(SuperDictionaryDTO data)
        {
            var superDictionary = new SuperDictionary
            {
                Name = data.Name,
                DictionaryId = data.DictionaryId
            };

            _superDictionaryRepository.Create(superDictionary);
        }

        public bool IsExistsData(int id) => _superDictionaryRepository.GetResultSpec(x => x.Any(p => p.Id == id));

        public void Update(SuperDictionaryDTO model)
        {
            var data = _superDictionaryRepository.GetById(model.Id);

            if (data != null)
            {
                data.Name = model.Name;

                _superDictionaryRepository.Update(data);
            }
        }

        public void Delete(int id)
        {
            _superDictionaryRepository.Delete(_superDictionaryRepository.GetResultSpec(x => x.Where(p => p.Id == id)).First());
        }
    }
}
