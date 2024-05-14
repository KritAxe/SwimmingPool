using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool.Classes
{
    public class ClassShedule
    {
        
        public static List<Shedule> shedule  = new List<Shedule>();
        public int SheduleID { get; set; }
        public string NameTrainer { get; set; }
        public string NameClient { get; set; }
        public string NamePool { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Day {  get; set; }
    }
}
