using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCleanArchitecture.Domain.Entities
{
    [Table("temp_login")] // Specifies the exact table name in the database
    public class TempLogin
    {
        [Key] // Marks this as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specifies auto-increment
        public int Id { get; set; }

        [StringLength(255)] // Sets maximum length
        public required string Username { get; set; }

        [StringLength(255)] // Sets maximum length
        public required string Password { get; set; }

        public bool CheckPassword(string password)
        {
            return Password == password;    
        }
    }
}
