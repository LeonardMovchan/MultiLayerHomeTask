using AutoMapper;
using HairCut.Data.Interfaces;
using HairCut.Data.Models;
using HairCut.Data.Repositories;
using HairCut.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace HairCut.Domain
{
    public class HairCutService
    {
        private readonly IHairCutAppointmentRepository _hairCutAppointmentRepository;
        private readonly IMapper _mapper;
        public HairCutService()
        {
            _hairCutAppointmentRepository = new HairCutAppointmentDapperRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HairCutAppointmentModel, HairCutAppointment>().ReverseMap();

            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateHairCutRequest(HairCutAppointmentModel model)
        {
            var appointments = _hairCutAppointmentRepository.GetRecentAppointmentDates();
            var MinTimeBeforeAppointmentInHours = 1;

            if (appointments.Any(x => x.Date.AddHours(MinTimeBeforeAppointmentInHours) >= model.Date && x.Barber == model.Barber))
                throw new System.Exception("The date is already taken");
          
            var hairCutAppointmenet = _mapper.Map<HairCutAppointment>(model);

            _hairCutAppointmentRepository.Create(hairCutAppointmenet);
        }

        public IEnumerable<HairCutAppointmentModel> GetAll()
        {
            IEnumerable<HairCutAppointment> models = _hairCutAppointmentRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<HairCutAppointmentModel>>(models);

            return mappedModels;
        }

        public HairCutAppointmentModel GetById(int id)
        {
            HairCutAppointment model = _hairCutAppointmentRepository.GetById(id);
            return _mapper.Map<HairCutAppointmentModel> (model);
        }
    }
}
