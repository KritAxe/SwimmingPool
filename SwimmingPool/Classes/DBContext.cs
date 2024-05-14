using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool.Classes
{
    internal class DBContext
    {
        public static SwimmingPoolComplexEntities context { get; set; } = new SwimmingPoolComplexEntities();
    }
}
