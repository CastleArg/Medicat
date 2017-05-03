using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Medicat.Models
{
   public class Administration
   {
      public int Id { get; set; }
      public int PatientId { get; set; }
      public int MedicineId { get; set; }
      public decimal Dose { get; set; }
      [DataType(DataType.Date)]
      public DateTime AdministrationDate { get; set; }
      public int ApplicationUserId {get; set;}
    }
}
