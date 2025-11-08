using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class ItemSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public ItemCategory Category { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
