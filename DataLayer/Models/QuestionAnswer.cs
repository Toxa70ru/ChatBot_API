using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class QuestionAnswer
    {
        public long Id { get; set; }
        public long SoftwareNameId { get; set; }
        //public SoftwareName SoftwareName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
