using System.ComponentModel.DataAnnotations;

namespace BookManagementApp.Models.Domain
{
    //Book Domain Class
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? Genre { get; set; }
    }
}
