using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HairCut.Data.Models;
using HairCut.Domain;
using HairCut.Domain.Models;
using HairCut.Models.PostModels;
namespace HairCut.Controllers
{
    public class HairCutAppointmentController
    {
        private readonly HairCutService _hairCutService;
        private readonly IMapper _mapper;
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
            //var hairCutAppointmentModel = new HairCutAppointmentModel()
            //{
            //    Id = model.Id,
            //    Date = model.Date,
            //    Phone = model.Phone,
            //    Barber = model.Barber,
            //    FullName = model.FullName,
            //    HairCutStyle = model.HairCutStyle

            //};

            var hairCutAppointment = _mapper.Map<HairCutAppointmentModel>(model);

            _hairCutService.CreateHairCutRequest(hairCutAppointment);
        }
    }
}
