using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegistrationAPI.Models
{
    public class EmployeeDTO
    {
       
        public int EmployeeId { get; set; }

        public string? EmployeeCode { get; set; }

        public short SalutationId { get; set; }
        public string SalutationName { get; set; }

        public short DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string? Lastname { get; set; }

        public string DisplayName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string? MotherName { get; set; }

        public string? SpouseName { get; set; }

        public short GenderId { get; set; }
        public string GenderName { get; set; }

        public bool MaritalStatus { get; set; }

        public DateTime Dob { get; set; }

        public DateTime? Doj { get; set; }

        public string? Panno { get; set; }

        public string? Aadharno { get; set; }

        public string? Description { get; set; }
        


    }


   public class EmployeeUpdateDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        public string? EmployeeCode { get; set; }

        public short SalutationId { get; set; }
       

        public short DepartmentId { get; set; }
       

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string? Lastname { get; set; }

        public string DisplayName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string? MotherName { get; set; }

        public string? SpouseName { get; set; }

        public short GenderId { get; set; }
        
        public DepartmentDTO Department { get; set; }
        public GenderDTO Gender { get; set; }
        public SalutationDTO Salutation { get; set; }

        public bool MaritalStatus { get; set; }

        public DateTime Dob { get; set; }

        public DateTime? Doj { get; set; }

        public string? Panno { get; set; }

        public string? Aadharno { get; set; }

        public string? Description { get; set; }
        



    }
}
