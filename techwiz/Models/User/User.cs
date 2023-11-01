namespace TechWiz.Models{

    public class User
    {   
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AboutMe { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string githubUrl { get; set; } = string.Empty;
        public string imageUrl { get; set; } = string.Empty;
        public string linkedinUrl { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    
}