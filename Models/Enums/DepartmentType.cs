namespace TimeTrack.API.Models.Enums;

public static class DepartmentType
{
    public const string DotNetAngular = "Dot-net angular";
    public const string JavaReact = "Java React";
    public const string JavaAngular = "Java Angular";
    public const string MultiCloud = "Multi Cloud";

    public static readonly string[] AllDepartments = 
    {
        DotNetAngular,
        JavaReact,
        JavaAngular,
        MultiCloud
    };

    public static bool IsValid(string department)
    {
        return AllDepartments.Contains(department, StringComparer.OrdinalIgnoreCase);
    }

    public static string GetValidDepartmentsString()
    {
        return string.Join(", ", AllDepartments);
    }
}