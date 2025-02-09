using System.ComponentModel.DataAnnotations;

public class Review
{
    public int Id { get; set; }  // Primary key for the database
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Rating is required")]
    public int Rating { get; set; }
    [Required(ErrorMessage = "Comments are required")]
    public string Comments { get; set; }
}

