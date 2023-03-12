using Microsoft.EntityFrameworkCore;
using Test1.Context;
using Test1.DTO;
using Test1.Model;
using Test1.Services;

namespace Test1.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationContext _context;
        public EmployeeRepo(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        public async Task<bool> AddEmployee(EmployeeDto employee)
        {
            var NewEmployee = new Employee()
            {
                EmployeeId = Guid.NewGuid().ToString(),
                Address = employee.Address,
                Age = employee.Age,
                Name = employee.Name
            };

            var data = _context.Add(NewEmployee);
            await _context.SaveChangesAsync();

            return data != null;
        }

        public async Task<bool> Delete(string Id)
        {
            var employee = await _context.employee.FindAsync(Id);
            if (employee == null) return false;

            _context.employee.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmployeeID>> GetAll()
        {

            return await _context.employee.Select(x =>
            new EmployeeID()
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                Address = x.Address,
                Age = x.Age
            }).ToListAsync();
        }

        public async Task<EmployeeID> GetEmployee(string id)
        {
            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return null;
            }

            return new EmployeeID()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Address = employee.Address,
                Age= employee.Age
            };
        }

        public async Task<bool> Update(EmployeeID employee)
        {
            var record = await _context.employee.FindAsync(employee.EmployeeId);

            if (record == null) return false;

            record.Name = employee.Name;
            record.Address = employee.Address;
            record.Age = employee.Age;
            

            _context.Update(record);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
