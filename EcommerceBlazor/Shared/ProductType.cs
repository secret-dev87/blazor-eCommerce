using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Deleted { get; set; } = false;
        [NotMapped] //not visible as a column in DB
        public bool Editing { get; set; } = false;
        [NotMapped] //only for the form
        public bool IsNew { get; set; } = false;
    }
}
