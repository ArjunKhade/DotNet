using ModelBindingWithDbCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindingWithDbCode.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> emps = Employee.GetAllEmployees();
            return View(emps);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            try
            {
                // TODO: Add insert logic here
                Employee.InsertEmployee(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                // TODO: Add update logic here
                Employee.UpdateEmployee(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Employee.DeleteEmployee(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

***************************************

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ModelBindingWithDbCode.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmps = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from employees ";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    lstEmps.Add(new Employee { EmpNo = dr.GetInt32(0), Name = dr.GetString(1), Basic = dr.GetDecimal(2), DeptNo = dr.GetInt32(3) });
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lstEmps;
        }
        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee obj = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from employees where empno=@EmpNo";
                cmdInsert.Parameters.AddWithValue("@EmpNo", EmpNo);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    obj.EmpNo = dr.GetInt32(0);
                    obj.Name = dr.GetString(1);
                    obj.Basic = dr.GetDecimal(2);
                    obj.DeptNo = dr.GetInt32(3);



                }
                else
                {
                    obj = null;
                    //Console.WriteLine("Not present");
                    //record not persent
                }
                dr.Close();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            //read from db for EmpNo = 1 and populate obj
            return obj;
        }
        public static void InsertEmployee(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";



                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }
        public static void UpdateEmployee(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update employees set name=@Name, basic=@Basic, deptno=@Deptno where empno =@EmpNo";




                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }
        public static void DeleteEmployee(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from employees where empno =@EmpNo";




                cmdInsert.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmdInsert.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }
    }
}

*****************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotations.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employee Number")]
        public int EmpNo{ get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }

        [Range(1000, 500000, ErrorMessage = "Please enter values between 1000-500000")]
        [MaxLength(6), MinLength(4)]
        [Display(Name = "Basic Salary")]
        [DataType(DataType.Currency)]
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        [ScaffoldColumn(false)]
        public string Dummy { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password should be the same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        // Allow up to 40 uppercase and lowercase 
        // characters. Use custom error.
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
             ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        // Allow up to 40 uppercase and lowercase 
        // characters. Use standard error.
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string LastName { get; set; }
    }
}
//https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.8