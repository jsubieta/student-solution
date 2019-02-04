using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Services;
using Data.Repositories;
using Domain.Entities;
namespace StudentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];
            //TODO: Resolve dependencies with some IOC container
            IStudentService service = new StudentService(new StudentRepository(), new ParseDataService());
            ICriteriaParser<Student> parser = new CriteriaParser();
            service.InitializeData(filePath);
            var criteria = new Dictionary<string, string>();
           
            for (var i = 1; i < args.Length; i++)
            {
                var data = args[i].Split('=');
                criteria.Add(data[0], data[1]);
            }

            Func<Student, bool> parsedCriteria = parser.ParseCriteria(criteria);
            var output = service.GetFiltered(parsedCriteria).ToList();
            var sb = new StringBuilder();
            output.ForEach(x => 
                sb.Append(
                String.Format("{0} {1} {2} {3}", x.Type.ToString(), x.Name, x.Gender.ToString(), x.LastModified.ToString())
                ));
            Console.Write(sb.ToString());
        }
    }
}
