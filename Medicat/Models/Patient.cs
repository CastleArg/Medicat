﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicat.Models
{
    public class Patient
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public Species Species { get; set; }
    }
}
