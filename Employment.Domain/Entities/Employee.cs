using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employment.Domain.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key
        public string Name { get; set; } = string.Empty; // Employee's full name
        public string Position { get; set; } = string.Empty; // Job title or position
        public string Department { get; set; } = string.Empty; // Department name
        public decimal Salary { get; set; } // Salary of the employee
        public DateTime JoiningDate { get; set; } // Date the employee joined
    }
}
