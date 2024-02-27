using Day1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Day1.Services
{
    public class StudentRepo
    {
        private readonly APIdbContext db;

        public StudentRepo(APIdbContext context)
        {
            db = context;
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetById(int id)
        {
            return db.Students.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Student> GetByName(string name)
        {
            return db.Students.Where(a => a.Name == name).ToList();
        }

        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void Update(int id, Student student)
        {
            var oldstd = GetById(id); ;
            if (oldstd != null)
            {
                oldstd.Name = student.Name;
                oldstd.Age = student.Age;
                oldstd.Address = student.Address;
                oldstd.Image = student.Image;
                db.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var model = db.Students.SingleOrDefault(a => a.Id == id);
            db.Students.Remove(model);
            db.SaveChanges();

        }
    }
}
