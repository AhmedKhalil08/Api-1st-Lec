namespace API.DTO
{
    public class DepartmentDTO
    {
        public int DeptNumber { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int StudentsCount { get; set; }
        public List<string> Students { get; set; }
    }
}
