using System;
using System.Collections.Generic;

namespace EliSetBackend.Domain.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
