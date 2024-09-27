using System;
using System.Collections.Generic;

namespace EmployeeRegistrationAPI.Models;

public partial class Employee
{
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

    public bool MaritalStatus { get; set; }

    public DateTime Dob { get; set; }

    public DateTime? Doj { get; set; }

    public string? Panno { get; set; }

    public string? Aadharno { get; set; }

    public string? Description { get; set; }
     
    //public string DepartmentName { get; set; }
    //public string GenderName { get; set; }
   // public string SalutationName { get; set; }


    public virtual Department Department { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual Salutation Salutation { get; set; } = null!;
}
