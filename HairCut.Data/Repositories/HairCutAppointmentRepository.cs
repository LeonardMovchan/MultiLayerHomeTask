using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public HairCutAppointment GetById(int id)
        {
            return null;
        }
    }
}
