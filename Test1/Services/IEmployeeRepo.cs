using Test1.DTO;
using Test1.Model;

namespace Test1.Services
{
    public interface IEmployeeRepo
    {
        Task<bool> AddEmployee(EmployeeDto employee);
        Task<EmployeeID> GetEmployee(string id);
        Task<List<EmployeeID>> GetAll();
        Task<bool> Update(EmployeeID employee);
        Task<bool> Delete(string Id);
    }
}
