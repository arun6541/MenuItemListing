using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemListingWebAPI.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name ="Free Delivery")]
        public bool FreeDelivery { get; set; }

        [Required]
        public double Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DateOfLaunch { get; set; }

        public bool Active { get; set; }

        public MenuItem(int id,string name,bool fd,double price,string date,bool active)
        {
            this.Id = id;
            this.Name = name;
            this.FreeDelivery = fd;
            this.Price = price;
            this.DateOfLaunch = DateTime.Parse(date);
            this.Active = active;
        }
    }
}
