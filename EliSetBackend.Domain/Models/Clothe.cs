using System;
using System.Collections.Generic;

namespace EliSetBackend.Domain.Models
{
    public partial class Clothe
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int CategoryId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreationDateTime { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
