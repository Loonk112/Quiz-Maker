using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    internal class BoolToString
    {
        public static string BTS(bool _bool)
        {
            if (_bool)
                return "T";
            else
                return "F";
        }
    }
}
