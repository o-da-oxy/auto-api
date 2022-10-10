using Newtonsoft.Json;
namespace Auto.Data.Entities;

public class Owner
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Registration { get; set; }
    
    [JsonIgnore]
    public virtual Vehicle OwnersVehicle { get; set; }
}