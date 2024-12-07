using System.Data;
using CRUDWithADONet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CRUDWithADONet.DAL
{
    public class Employee_DAL
    {
        private SqlConnection _connection = null;
        private SqlCommand _command = null;

        public static IConfiguration? Configuration { get; set; } 

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
        }
        // List in table
        public List<Employee> GetAll()
        {
            List<Employee> employeeList = new List<Employee>();

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[ups_Get_Employees]";

                _connection.Open();

                using (SqlDataReader dr = _command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employee employee = new Employee
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstName = dr["FirstName"]?.ToString() ?? string.Empty,
                            LastName = dr["LastName"]?.ToString() ?? string.Empty,
                            DateOfBirth = dr["DateOfBirth"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["DateOfBirth"]),
                            Email = dr["Email"]?.ToString() ?? string.Empty, 
                            Salary = dr["Salary"] == DBNull.Value ? 0.0 : Convert.ToDouble(dr["Salary"])
                        };
                        employeeList.Add(employee);
                    }
                }
                _connection.Close();
            }
            return employeeList;
        }
        // Insert method
        public bool Insert(Employee model)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[ups_Insert_Employee]";
                _command.Parameters.AddWithValue("@FirstName", model.FirstName);
                _command.Parameters.AddWithValue("@LastName", model.LastName);
                _command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                _command.Parameters.AddWithValue("@Email", model.Email);
                _command.Parameters.AddWithValue("@Salary", model.Salary);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return id > 0 ? true : false;
        }

        // Get by ID
        public Employee GetById(int id)
        {
            Employee employee = new Employee();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[ups_Get_EmployeeById]";
                _command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                using (SqlDataReader dr = _command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                            employee.Id = Convert.ToInt32(dr["Id"]);
                            employee.FirstName = dr["FirstName"]?.ToString() ?? string.Empty;
                            employee.LastName = dr["LastName"]?.ToString() ?? string.Empty;
                            employee.DateOfBirth = dr["DateOfBirth"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["DateOfBirth"]);
                            employee.Email = dr["Email"]?.ToString() ?? string.Empty;
                            employee.Salary = dr["Salary"] == DBNull.Value ? 0.0 : Convert.ToDouble(dr["Salary"]);
                    };
                }
                _connection.Close();
            }
            return employee;
        }

        // Update method
        public bool Update(Employee model)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[ups_Update_Employee]";
                _command.Parameters.AddWithValue("@Id", model.Id);
                _command.Parameters.AddWithValue("@FirstName", model.FirstName);
                _command.Parameters.AddWithValue("@LastName", model.LastName);
                _command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                _command.Parameters.AddWithValue("@Email", model.Email);
                _command.Parameters.AddWithValue("@Salary", model.Salary);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return id > 0 ? true : false;
        }

        // Delete method
        public bool Delete(int id)
        {
            int deletedRowCount = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[ups_Delete_Employee]";
                _command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                deletedRowCount = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return id > 0 ? true : false;
        }
    }
}
