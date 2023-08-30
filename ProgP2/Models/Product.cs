using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using test8.Areas.Identity.Data;

namespace test8.Models
{
    public class Product
    {

        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime DateExpected { get; set; }
        public string UserId { get; set; }
        public virtual test8User User { get; set; }

        public String Type { get; set; }

    }
}
