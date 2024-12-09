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

        // DBConnection
        private string GetConnectionString()
        {
            string connectionString = string.Empty;

            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                Configuration = builder.Build();
                connectionString = Configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Connection string not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the connection string: " + ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("GetConnectionString execution completed.");
            }

            return connectionString;
        }

        // List in table
        public List<Employee> GetAll()
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the employee list: " + ex.Message);
                throw;
            }
            return employeeList;
        }

        // Insert method
        public void Insert(Employee model)
        {
            try
            {
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
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting the employee: " + ex.Message);
                throw;
            }
        }

        // Get by ID
        public Employee GetById(int id)
        {
            Employee employee = new Employee();
            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting the employee: " + ex.Message);
                throw;
            }
            return employee;
        }

        // Update method
        public void Update(Employee model)
        {
            try
            {
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
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the employee: " + ex.Message);
                throw;
            }
        }


        // Delete method
        public void Delete(int id)
        {
            try
            {
                using (_connection = new SqlConnection(GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.CommandText = "[DBO].[ups_Delete_Employee]";
                    _command.Parameters.AddWithValue("@Id", id);

                    _connection.Open();
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the employee: " + ex.Message);
                throw;
            }
        }

        // INSERT AND UPDATE method
        public void CreateOrUpdate(Employee model)
        {
            try
            {
                using (_connection = new SqlConnection(GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.CommandText = "[DBO].[usp_InsertOrUpdateEmployee]";
                    _command.Parameters.AddWithValue("@Id", model.Id);
                    _command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    _command.Parameters.AddWithValue("@LastName", model.LastName);
                    _command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                    _command.Parameters.AddWithValue("@Email", model.Email);
                    _command.Parameters.AddWithValue("@Salary", model.Salary);

                    _connection.Open();
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating or updating the employee: " + ex.Message);
                throw;
            }
        }

    }
}
