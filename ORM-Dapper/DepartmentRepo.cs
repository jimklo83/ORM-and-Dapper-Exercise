using Dapper;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DepartmentRepo : IDepartmentRepo
    {
        public DepartmentRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        private readonly IDbConnection _connection;
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments");
        }

        public void InsertDepartment(string department)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@department);",
            new { department });
        }
    }
}
