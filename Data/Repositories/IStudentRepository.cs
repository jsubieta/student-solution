﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Base;
namespace Data.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
