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

            UserId = arr[0]?.Trim() ?? "";

            string[] nameArr = arr[1]?.Split(" ") ?? new string[2];
            //If only one name is passed then it will be used as first and last name

            FirstName = nameArr.First().Trim() ?? "";
            LastName = nameArr.Last().Trim() ?? "";
            //will default version to 0 if none is passed
            string v = String.IsNullOrEmpty(arr[2]) ? "0" : arr[2];
            Version = int.Parse(v);
            InsuranceCompany = arr[3]?.Trim() ?? "";
        }
        public EnrolleeModel(string userId, string firstName, string lastName, int version, string insuranceCompany)
        {
            UserId = userId ?? "";
            FirstName = firstName ?? "";
            LastName = lastName ?? "";
            Version = version;
            InsuranceCompany = insuranceCompany ?? "";
        }

        public string UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Version { get; private set; }
        public string InsuranceCompany { get; private set; }
    }
}
