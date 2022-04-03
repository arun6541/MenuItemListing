using CloudConsole.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace CloudConsole
{
    public class Program
    {
        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(
                        issuer: "mySystem",
                        audience: "myUsers",
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:15338/api/");
                var response = client.GetAsync("MenuItem");
                response.Wait();
                var res = response.Result;
                var list = res.Content.ReadAsAsync<MenuItem[]>();
                list.Wait();
                var menuItem = list.Result;
                Console.WriteLine("Name\t\tPrice\tDeliveryStatus\tLaunchedDate\tActive");
                foreach(var Item in menuItem)
                {
                    Console.WriteLine(Item.Name+"\t\t"+Item.Price+"\t"+Item.FreeDelivery+"\t\t"+Item.DateOfLaunch.ToShortDateString()+"\t"+Item.Active);
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:23966/api/");
                Console.WriteLine("Enter a menuItemId");
                int menuItemId = int.Parse(Console.ReadLine());
                /*if(menuItemId<1 || menuItemId>4)
                {
                    Console.WriteLine("Invalid menuItemId");
                    return;
                }*/
                var response = client.GetAsync($"Order?menuItemId={menuItemId}");
                response.Wait();
                var res = response.Result;
                if (res.IsSuccessStatusCode)
                {
                    var list = res.Content.ReadAsAsync<Cart>();
                    list.Wait();
                    var cartItem = list.Result;
                    Console.WriteLine(cartItem.UserId + "\t" + cartItem.MenuItemId + "\t" + cartItem.MenuItemName);
                }
                else
                {
                    Console.WriteLine("Item not found");
                }
            }
        }
    }
}
