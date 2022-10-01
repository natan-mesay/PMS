using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PMS.Models
{
    public class Medicine
    {
        
        public int MedicineId { get; set; }
        [Required(ErrorMessage = "Medicine Name is required")]
        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }
        public string MedicineDescription { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Medicine Mass is required")]
        [Display(Name = "Medicine Mass")]
        public int MedicineMass { get; set; }
        [Required(ErrorMessage = "Product Date is required")]
        [Display(Name = "Product Date")]
        public DateTime ProductDate { get; set; }
        [Required(ErrorMessage = "Expire Date is required")]
        [Display(Name = "Expire Date")]
        public DateTime ExpireDate { get; set; }
        [Required(ErrorMessage = "Made In is required")]
        [Display(Name = "Made In")]
        public string MadeIn { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Typeis required")]
        public string Type { get; set; }
        
    }
}
