using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6.Models
{
    public class EnrolleeModel
    {
        public EnrolleeModel(string input)
        {
            string[] arr = input.Split(",");

            UserId = arr[0].Trim();

            string[] nameArr = arr[1].Split(" ");
            FirstName = nameArr[0].Trim();
            LastName = nameArr[1].Trim();

            Version = int.Parse(arr[2].Trim());
            InsuranceCompany = arr[3].Trim();
        }
        public EnrolleeModel(string userId, string firstName, string lastName, int version, string insuranceCompany)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Version = version;
            InsuranceCompany = insuranceCompany;
        }

        public string UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Version { get; private set; }
        public string InsuranceCompany { get; private set; }
    }
}
