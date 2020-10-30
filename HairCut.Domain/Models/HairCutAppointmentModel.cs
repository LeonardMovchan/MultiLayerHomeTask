using System;
namespace HairCut.Domain.Models
{
    public class HairCutAppointmentModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string HairCutStyle { get; set; }
        public string Barber { get; set; }
        public DateTime Date { get; set; }
    }
}
