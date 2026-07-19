using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Model.ViewModels;

namespace VideoRentalOnlineStore.Mapper
{
    public static class CastMapper
    {
        public static CastViewModel MapCast(this Cast cast)
        {
            return new CastViewModel
            {
                Name = cast.Name,
                Part = cast.Part
            };
        }
    }
}
