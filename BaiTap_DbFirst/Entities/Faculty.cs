using System;
using System.Collections.Generic;

namespace BaiTap_DbFirst.Entities;

public partial class Faculty
{
    public string FacultyId { get; set; } = null!;

    public string? FacultyName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
