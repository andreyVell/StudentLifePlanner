using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.Data.Entities
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? SecondName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? LastName { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? AvatarUrl { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Login { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string PasswordHash { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string PasswordSalt { get; set; }

    }
}
