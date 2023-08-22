using System;
using System.Collections.Generic;

namespace EliSetBackend.Domain.Models
{
    public partial class Picture
    {
        public long Id { get; set; }
        public int ClothesId { get; set; }
        public string? ImageName { get; set; }
        public string? Address { get; set; }
    }
}
