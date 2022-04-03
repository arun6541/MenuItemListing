using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItemWebAPI.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MenuItemId { get; set; }

        public string MenuItemName { get; set; }

        public Cart(int id,int userId,int menuItemId,string menuItemName)
        {
            this.Id = id;
            this.UserId = userId;
            this.MenuItemId = menuItemId;
            this.MenuItemName = menuItemName;
        }
    }
}
