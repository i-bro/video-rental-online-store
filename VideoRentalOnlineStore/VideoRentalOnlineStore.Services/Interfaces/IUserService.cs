using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.Services.Interfaces
{
    public interface IUserService
    {
        User? GetByCardNumber(string cardNumber);
    }
}
