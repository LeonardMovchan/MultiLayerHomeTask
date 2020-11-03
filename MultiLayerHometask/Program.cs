using HairCut.Controllers;
using HairCut.Models.PostModels;
using System;

namespace MultiLayerHometask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new HairCutAppointmentController();
            controller.MinTimeBeforeAppointment = 0;

            var model = new CreateHairCutAppointmentPostModel
            {
                Date = DateTime.Now.AddMinutes(50),
                FullName = "Phil Colinz",
                Phone = "+31111111",
                Barber = "Barbara Straizand",
                HairCutStyle = "Under Cut",                         
                
            };

            controller.CreateHairCutRequest(model);

            var allAppointments = controller.GetAll();
            var appointment = controller.GetById(2);
        }
    }
}
