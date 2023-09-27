﻿using GroceryDelivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.DTOs
{
    public class DriverForCreationDto
    {
        public string FirsName { get; set; }
        public string Lastname { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
