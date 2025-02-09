
using System.ComponentModel.DataAnnotations;

public class User {
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string Email { get; set; } // Future improvement
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    public string Role { get; set; } // Future improvement
    public string Token { get; set; } // Future improvement
}