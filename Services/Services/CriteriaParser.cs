using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Linq.Expressions;

namespace Services.Services
{
    public class CriteriaParser : ICriteriaParser<Student>
    {
        public Func<Student, bool> ParseCriteria(Dictionary<string, string> criteria)
        {
            Func<Student, bool> parsedCriteria = x => { return true; };
            //Here I'm going to implement a pretty single (and probably poorly implemented) solution and without any flexibility I should probably build a dynamic Expression to return the lambda needed based on the amount of criterias provided but I'm not going to go too far for this example
            if (criteria.ContainsKey("type") && criteria.ContainsKey("gender") && criteria.ContainsKey("name"))
            {
                parsedCriteria = x => x.Type == (StudentType)Enum.Parse(typeof(StudentType), criteria["type"]) &&
                    x.Gender == (Gender)Enum.Parse(typeof(Gender), criteria["gender"]) &&
                    x.Name.ToLower() == criteria["name"].ToLower();
            }
            else if (criteria.ContainsKey("type") && criteria.ContainsKey("gender"))
            {
                parsedCriteria = x => x.Type == (StudentType)Enum.Parse(typeof(StudentType), criteria["type"]) &&
                       x.Gender == (Gender)Enum.Parse(typeof(Gender), criteria["gender"]);
                       
            }
            else if (criteria.ContainsKey("type") && criteria.ContainsKey("name"))
            {
                parsedCriteria = x => x.Type == (StudentType)Enum.Parse(typeof(StudentType), criteria["type"]) &&
                       x.Name.ToLower() == criteria["name"].ToLower();
            }

            else if (criteria.ContainsKey("type"))
            {
                parsedCriteria = x => x.Type == (StudentType)Enum.Parse(typeof(StudentType), criteria["type"]);
            }
            else if (criteria.ContainsKey("gender") && criteria.ContainsKey("name"))
            {
                  parsedCriteria = x => x.Gender == (Gender)Enum.Parse(typeof(Gender), criteria["gender"]) &&
                    x.Name.ToLower() == criteria["name"].ToLower();
            }
            else if (criteria.ContainsKey("gender"))
            {
                parsedCriteria = x => x.Gender == (Gender)Enum.Parse(typeof(Gender), criteria["gender"]);
            }
            else if (criteria.ContainsKey("name"))
            {
                parsedCriteria = x => x.Name.ToLower() == criteria["name"].ToLower();
            }
            
            return parsedCriteria;
        }
    }
}
