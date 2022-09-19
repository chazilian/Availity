using Exercise6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6.Services
{
    public class CsvFileService : ICsvFileService
    {
        private readonly ISeperateEnrolleeService _seperateEnrolleeService;

        public CsvFileService(ISeperateEnrolleeService seperateEnrolleeService)
        {
            _seperateEnrolleeService = seperateEnrolleeService;
        }

        public void CsvParser(string path)
        {
            var enrolleeList = new List<EnrolleeModel>();
            using (StreamReader sr = new StreamReader(path))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    var enrollee = new EnrolleeModel(currentLine);
                    enrolleeList.Add(enrollee);
                }
            }

            var result = _seperateEnrolleeService.SeperateEnrollee(enrolleeList);
            CsvBuilder(result);

        }

        private void CsvBuilder(Dictionary<string, List<EnrolleeModel>> dict)
        {

            foreach (var key in dict.Keys)
            {
                var csv = new StringBuilder();
                foreach (var enrollee in dict[key])
                {
                    var newline = string.Format($"" +
                        $"{enrollee.InsuranceCompany}," +
                        $"{enrollee.UserId}," +
                        $"{enrollee.FirstName + " " + enrollee.LastName}," +
                        $"{enrollee.Version}");
                    csv.AppendLine(newline);
                }
                var fileName = Path.Combine(Environment.CurrentDirectory, $"{key}_{Guid.NewGuid()}.csv");
                File.WriteAllTextAsync(fileName, csv.ToString());
                Console.WriteLine($"File {fileName} was created.");
            }


        }
    }
}
