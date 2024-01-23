using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestLibrary
{
    /// <summary>
    /// Represents an employee with an ID, first name, and last name.
    /// </summary>
    public class Employee : IComparable<Employee>
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        /// <summary>
        /// Initializes a new instance of the Employee class with the specified ID.
        /// </summary>
        /// <param name="employeeId">The unique identifier for the new employee.</param>
        public Employee(int employeeId)
        {
            this.EmployeeID = employeeId;
        }

        /// <summary>
        /// Initializes a new instance of the Employee class with the specified ID, first name, and last name.
        /// </summary>
        /// <param name="employeeId">The unique identifier for the new employee.</param>
        /// <param name="firstName">The first name of the new employee.</param>
        /// <param name="lastName">The last name of the new employee.</param>
        public Employee(int employeeId, string firstName, string lastName)
        {
            this.EmployeeID = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Compares the current Employee instance with another Employee object for sort order.
        /// </summary>
        /// <param name="other">The Employee to compare with this instance.</param>
        /// <returns>
        /// An integer that indicates the order of the employees being compared.
        /// </returns>
        public int CompareTo(Employee other)
        {
            return this.EmployeeID.CompareTo(other.EmployeeID);
        }

        /// <summary>
        /// Returns a string representation of the current Employee object.
        /// </summary>
        /// <returns>
        /// A string containing the employee's ID, first name, and last name. 
        /// </returns>
        public override string ToString()
        {
            string firstName = FirstName ?? "null";
            string lastName = LastName ?? "null";

            return string.Format("{0} {1} {2}", EmployeeID, firstName, lastName);
        }
    }
}
