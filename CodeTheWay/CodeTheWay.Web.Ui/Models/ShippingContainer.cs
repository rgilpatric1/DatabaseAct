﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;

namespace CodeTheWay.Web.Ui.Models
{
    public class ShippingContainer
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public string Destination { get; set; }
    }
}