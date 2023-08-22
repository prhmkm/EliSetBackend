using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliSetBackend.Domain.DTOs
{
    public class ClotheDTO
    {
        public class GetAllClothes
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int CategoryId { get; set; }
            public string CategoryTitle { get; set; }
            public string Description { get; set; }
            public List<string>? Pictures { get; set; }
        }
        public class AddNewClothe
        {
            public string Title { get; set; }
            public int CategoryId { get; set; }
            public string Description { get; set; }
            public List<string>? Pictures { get; set; }
        }
    }
}
