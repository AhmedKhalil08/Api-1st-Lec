using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class DepartmentRepository:Repository<Department>, IDepartmentRepository
    {
        APIContext db;
        public DepartmentRepository(APIContext _db):base(_db)
        {
            db= _db;
        }
        public List<Department> GetAllWithDetails()
        {
            return db.Department.Include(d => d.Students).ToList();
        }
    }
}
