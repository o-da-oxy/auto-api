using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Auto.Website.Models;

public class OwnerDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    private string _registration;

    private static string NormalizeRegistration(string reg) {
        return reg == null ? reg : Regex.Replace(reg.ToUpperInvariant(), "[^A-Z0-9]", "");
    }

    [Required]
    [DisplayName("Registration Plate")]
    public string Registration {
        get => NormalizeRegistration(_registration);
        set => _registration = value;
    }
}