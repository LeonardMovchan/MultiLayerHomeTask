using AutoMapper;
using HairCut.Domain;
using HairCut.Domain.Models;
using HairCut.Models.PostModels;
using HairCut.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace HairCut.Controllers
{
    public class HairCutAppointmentController
    {
        private readonly HairCutService _hairCutService;
        private readonly IMapper _mapper;
        public int MinTimeBeforeAppointmentInHours { get; set; }
        public int MaxRangeForTheAppointmentInDays { get; set; }
        public HairCutAppointmentController()
        {
            _hairCutService = new HairCutService();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateHairCutAppointmentPostModel, HairCutAppointmentModel>();
                cfg.CreateMap<HairCutAppointmentModel, HairCutAppointmentViewModel>();
                
            
            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateHairCutRequest(CreateHairCutAppointmentPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Phone))
                throw new Exception("Phone number is reuqired to make a reservation");
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new Exception("Full Name is required to make a reservation");
            if (model.Date < DateTime.UtcNow.AddHours(MinTimeBeforeAppointmentInHours))
                throw new Exception("Our barbers need some time to prepare");
            if (model.Date > DateTime.UtcNow.AddDays(MaxRangeForTheAppointmentInDays))
                throw new Exception($"The appoinement should be schedulled within {MaxRangeForTheAppointmentInDays} period");

            var hairCutAppointment = _mapper.Map<HairCutAppointmentModel>(model);

            _hairCutService.CreateHairCutRequest(hairCutAppointment);
        }

     public IEnumerable<HairCutAppointmentViewModel> GetAll()
        {
            IEnumerable<HairCutAppointmentModel> models = _hairCutService.GetAll();

            return _mapper.Map<IEnumerable<HairCutAppointmentViewModel>>(models);
        }

      public HairCutAppointmentViewModel GetById(int id)
        {
            HairCutAppointmentModel model = _hairCutService.GetById(id);
            return _mapper.Map<HairCutAppointmentViewModel>(model);
        }
    }
}
