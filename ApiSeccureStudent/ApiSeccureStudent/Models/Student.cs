

namespace ApiSeccureStudent.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Student
    {
        [Key]
        [Range(1, 9999)]
        public int StudentID { get; set; }


        [StringLength(30)]
        [Required(ErrorMessage = "You must enter the field {0}")]//usted debe ingresar el campo requerido
        public string LastName { get; set; }


        [StringLength(30, ErrorMessage = "The field {0} must contain betwen {2} and {1} characters  ", MinimumLength = 2)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public string FirstName { get; set; }
 

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

    }
}