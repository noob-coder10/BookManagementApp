using BookManagementApp.Models.Domain;
using System.ComponentModel.DataAnnotations;
using static HotChocolate.ErrorCodes;

namespace BookManagementApp.Models.DTO
{
    //Adding new Book request DTO(Data Transfer Object) Class 
    public class AddBookRequestDto
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BookPublishedDate { get; set; }
        [MinLength(3, ErrorMessage = "Genre has to be a minimum of 3 characters")]
        public string? BookGenre { get; set; }
    }
}
