using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegistrationAPI.Models;

public partial class Gender
{
    public short GenderId { get; set; }

    public string GenderName { get; set; } = null!;
    
   public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
