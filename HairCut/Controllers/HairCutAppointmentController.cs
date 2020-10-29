using AutoMapper;
using HairCut.Domain;
using HairCut.Domain.Models;
using HairCut.Models.PostModels;
using System;
namespace HairCut.Controllers
{
    public class HairCutAppointmentController
    {
        private readonly HairCutService _hairCutService;
        private readonly IMapper _mapper;
        public int MinTimeBeforeAppointment { get; set; }
        public HairCutAppointmentController()
        {
            _hairCutService = new HairCutService();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateHairCutAppointmentPostModel, HairCutAppointmentModel>().ReverseMap();
            
            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateHairCutRequest(CreateHairCutAppointmentPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Phone))
                throw new Exception("Phone number is reuqired to make a reservation");
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new Exception("Full Name is required to make a reservation");
            if (model.Date < DateTime.UtcNow.AddHours(MinTimeBeforeAppointment))
                throw new Exception("Our barbers need some time to prepare");

            var hairCutAppointment = _mapper.Map<HairCutAppointmentModel>(model);

            _hairCutService.CreateHairCutRequest(hairCutAppointment);
        }

     
    }
}
