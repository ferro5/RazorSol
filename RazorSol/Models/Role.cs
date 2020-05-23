﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorSol.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
