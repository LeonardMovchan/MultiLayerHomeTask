using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace HairCut.Domain.Models
{
    public class HairCutAppointmentModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string HairCutStyle { get; set; }
        public string Barber { get; set; }
        public DateTime Date { get; set; }
    }
}
