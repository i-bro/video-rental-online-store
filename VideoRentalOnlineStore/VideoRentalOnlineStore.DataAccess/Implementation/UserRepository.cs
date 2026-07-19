using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess.Implementation
{
    public class UserRepository : IRepository<User>
    {
        public void Create(User entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("User cannot be empty");
            }
            entity.Id = StaticDb.Users.LastOrDefault() != null ? StaticDb.Users.Last().Id + 1 : 1;
            StaticDb.Users.Add(entity);
        }

        public void Delete(int id)
        {
            User userFromDb = StaticDb.Users.FirstOrDefault(u => u.Id == id);
            if(userFromDb != null)
            {
                StaticDb.Users.Remove(userFromDb);
            }
            else
            {
                throw new Exception("User cannot be found");
            }
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            User userFromDB = GetById(entity.Id);
            int index = StaticDb.Users.IndexOf(userFromDB);
            StaticDb.Users[index] = entity;
        }
    }
}
