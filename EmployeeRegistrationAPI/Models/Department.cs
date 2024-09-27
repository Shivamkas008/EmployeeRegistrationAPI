using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegistrationAPI.Models;

public partial class Department
{
    public short DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

   
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
