using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashServiceApp.Models
{
    [Table("AppointmentService")]
    public class AppointmentService
    {
        [Key]
        public int AppointmentServiceId { get; set; }
        public Appointment Appointment { get; set; }
        public Service Service { get; set; }                
        public double Amount { get; set; }
    }
}
