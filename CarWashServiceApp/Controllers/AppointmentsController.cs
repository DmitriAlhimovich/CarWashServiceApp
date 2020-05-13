using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarWashServiceApp.Data;
using CarWashServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarWashServiceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<ServicesController> logger;

        public AppointmentsController(ILogger<ServicesController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Appointment> Index()
        {
            using (var context = new CarWashServiceContext())
            {
                var list = context.Appointments.OrderByDescending(a => a.StartTime).ToList();

                return list;
            }
        }

        [HttpPost()]
        public IActionResult Add(AppointmentDto appointmentDto)
        {
            using (var context = new CarWashServiceContext())
            {
                var appointment = new Appointment
                {
                    StartTime = appointmentDto.StartTime,
                    Customer = context.Customers.First(c => c.CustomerId == appointmentDto.CustomerId)
                };

                context.Appointments.Add(appointment);
                context.AppointmentServices.AddRange(
                    appointmentDto.ServicesIds.Select(id => new AppointmentService()
                    {
                        Appointment = appointment,
                        Service = context.Services.First(s => s.ServiceId == id)
                    })
                    );
                context.SaveChanges();
            }

            return Ok();
        }
    }
}
