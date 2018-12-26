﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StoreOfBuild.Web.ViewModels
{
    public class CategoryViewModel 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}