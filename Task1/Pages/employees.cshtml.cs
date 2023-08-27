using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Task1.Pages
{
    public class Index1Model : PageModel
    {
        //create a list of employee
        public List<employeesInfo> employeesList = new List<employeesInfo>();
        public void OnGet()
            //here the code will execute
            //read data from database and list it
        {
            try
            {
                String connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=tasks;Integrated Security=True";
                //create connection with database:
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    //create query
                    connection.Open();
                    String sql = "select * from employees";
                    //create sql command:
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //create sql reader using while loop
                        using (SqlDataReader reader = command.ExecuteReader()) { 
                        while (reader.Read())
                        {
                                //create opject of employee:
                                employeesInfo employeesInfo1 = new employeesInfo();
                                employeesInfo1.employeeID = reader.GetInt32(0);
                                employeesInfo1.name = reader.GetString(1);
                                employeesInfo1.address = reader.GetString(2);
                                employeesInfo1.position = reader.GetString(3);
                                employeesInfo1.birthDate = reader.GetString(4);
                                employeesInfo1.hireDate = reader.GetString(5);

                                employeesList.Add(employeesInfo1);

                            }
                        }
                    }

                }
         

            }
            catch (Exception ex)
            {

            }


        }
     
      
        public class employeesInfo
        {
            public int employeeID;
            public string name;
            public string address;
            public string position;
            public string birthDate;
            public string hireDate;

        }
    }
}
