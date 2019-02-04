using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.IO;

namespace Services.Services
{
    public interface IParseDataService
    {
        IList<Student> ParseData(StreamReader reader);
    }
}
