using Exercise6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6.Services
{
    public class SeperateEnrolleeService : ISeperateEnrolleeService
    {
        public Dictionary<string, List<EnrolleeModel>> SeperateEnrollee(List<EnrolleeModel> input)
        {
            Dictionary<string, List<EnrolleeModel>> dictEnrollee = new Dictionary<string, List<EnrolleeModel>>();
            foreach (EnrolleeModel enrollee in input)
            {
                // add to dictionary if it doesn't exist
                if (!dictEnrollee.ContainsKey(enrollee.InsuranceCompany))
                {
                    dictEnrollee.Add(enrollee.InsuranceCompany, new List<EnrolleeModel>());
                    dictEnrollee[enrollee.InsuranceCompany].Add(enrollee);
                    continue;
                }

                // add to enrollee to List
                dictEnrollee[enrollee.InsuranceCompany].Add(enrollee);
            }

            return RemoveDuplicates(dictEnrollee);
        }

        private Dictionary<string, List<EnrolleeModel>> RemoveDuplicates(Dictionary<string, List<EnrolleeModel>> dict)
        {
            Dictionary<string, List<EnrolleeModel>> dictTemp = new Dictionary<string, List<EnrolleeModel>>();

            foreach (string key in dict.Keys)
            {
                //finds all unique versions of Enrollees
                var uniqueEnrollees = dict[key]
                    .GroupBy(g => g.UserId)
                    .Where(w => w.Count() == 1)
                    .SelectMany(s => s);

                //finds duplicates and returns highest version of it
                var duplicateEnrollees = dict[key]
                    .GroupBy(g => g.UserId)
                    .Where(w => w.Count() > 1)
                    .Select(s => s.OrderByDescending(a => a.Version).FirstOrDefault());

                var combineEnrollees = OrderByLastNameThenFirstName(uniqueEnrollees, duplicateEnrollees);

                dictTemp.Add(key, combineEnrollees.ToList());
            }

            return dictTemp;
        }

        private IOrderedEnumerable<EnrolleeModel> OrderByLastNameThenFirstName(IEnumerable<EnrolleeModel> a, IEnumerable<EnrolleeModel?> b)
        {
            if (b.Count() == 0)
            {
                return a.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            }
            else
            {
                return a.Concat(b).OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            }
        }
    }
}
