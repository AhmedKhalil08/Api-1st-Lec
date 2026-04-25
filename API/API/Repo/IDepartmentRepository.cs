using API.Models;

namespace API.Repo
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        List<Department> GetAllWithDetails();
    }
}
