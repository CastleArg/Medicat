using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicat.Models
{
   public class Administration
   {
      public int Id { get; set; }
      public Patient Patient { get; set; }
      public Medicine Medicine { get; set; }
      public DateTime AdministrationDate { get; set; }
      public ApplicationUser RecordedBy {get; set;}
    }
}
