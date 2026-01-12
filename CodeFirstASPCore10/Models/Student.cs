using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstASPCore10.Models
{
    public class Student
    {
        [Key]

        public int Id { get; set; }
        [Column("StudentName",TypeName = "nvarchar(100)")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Column("StudenGender", TypeName = "nvarchar(20)")]
        [Required(ErrorMessage ="Gender is required")]
        public string Gender { get; set; }
        //[Column("StudentAge", TypeName = "nvarchar(100)")]
        [Required(ErrorMessage ="Age is required")]
        public int? Age { get; set; }
        [Required(ErrorMessage ="Standard is required")]
        public int? standard { get; set; }
    }
}
