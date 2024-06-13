using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace classlibrary
{
    public class Busdetails
    {
        public int BusID { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name ="Bus Name")]
        public string BusName { get; set; }
        [Required]
        [Display(Name = "Driver Contact Number")]
        [Range(1,9999999999, ErrorMessage ="Please Enter the correct number")]
        public string DriverMobilenumber { get; set; }
        [Required]
        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        [Display(Name ="Fair Amount")]
        public long Fair { get; set; }
        [Required]
        [Display(Name = "No.of.Passenger")]
        public long NoofPassenger { get; set; }
        public int LocationID { get; set; }
        public IEnumerable<StartPoint> Location { get; set; }
    }
}
