using Lab.DTOs;
using Lab.Interfaces.Repositories;
using Lab.Interfaces.Services;
using Lab.Models;

namespace Lab.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> ListAll()
        {
            return AutoMapperExpression.AutoMapUserDTO(_userRepository.GetListResultSpec(x => x));
        }

        public void Create(UserDTO data)
        {
            var user = new User
            {
                Name = data.Name,
                Surname = data.Surname,
                Patronymic = data.Patronymic,
                AccountNumber = data.AccountNumber
            };

            _userRepository.Create(user);
        }

        public bool IsExistsData(int id) => _userRepository.GetResultSpec(x => x.Any(p => p.Id == id));

        public void Update(UserDTO model)
        {
            var data = _userRepository.GetById(model.Id);

            if (data != null)
            {
                data.Name = model.Name;
                data.Surname = model.Surname;
                data.Patronymic = model.Patronymic;
                data.AccountNumber = model.AccountNumber;

                _userRepository.Update(data);
            }
        }

        public void Delete(int id)
        {
            _userRepository.Delete(_userRepository.GetResultSpec(x => x.Where(p => p.Id == id)).First());
        }
    }
}
