using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess.Implementation
{
    public class CastRepository : IRepository<Cast> , ICastRepository
    {
        public void Create(Cast entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("User cannot be empty");
            }
            entity.Id = StaticDb.Casts.LastOrDefault() != null ? StaticDb.Casts.Last().Id + 1 : 1;
            StaticDb.Casts.Add(entity);
        }

        public void Delete(int id)
        {
            Cast userFromDb = StaticDb.Casts.FirstOrDefault(u => u.Id == id);
            if (userFromDb != null)
            {
                StaticDb.Casts.Remove(userFromDb);
            }
            else
            {
                throw new Exception("User cannot be found");
            }
        }

        public List<Cast> GetAll()
        {
            return StaticDb.Casts;
        }

        public Cast GetById(int id)
        {
            return StaticDb.Casts.FirstOrDefault(u => u.Id == id);
        }

        public void Update(Cast entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            Cast userFromDB = GetById(entity.Id);
            int index = StaticDb.Casts.IndexOf(userFromDB);
            StaticDb.Casts[index] = entity;
        }

        public List<Cast> GetByMovieId(int movieId)
        {
            return StaticDb.Casts.Where(c => c.MovieId == movieId).ToList();
        }
    }
}
