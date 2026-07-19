using VideoRentalOnlineStore.DataAccess;
using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public User? GetByCardNumber(string cardNumber)
        {
            return _userRepository.GetAll().FirstOrDefault(u => u.CardNumber == cardNumber);
        }
    }
}
