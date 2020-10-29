using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Models

{
    public class HairCutAppointment
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string HairCutStyle { get; set; }
        public string Barber { get; set; }
        public DateTime Date { get; set; }
    }
}
