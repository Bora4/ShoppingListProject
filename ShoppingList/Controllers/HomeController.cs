using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShoppingList.Sessions;
using ShoppingList.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using ShoppingListAPI.Models;
using ShoppingListAPI.Models.ViewModels;
using ShoppingListAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Controllers
{

    [Authorize]
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingDBContext _context;
        private readonly CategoriesController _categoriesController;
        private readonly ShoppingListsController _slcontroller;
        private readonly ShoppingListDetailsController _sldcontroller;
        private readonly ItemsController _itemsController;
        private readonly IndexViewModel model;
        private readonly CategoryViewModel categorymodel;
        private List<Category> categorylist;






        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new();
            _categoriesController = new(_context);
            _slcontroller = new(_context);
            _sldcontroller = new(_context);
            _itemsController = new(_context);
            model = new();
            categorymodel = new();
            categorylist = new();
        }

        public IActionResult Index()
        {
            if (CurrentUser.Id == null)
            {
                return RedirectToAction("Login", "Login");
            }


            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");
            categorylist = _categoriesController.GetCategories();


            if (shoppinglist == null)
            {
                shoppinglist = new Cart();
            }
            model.Categories = categorylist;
            model.Cart = shoppinglist;
            HttpContext.Session.Set("shoppinglist", shoppinglist);

            return View(model);
        }

        [HttpPost]
        [ActionName("SetCart")]
        public async Task<IActionResult> SetCart(int id, int quantity, string cartname)
        {
            var item = await _itemsController.GetItem(id);
            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");
            
            var check = shoppinglist.Items.Find(i => i.Id == id);
            if(check == null)
            {
                ViewItem viewitem = new()
                {
                    Id = item.Value.Id,
                    Name = item.Value.Name,
                    Quantity = quantity
                };
                shoppinglist.Items.Add(viewitem);
            } else
            {
                
                shoppinglist.Items.Remove(check);
                check.Quantity = quantity;
                shoppinglist.Items.Add(check);
            }
            
            shoppinglist.Title = cartname;
            HttpContext.Session.Set("shoppinglist", shoppinglist);
            return Ok();
        }

        [HttpDelete]
        [ActionName("DontSetCart")]
        public IActionResult DontSetCart(int id, string cartname)
        {
            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");
            var item = shoppinglist.Items.Where(s => s.Id == id).FirstOrDefault();
            shoppinglist.Items.Remove(item);
            shoppinglist.Title = cartname;
            HttpContext.Session.Set("shoppinglist", shoppinglist);
            return Ok();
        }

        [HttpPost]
        [ActionName("SetTitle")]
        public IActionResult SetTitle(string cartname)
        {
            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");
            shoppinglist.Title = cartname;
            HttpContext.Session.Set("shoppinglist", shoppinglist);
            return Ok();
        }

        [HttpPost]
        [ActionName("SaveList")]
        public async Task<IActionResult> SaveList()
        {
            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");

            ShoppingListAPI.Models.ShoppingList myshoppinglist = new()
            {
                Name = shoppinglist.Title,
                UserId = (int)CurrentUser.Id,
            };

            var result = _slcontroller.PostShoppingList(myshoppinglist);
            result.Wait();
            foreach (ViewItem item in shoppinglist.Items)
            {
                ShoppingListDetail mydetails = new()
                {
                    ShoppingListId = ((ShoppingListDTO)((ObjectResult)result.Result.Result).Value).Id,
                    ItemId = item.Id,
                    Quantity = item.Quantity

                };
                await _sldcontroller.PostShoppingListDetail(mydetails);

            };


            shoppinglist.Items = new();
            shoppinglist.Title = "";

            HttpContext.Session.Set("shoppinglist", shoppinglist);

            return RedirectToAction("MyShoppingLists");
        }

        [HttpGet]
        [ActionName("MyShoppingLists")]
        public IActionResult MyShoppingListsx()
        {
            List<ShoppingListAPI.Models.ShoppingList> allShoppingLists = _context.ShoppingLists.Where(s => s.UserId == CurrentUser.Id).ToList();


            return View("MyShoppingLists", allShoppingLists);
        }

        [HttpPost]
        [ActionName("FinalTitle")]

        public void FinalTitle(int id)
        {
            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");
            shoppinglist.Id = id;
            HttpContext.Session.Set("shoppinglist", shoppinglist);
        }

        [HttpGet]
        [ActionName("Market")]

        public async Task<IActionResult> MarketGet()
        {
            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");

            int finalId = (int)shoppinglist.Id;

            var finalResult = await _slcontroller.GetShoppingList(finalId);

            ShoppingListDTO finalListDTO = (ShoppingListDTO)((ObjectResult)finalResult.Result).Value;

            ShoppingListAPI.Models.ShoppingList finalList = new()
            {
                Id = finalListDTO.Id,
                Name = finalListDTO.Name,
                UserId = finalListDTO.UserId
            };

            Cart emptylist = new();

            HttpContext.Session.Set("shoppinglist", emptylist);


            return View("Market", finalList);

        }


        [HttpPost]
        [ActionName("Market")]
        public async Task<IActionResult> Market()
        {

            string name = Request.Form["ShoppingListName"];
            
            int shoppinglistid = 1;

            Cart shoppinglist = HttpContext.Session.Get<Cart>("shoppinglist");

            if (name != null) 
            {
                ShoppingListAPI.Models.ShoppingList myshoppinglist = new()
                {
                    Name = name,
                    UserId = (int)CurrentUser.Id,
                };

                var result = _slcontroller.PostShoppingList(myshoppinglist);
                result.Wait();


                foreach (ViewItem item in shoppinglist.Items)
                {
                    ShoppingListDetail mydetails = new()
                    {
                        ShoppingListId = ((ShoppingListDTO)((ObjectResult)result.Result.Result).Value).Id,
                        ItemId = item.Id,
                        Quantity = item.Quantity

                    };
                    await _sldcontroller.PostShoppingListDetail(mydetails);

                }

                shoppinglistid = ((ShoppingListDTO)((ObjectResult)result.Result.Result).Value).Id;
                
            } else
            {
                
                RedirectToAction("Index", "Home");
            }

            var finalResult = await _slcontroller.GetShoppingList(shoppinglistid);

            ShoppingListDTO finalListDTO = (ShoppingListDTO)((ObjectResult)finalResult.Result).Value;

            ShoppingListAPI.Models.ShoppingList finalList = new()
            {
                Id = finalListDTO.Id,
                Name = finalListDTO.Name,
                UserId = finalListDTO.UserId
            };

            Cart emptylist = new();

            HttpContext.Session.Set("shoppinglist", emptylist);

            return View("Market", finalList);
        }

        



            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("AddItemMenu")]
        public IActionResult AddItemMenu()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("AddItemMenu")]
        public async Task<IActionResult> AddItemMenux()
        {
            Item item = new()
            {
                Name = Request.Form["ItemName"],
                CategoryId = Convert.ToInt32(Request.Form["CategoryId"])
            };


            await _itemsController.PostItem(item);


            return View("AddItemMenu");
        }

        [HttpGet]
        [ActionName("Logout")]
        public async Task<IActionResult> Logout()
        {
            CurrentUser.FirstName = null;
            CurrentUser.LastName = null;
            CurrentUser.Email = null;
            CurrentUser.Id = null;
            CurrentUser.RememberMe = false;

            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Login");
            
        }
    }


}

