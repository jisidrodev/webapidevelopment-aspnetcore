using System;

namespace ConfigurationExample.Models;

public class DatabaseOption
{
    public const string SectionName = "Database";
    public string Type { get; set; } = String.Empty;
    public string ConnectionString { get; set; } = String.Empty;

}
