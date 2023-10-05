using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public class Header<T> where T:class
    {
        public List<T> Results { set; get; }
    }
}
