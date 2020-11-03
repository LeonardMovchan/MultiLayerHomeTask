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
            controller.MinTimeBeforeAppointmentInHours = 0;
            controller.MaxRangeForTheAppointmentInDays = 7;
            var model = new CreateHairCutAppointmentPostModel
            {
                Date = DateTime.Now.AddHours(1),
                FullName = "Phil Colinz",
                Phone = "+31111111",
                Barber = "barbara Straizand",
                HairCutStyle = "Under Cut",                         
                
            };

            controller.CreateHairCutRequest(model);

            var allAppointments = controller.GetAll();
            var appointment = controller.GetById(2);
        }
    }
}
