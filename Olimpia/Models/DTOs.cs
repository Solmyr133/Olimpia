namespace Olimpia.Models
{
    public class DTOs
    {
        public record CreateDataDTO(string Country, string County, string Description);
        public record UpdateDataDTO(Guid Id, string Country, string County, string Description);
        public record CreatePlayerDTO(string Name, int Age, int Weight, int Height);
        public record UpdatePlayerDTO(Guid Id, string Name, int Age, int Weight, int Height);
    }
}
