using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//..
using SessionDemo.Models;
using SessionDemo.ViewModels;
using SessionDemo.Services;

namespace SessionDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HomeIndexViewModel vm = new HomeIndexViewModel
            {
                Search = "add item "
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel vm)
        {
            //get the session list
            IEnumerable<Item> theList = SessionExtensions.Get<IEnumerable<Item>>(HttpContext.Session, "ItemsList");

            if(theList == null)
            {
                theList = new List<Item>();
                SessionExtensions.Set<IEnumerable<Item>>(HttpContext.Session, "ItemsList", theList);
            }
            //add one item
            Item item = new Item { ItemName = vm.Search };
            theList = theList.Append(item);

            //set the list back to session
            SessionExtensions.Set<IEnumerable<Item>>(HttpContext.Session, "ItemsList", theList);

            return RedirectToAction("Display");
              
        }

        public IActionResult Display()
        {
            //get the session list
            IEnumerable<Item> theList = SessionExtensions.Get<IEnumerable<Item>>(HttpContext.Session, "ItemsList");

            //vm
            HomeDisplayViewModel vm = new HomeDisplayViewModel
            {
                 Items = theList
            };

            return View(vm);
        }
    }
}