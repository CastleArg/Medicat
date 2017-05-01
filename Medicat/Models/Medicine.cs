using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicat.Models
{
    public class Medicine
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public Unit Unit { get; set; } 

    }

   public enum Unit
   {
      Millilitre,
      Gram,
      Tablet,
   }
}
