using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarAjaxJquery.Models
{
    public class CreateCarViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter brand name."), MaxLength(50), MinLength(3)]
        [Display(Name ="Brand Name")]
        public string Brand { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="Enter milage")]
        [Display(Name = "Car Milage")]
        public int Milage { get; set; }
    }
}
