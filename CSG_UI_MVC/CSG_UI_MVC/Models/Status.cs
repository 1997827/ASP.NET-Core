using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSG_UI_MVC.Models
{
    public class Status
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsSelected { get; set; }
    }
}
