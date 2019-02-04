using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ICriteriaParser<T>
    {
        Func<T, bool> ParseCriteria(Dictionary<string, string> criteria);
    }
}
