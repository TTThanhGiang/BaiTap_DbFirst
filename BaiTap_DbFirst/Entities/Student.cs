using System;
using System.Collections.Generic;

namespace BaiTap_DbFirst.Entities;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? StudentName { get; set; }

    public DateOnly Gender { get; set; }

    public string? Address { get; set; }

    public string? FacultyId { get; set; }

    public virtual Faculty? Faculty { get; set; }
}
