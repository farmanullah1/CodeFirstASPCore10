using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstASPCore10.Models
{
    public class Student
    {
        [Key]

        public int Id { get; set; }
        [Column("StudentName",TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column("StudenGender", TypeName = "nvarchar(20)")]
        public string Gender { get; set; }
        //[Column("StudentAge", TypeName = "nvarchar(100)")]
        public int Age { get; set; }
    }
}
