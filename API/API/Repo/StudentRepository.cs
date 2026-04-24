using API.Context;
using API.Models;

namespace API.Repo
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {
        APIContext db;
        public StudentRepository(APIContext _db):base(_db)
        {
            db= _db;
        }
    }
}
