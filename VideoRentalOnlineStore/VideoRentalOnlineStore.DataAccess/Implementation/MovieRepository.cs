using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess.Implementation
{
    public class MovieRepository : IRepository<Movie>
    {
        public void Create(Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("User cannot be empty");
            }
            entity.Id = StaticDb.Movies.LastOrDefault() != null ? StaticDb.Movies.Last().Id + 1 : 1;
            StaticDb.Movies.Add(entity);
        }

        public void Delete(int id)
        {
            Movie userFromDb = StaticDb.Movies.FirstOrDefault(u => u.Id == id);
            if (userFromDb != null)
            {
                StaticDb.Movies.Remove(userFromDb);
            }
            else
            {
                throw new Exception("User cannot be found");
            }
        }

        public List<Movie> GetAll()
        {
            return StaticDb.Movies;
        }

        public Movie GetById(int id)
        {
            return StaticDb.Movies.FirstOrDefault(u => u.Id == id);
        }

        public void Update(Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            Movie userFromDB = GetById(entity.Id);
            int index = StaticDb.Movies.IndexOf(userFromDB);
            StaticDb.Movies[index] = entity;
        }
    }
}
