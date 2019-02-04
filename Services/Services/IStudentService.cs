using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Services
{
    // we should be using some sort of DTO on this level to deliver data in structures ready to be consumed by the  client but for now we are going to use the domain entities in a transversal way
    public interface IStudentService
    {
        void AddStudent(Student student);
        void InitializeData(string filePath);
        IList<Student> GetFiltered(Func<Student, bool> criteria);
    }
}
