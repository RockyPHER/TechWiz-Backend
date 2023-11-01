namespace TechWiz.Models
{
    public class UserTechnology
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public uint TechnologyId { get; set; }
        public uint InterestLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UptatedAt { get; set; } 
        public uint Position { get; set; }
    }
}