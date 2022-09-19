using Exercise6.Models;

namespace Exercise6.Services
{
    public interface ISeperateEnrolleeService
    {
        Dictionary<string, List<EnrolleeModel>> SeperateEnrollee(List<EnrolleeModel> input);
    }
}