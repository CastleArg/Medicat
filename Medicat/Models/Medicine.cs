using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Medicat.Models
{
   public class Medicine
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public Unit Unit { get; set; } 
      [NotMapped]
      public string DisplayName { get { return $"{Name} ({Unit}s)"; } }

    }

   public enum Unit
   {
      Millilitre,
      Gram,
      Tablet,
   }
}
