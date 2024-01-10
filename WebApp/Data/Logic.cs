using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApp.Data
{
    public class Logic
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Created")]
        public DateTime Created { get; set; }

        [DisplayName("Value")]
        [Required]
        public int Value { get; set; }

        [DisplayName("Success")]
        public bool Success { get; set; }
    }
}
