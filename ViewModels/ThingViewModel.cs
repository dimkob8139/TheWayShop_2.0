using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.ViewModels
{
    public class ThingViewModel
    {
        public Thing Thing { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
