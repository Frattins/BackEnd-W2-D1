using Microsoft.AspNetCore.Mvc;
using BackEnd_W2_D1.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd_W2_D1.Controllers
{
    public class MenuController : Controller
    {
        private static readonly List<MenuItems> MenuItemss = new List<MenuItems>
        {
            new MenuItems { Id = 1, Name = "Coca Cola 150 ml", Price = 2.50m },
            new MenuItems { Id = 2, Name = "Insalata di pollo", Price = 5.20m },
            new MenuItems { Id = 3, Name = "Pizza Margherita", Price = 10.00m },
            new MenuItems { Id = 4, Name = "Pizza 4 Formaggi", Price = 12.50m },
            new MenuItems { Id = 5, Name = "Patatine fritte", Price = 3.50m },
            new MenuItems { Id = 6, Name = "Insalata di riso", Price = 8.00m },
            new MenuItems { Id = 7, Name = "Frutta di stagione", Price = 5.00m },
            new MenuItems { Id = 8, Name = "Pizza fritta", Price = 5.00m },
            new MenuItems { Id = 9, Name = "Piadina vegetariana", Price = 6.00m },
            new MenuItems { Id = 10, Name = "Panino Hamburger", Price = 7.90m },
        };

        private static List<MenuItems> selectedItems = new List<MenuItems>();

        public IActionResult Index()
        {
            ViewBag.MenuItemss = MenuItemss;
            ViewBag.SelectedItems = selectedItems;
            ViewBag.Total = selectedItems.Sum(item => item.Price) + 3.00m; // Include table service fee
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(int id)
        {
            var MenuItems = MenuItemss.FirstOrDefault(item => item.Id == id);
            if (MenuItems != null)
            {
                selectedItems.Add(MenuItems);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearOrder()
        {
            selectedItems.Clear();
            return RedirectToAction("Index");
        }
    }
}