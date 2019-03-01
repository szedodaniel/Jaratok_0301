using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class HibasJaratSzamException: Exception
    {
        public HibasJaratSzamException(string jaratSzam)
            : base("Hibas szamlaszam: " + jaratSzam)
        {

        }
    }
}
