using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//..
using SessionDemo.Models;

namespace SessionDemo.ViewModels
{
    public class HomeDisplayViewModel
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
