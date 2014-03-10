using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScreen
{
    public static class CheckException
    {
        /// <summary>
        /// Returns true if not null
        /// </summary>
        /// <param name="objectToCheck"></param>
        /// <returns></returns>
        public static bool CheckNull(object objectToCheck)
        {
            return objectToCheck != null;
        }   
    }
}
