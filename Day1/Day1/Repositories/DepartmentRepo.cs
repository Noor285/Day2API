using Day1.Models;

namespace Day1.Repositories
{
    public class DepartmentRepo
    {
        private readonly APIdbContext db;

        public DepartmentRepo(APIdbContext context)
        {
            db = context;
        }

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.Find(id);
        }

        public Department GetByName(string name)
        {
            return db.Departments.FirstOrDefault(d => d.Name == name);
        }

        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }

        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = db.Departments.Find(id);
            if (department != null)
            {
                db.Departments.Remove(department);
                db.SaveChanges();
            }
        }

    }
}
