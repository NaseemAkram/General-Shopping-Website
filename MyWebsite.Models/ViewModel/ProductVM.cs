﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebsite.Models.Models;

namespace MyWebsite.Models.ViewModel
{
    public class ProductVM
    {
        public Product product { get; set; }
        [ValidateNever]
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        [ValidateNever]

        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
