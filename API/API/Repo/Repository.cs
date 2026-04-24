using API.Context;

namespace API.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly APIContext db;
        public Repository(APIContext _db)
        {
            db= _db;
        }
        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var item = db.Set<T>().Find(id);
            if (item != null)
            {
                db.Set<T>().Remove(item);
            }
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();

        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
        }
    }
}
