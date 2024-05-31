namespace BookManagementApp.Models.DTO
{
    //Book details DTO (Data Transfer Object) Class
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BookPublishedDate { get; set; }
        public string? BookGenre { get; set; }
    }
}
