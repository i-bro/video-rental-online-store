using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess.Implementation
{
    public class RentalRepository : IRepository<Rental>, IRentalRepository
    {
        public void Create(Rental entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("User cannot be empty");
            }
            entity.Id = StaticDb.Rentals.LastOrDefault() != null ? StaticDb.Rentals.Last().Id + 1 : 1;
            StaticDb.Rentals.Add(entity);
        }

        public void Delete(int id)
        {
            Rental userFromDb = StaticDb.Rentals.FirstOrDefault(u => u.Id == id);
            if (userFromDb != null)
            {
                StaticDb.Rentals.Remove(userFromDb);
            }
            else
            {
                throw new Exception("User cannot be found");
            }
        }

        public Rental GetActiveRentalByMovieId(int movieId)
        {
            return StaticDb.Rentals.FirstOrDefault(r => r.MovieId == movieId && r.ReturnedOn == null);
        }

        public List<Rental> GetAll()
        {
            return StaticDb.Rentals;
        }

        public Rental GetById(int id)
        {
            return StaticDb.Rentals.FirstOrDefault(u => u.Id == id);
        }

        public void Update(Rental entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            Rental userFromDB = GetById(entity.Id);
            int index = StaticDb.Rentals.IndexOf(userFromDB);
            StaticDb.Rentals[index] = entity;
        }
    }
}
