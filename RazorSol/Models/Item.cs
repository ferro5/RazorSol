﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorSol.Models
{
    public class Item
    {
        public virtual ProductCart product { get; set; }
        public int Quantity { get; set; }

    }
}
