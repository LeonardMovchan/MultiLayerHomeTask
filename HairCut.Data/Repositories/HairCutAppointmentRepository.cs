using HairCut.Data.Models;
using System.Collections.Generic;
using System.ComponentModel;

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
            var appointment = new HairCutAppointment();
            foreach (var item in hairCutAppointments)
            {
                if (item.Id == id)
                {
                    appointment = item;
                }                   
            }
            return appointment;
        }
    }
}
