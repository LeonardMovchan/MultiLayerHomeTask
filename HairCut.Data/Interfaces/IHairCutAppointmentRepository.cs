using HairCut.Data.Models;
using System.Collections.Generic;

namespace HairCut.Data.Interfaces
{
    public interface IHairCutAppointmentRepository
    {
        HairCutAppointment Create(HairCutAppointment model);
        IEnumerable<HairCutAppointment> GetAll();
        HairCutAppointment GetById(int id);
        IEnumerable<HairCutAppointment> GetRecentAppointmentDates();
    }
}
