using System;
using System.Collections.Generic;

namespace DatabaseTask.EF.Tables;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
