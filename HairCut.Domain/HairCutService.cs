using HairCut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairCut.Data;
using HairCut.Data.Repositories;
using HairCut.Data.Models;
using AutoMapper;
namespace HairCut.Domain
{
    public class HairCutService
    {
        private readonly HairCutAppointmentRepository _hairCutAppointmentRepository;
        public HairCutService()
        {
            _hairCutAppointmentRepository = new HairCutAppointmentRepository();
        }

        public void CreateHairCutRequest(HairCutAppointmentModel model)
        {
            var hairCutAppointmenet = new HairCutAppointment()
            {
                Id = model.Id,
                Date = model.Date,
                Phone = model.Phone,
                Barber = model.Barber,
                FullName = model.FullName,
                HairCutStyle = model.HairCutStyle
            };

            _hairCutAppointmentRepository.Create(hairCutAppointmenet);
        }
    }
}
