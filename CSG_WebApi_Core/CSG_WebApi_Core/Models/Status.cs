using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CSG_WebApi_Core.Models
{
    public partial class Status
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsSelected { get; set; }
    }
}
