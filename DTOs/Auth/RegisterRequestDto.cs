using System.ComponentModel.DataAnnotations;
using TimeTrack.API.Models.Enums;

namespace TimeTrack.API.DTOs.Auth;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public string Role { get; set; } // Employee, Manager, Admin

    [Required(ErrorMessage = "Department is required")]
    [StringLength(100)]
    public string Department { get; set; }

    public void Validate()
    {
        // Validate department
        if (!DepartmentType.IsValid(Department))
        {
            throw new ArgumentException(
                $"Invalid department. Allowed values: {DepartmentType.GetValidDepartmentsString()}");
        }

        // Validate role
        var validRoles = new[] { "Employee", "Manager", "Admin" };
        if (!validRoles.Contains(Role, StringComparer.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                $"Invalid role. Allowed values: {string.Join(", ", validRoles)}");
        }
    }
}