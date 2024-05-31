using System.ComponentModel.DataAnnotations;

namespace BookManagementApp.Models.DTO
{
    //Updating existing Book request DTO(Data Transfer Object) Class 
    public class UpdateBookRequestDto
    {
        public string? BookTitleToBeUpdated { get; set; }
        public string? BookAuthorToBeUpdated { get; set; }
        public DateTime? BookPublishedDateToBeUpdated { get; set; }
        [MinLength(3, ErrorMessage = "Genre has to be a minimum of 3 characters")]
        public string? BookGenreToBeUpdated { get; set; }
    }
}
