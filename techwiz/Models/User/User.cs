namespace TechWiz.Models{

    public class User
    {   
        public uint Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AboutMe { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string GithubUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string LinkedinUrl { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    
}