using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Base;
using Domain.Entities;

namespace Data.Repositories
{
    public class StudentRepository : AbstractRepository<Student>, IStudentRepository
    {
    }
}
