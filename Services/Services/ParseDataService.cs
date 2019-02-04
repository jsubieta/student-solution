using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.IO;
using System.Globalization;

namespace Services.Services
{
    public class ParseDataService : IParseDataService
    {
        public IList<Student> ParseData(StreamReader reader)
        {
            //TODO: Add validations to the parsing and validations to see if gender and type are valid values in the enums              
            var students = new List<Student>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                students.Add(new Student
                {
                    Type = (StudentType)Enum.Parse(typeof(StudentType), values[0]),
                    Name = values[1],
                    Gender = (Gender)Enum.Parse(typeof(Gender), values[2]),
                    LastModified = this.PaseDateTime(values[3])
                });
            }

            return students;
        }

        private DateTime PaseDateTime(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }
    }
}
