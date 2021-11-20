using BookCart.Application.Common.Mappings;
using BookCart.Domain.Entities;

namespace BookCart.Application.Common.Models
{
    public class BookDto : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
    }
}