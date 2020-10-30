using HairCut.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairCut.Data.Repositories
{
    public class HairCutAppointmentRepository
    {
        private List<HairCutAppointment> hairCutAppointments { get; set; }

        public HairCutAppointmentRepository()
        {
            hairCutAppointments = new List<HairCutAppointment>();
        }
        public void Create(HairCutAppointment model)
        {
            hairCutAppointments.Add(model);
        }

        public HairCutAppointment GetById(string id)
        {
            var appointment = hairCutAppointments
                .FirstOrDefault(x => x.Id == id);                             
            return appointment;
          
        }   
    }
}
