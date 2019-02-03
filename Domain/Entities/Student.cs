using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        public StudentType Type { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastModified { get; set; }
    }

    public enum StudentType
    { 
        Kinder,
        High
    }

    public enum Gender
    { 
        M,
        F
    }
}
