using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TechWiz.Models{

    public class User
    {   
        [Key]
        public uint Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UptadetAt { get; set; }
    }
    
}