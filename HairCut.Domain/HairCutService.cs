using AutoMapper;
using HairCut.Data.Models;
using HairCut.Data.Repositories;
using HairCut.Domain.Models;
namespace HairCut.Domain
{
    public class HairCutService
    {
        private readonly HairCutAppointmentANRepository _hairCutAppointmentANRepository;
        private readonly IMapper _mapper;
        public HairCutService()
        {
            _hairCutAppointmentANRepository = new HairCutAppointmentANRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HairCutAppointmentModel, HairCutAppointment>().ReverseMap();

            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateHairCutRequest(HairCutAppointmentModel model)
        {
          
            var hairCutAppointmenet = _mapper.Map<HairCutAppointment>(model);

            _hairCutAppointmentANRepository.Create(hairCutAppointmenet);
        }
    }
}
