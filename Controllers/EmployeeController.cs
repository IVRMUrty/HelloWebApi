using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace HelloWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private static IList<Employee> list = new List<Employee>()
 {
 new Employee()
 {
 Id = 12345, FirstName = "John", LastName = "Human", Department = 2
 },

 new Employee()
 {
 Id = 12346, FirstName = "Jane", LastName = "Public", Department = 3
 },
 new Employee()
 {
 Id = 12347, FirstName = "Joseph", LastName = "Law", Department = 2
 }
 };

        // GET api/employees
        public IEnumerable<Employee> Get()
        {
            return list;
        }

        // GET api/employees/12345
        public Employee Get(int id)
        {
            return list.First(e => e.Id == id);
        }

        public HttpResponseMessage Post(int id, Employee employee)
        {
            int index = list.ToList().FindIndex(e => e.Id == id);

            if (index >= 0)
            {
                list[index] = employee;
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public void Delete(int id)
        {
            Employee employee = Get(id);
            list.Remove(employee);
        }

    }
}
