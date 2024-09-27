using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegistrationAPI.Models;

public partial class Salutation
{
    public short SalutationId { get; set; }

    public string SalutationName { get; set; } = null!;
    
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
