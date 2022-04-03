using MenuItemListingWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemListingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        List<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem(1,"Pizza",true,100.00,"2022-03-31",true),
            new MenuItem(2,"Burger",true,150.00,"2022-03-31",false),
            new MenuItem(3,"Sandwich",false,200.00,"2022-03-31",true),
            new MenuItem(4,"Noodles",false,250.00,"2022-03-31",false)
        };

        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return menuItems;
        }
        
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            return menuItems[id - 1];
        }
    }
}
