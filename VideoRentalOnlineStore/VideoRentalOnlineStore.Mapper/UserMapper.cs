using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Model.DTOs;


namespace VideoRentalOnlineStore.Mapper
{
    public static class UserMapper
    {
        public static LoggedInUserDto Map(this User user)
        {
            return new LoggedInUserDto { CardNumber = user.CardNumber, FullName = user.FullName };
        }
    }
}
