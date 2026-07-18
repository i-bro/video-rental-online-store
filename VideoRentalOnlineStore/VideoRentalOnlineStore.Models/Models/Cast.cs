using VideoRentalOnlineStore.DomainModels.Enums;

namespace VideoRentalOnlineStore.DomainModels.Models
{
    public class Cast : BaseEntity
    {
        public int MovieId {get; set;}
        public string Name {get; set;}
        public CastPart Part {get; set;}
    }
}
