using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieMVC.Model.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public IEnumerable<SelectListItem> DeliveryTypeList { get; set; }
    }
}
