using VideoRentalOnlineStore.DataAccess;
using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class UserService : IUserService
    {
        public User? GetByCardNumber(string cardNumber)
        {
            return StaticDb.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }
    }
}
