using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCoreLecture.Models
{
    public class TblEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;set; }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]

        public string LastName { get; set; }
        [StringLength(80)]

        public string Email { get; set; }
        public int Age {  get; set; }
        public DateTime DOJ { get; set; }
        [StringLength(10)]
        public string Gender {  get; set; }
        public int IsMarried {  get; set; }
        public int IsActive { get; set; }
        public int DesignationID { get; set; }

        [NotMapped]
        public string Designation { get; set;}

        public int EmployeeID { get; set; }
    }
}
