using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Application
    {
        public long Id { get; set; }
        public long SoftwareNameId { get; set; }
        public long AppealId { get; set; }

        //public long ExecutorUserId { get; set; }  
        public string Description { get; set; }
        public string PCNumber { get; set; }
        public long StatusId { get; set; }
        public string UserFullName { get; set; }
    }
}
