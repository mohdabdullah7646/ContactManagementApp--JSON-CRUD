using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace crud_dotnet_api.Data
{
    public class EmployeeRepository
    {
        private readonly string _jsonFilePath;

        public EmployeeRepository(IWebHostEnvironment webHostEnvironment)
        {
            _jsonFilePath = Path.Combine(webHostEnvironment.WebRootPath, "employees.json");
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            if (!File.Exists(_jsonFilePath))
            {
                return new List<Employee>();
            }

            var json = await File.ReadAllTextAsync(_jsonFilePath);
            return JsonSerializer.Deserialize<List<Employee>>(json);
        }
        
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employees = await GetAllEmployeesAsync();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            var employees = await GetAllEmployeesAsync();
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            await SaveEmployeesAsync(employees);
        }

        public async Task UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            var employees = await GetAllEmployeesAsync();
            var employeeIndex = employees.FindIndex(e => e.Id == id);
            if (employeeIndex == -1)
            {
                throw new Exception("Employee not found");
            }
            updatedEmployee.Id = id;
            employees[employeeIndex] = updatedEmployee;
            await SaveEmployeesAsync(employees);
        }

        private async Task SaveEmployeesAsync(List<Employee> employees)
        {
            var json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });

            try
            {
                await File.WriteAllTextAsync(_jsonFilePath, json);
                Console.WriteLine("Employees saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving employees: {ex.Message}");
                throw;
            }
        }
        
        public async Task DeleteEmployeeAsync(int id)
        {
            var employees = await GetAllEmployeesAsync();
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            employees.Remove(employee);
            await SaveEmployeesAsync(employees);
        }
    }
}
