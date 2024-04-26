using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class Owner
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must only consist of letters")]
    /*
    ^: start of the string
    \s: can be any amount of whitespace
    [a-zA-Z]+: can be any alphabetical character (upper+lower)
    $: end of the string
    */
    public required string OwnerName { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")] // can auto check if email is in correct format
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must include at least 1 capital letter, 1 special character, and 1 digit, and be at least 8 characters long")]
    /*
    ^: start of the string
    (?=.*[A-Z]): at least 1 upper character
    (?=.*\d): at least 1 digit 
    (?=.*[^\da-zA-Z]):at least 1 non upper/lower case character or digit present => 1 special character present
    .{8,}: is at least 8 in length

    $: end of the string
    */
    public required string Password { get; set; }
    
    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\s*\d+(\s*\d+)*$", ErrorMessage = "Phone number must contain only digits and spaces")]
    /*
    ^: start of the string
    \s*: can be any amount of whitespace
    \d+: can be any amount of digits
    $: end of the string
    */
    public required string PhoneNumber { get; set; }

}
