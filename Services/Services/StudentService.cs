using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Domain.Entities;
using System.IO;

namespace Services.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository repo;
        private IParseDataService parseService;
        private readonly object fileLock = new object();

        public StudentService(IStudentRepository repo, IParseDataService parseService)
        {
            this.repo = repo;
            this.parseService = parseService;
        }
        
        public void AddStudent(Student student)
        {
            repo.Add(student);
        }

        public void InitializeData(string filePath)
        {
            //TODO: Implement Exception Handling and validations            
            IList<Student> students = new List<Student>();
            lock (fileLock)
            {
                using (var reader = new StreamReader(filePath))
                {
                    students = parseService.ParseData(reader);
                }

                foreach (var student in students)
                {
                    repo.Add(student);
                }
            }
        }


        public IList<Student> GetFiltered(Func<Student, bool> criteria)
        {
            return repo.GetList(criteria);
        }
    }
}
