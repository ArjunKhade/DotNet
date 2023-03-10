using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseCode
{
    class Program
    {
        static void Main()
        {
            //Connect();
            //Insert();

            Employee obj = new Employee {EmpNo =6, Name="D'Silva", Basic=12345, DeptNo=30 };
            //Insert(obj);
            //InsertWithParameters(obj);
            //InsertWithStoredProcedure(obj);

            //TO DO ---- create stored proc for update and delete and call it from code

            Console.ReadLine();
        }
        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                //cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;User Id=sa;Password=sa";

                cn.Open();
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void Insert()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(3,'Ashwin', 12345, 20)";
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}', {obj.Basic}, {obj.DeptNo})";
                Console.WriteLine(cmdInsert.CommandText);
                Console.ReadLine();
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void InsertWithParameters(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void InsertWithStoredProcedure(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployee";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name{ get; set; }
        public decimal Basic{ get; set; }
        public int DeptNo { get; set; }

    }
}


**********************************
CREATE TABLE [dbo].Departments
(
	[DeptNo] INT NOT NULL PRIMARY KEY, 
    [DeptName] VARCHAR(50) NOT NULL
)

***********************************

CREATE TABLE [dbo].Employees
(
	[EmpNo] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Basic] DECIMAL(18, 2) NOT NULL, 
    [DeptNo] INT NOT NULL, 
    CONSTRAINT [FK_Employees_Departments] FOREIGN KEY (DeptNo) REFERENCES Departments(DeptNo)
)

************************************

CREATE PROCEDURE [dbo].InsertEmployee
	@EmpNo int,
	@Name varchar(50),
	@Basic decimal(18,2),
	@DeptNo int 
AS
	insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)

RETURN 0

*******************************************************************************************
CREATE PROCEDURE [dbo].deleteEmployee
	@EmpNo int
AS
	delete from Employees where EmpNo = @EmpNo; 
RETURN 0

*********************************************Day10*********************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCode
{
    class Program
    {
        static void Main()
        {
            //Connect();
            //Insert();

            Employee obj = new Employee { EmpNo = 6, Name = "D'Silva", Basic = 12345, DeptNo = 30 };
            //Insert(obj);
            //InsertWithParameters(obj);
            //InsertWithStoredProcedure(obj);
          //  Transactions();


            //TO DO ---- create stored proc for update and delete and call it from code
            //QueryReturningSingleValue();

            //SqlDataReader examples
         //  QueryReturningSingleRecord(1); //found
           // QueryReturningSingleRecord(100); //not found
           // QueryReturningMultipleRecords();
            //QueryReturningMultipleResults();
            MARS();
          //  CallFuncReturningSqlDataReader();
            Console.ReadLine();
        }
        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                //cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;User Id=sa;Password=sa";

                cn.Open();
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void Insert()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(3,'Ashwin', 12345, 20)";
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}', {obj.Basic}, {obj.DeptNo})";
                Console.WriteLine(cmdInsert.CommandText);
                Console.ReadLine();
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void InsertWithParameters(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void InsertWithStoredProcedure(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployee";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void Transactions()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.Transaction = t;


            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(11, 'Rahul', 12345, 30)";


            SqlCommand cmdInsert2 = new SqlCommand();
            cmdInsert2.Connection = cn;
            cmdInsert2.Transaction = t;

            cmdInsert2.CommandType = System.Data.CommandType.Text;
            cmdInsert2.CommandText = "insert into Employees values(12, 'Tripati', 12345, 30)";
            try
            {
                cmdInsert.ExecuteNonQuery();
                cmdInsert2.ExecuteNonQuery();
                t.Commit();
                Console.WriteLine("no errors- commit");
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine("Rollback");
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }

        static void QueryReturningSingleValue()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select count(*) from Employees";

                //will only return first row, first column
                //cmdSelect.CommandText = "Select * from Employees";

                object retval = cmdSelect.ExecuteScalar();

                Console.WriteLine(retval);

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        static void QueryReturningSingleRecord(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees where EmpNo=@EmpNo";
                cmdSelect.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (dr.Read())
                {
                    Console.WriteLine(dr["EmpNo"]);
                }
                else
                    Console.WriteLine("no record found");
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        static void QueryReturningMultipleRecords()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees";

                SqlDataReader dr = cmdSelect.ExecuteReader();
                while(dr.Read())
                {
                    //Console.WriteLine(dr[0]);
                    Console.WriteLine(dr["EmpNo"]);
                    //Console.WriteLine(dr.GetInt32(0));
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        static void QueryReturningMultipleResults()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees;select * from Departments";

                SqlDataReader dr = cmdSelect.ExecuteReader();
                while (dr.Read())
                {
                    //Console.WriteLine(dr[0]);
                    Console.WriteLine(dr["Name"]);
                    //Console.WriteLine(dr.GetInt32(0));
                }
                
                dr.NextResult();
                while(dr.Read())
                {
                    Console.WriteLine(dr["DeptName"]);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        static void MARS()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=ActsJuly22;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                Console.WriteLine((drDepts["DeptName"]));

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    Console.WriteLine(("    " + drEmps["Name"]));
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }

        static void CallFuncReturningSqlDataReader()
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[1]);
            }
            dr.Close();
            Console.WriteLine();
            //Console.WriteLine(cn.State);
            Console.ReadLine();
        }
        //static SqlConnection cn = new SqlConnection();

        static SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Employees ";
            //SqlDataReader dr = cmdInsert.ExecuteReader();
            SqlDataReader dr = cmdInsert.ExecuteReader(CommandBehavior.CloseConnection);
            //cn.Close();
            return dr;
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
}



****************************DataSet*******************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetExample
{
    public partial class Form1 : Form
    {
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";

            cn.Open();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = cn;
            cmdSelect.CommandType = CommandType.Text;
            cmdSelect.CommandText = "Select * from Employees";

            SqlDataAdapter da = new SqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = cmdSelect;

            da.Fill(ds, "Emps");
 
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            cmdSelect.CommandText = "Select * from Departments";

            da.Fill(ds, "Deps");
            //MessageBox.Show(cn.State.ToString());

            //constraints
            //primary key constraint

            DataColumn[] arrCols = new DataColumn[1];
            arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
            ds.Tables["Emps"].PrimaryKey = arrCols;

            //foreign key
            ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"],
                ds.Tables["Emps"].Columns["DeptNo"]);

            //column level constraints
            ds.Tables["Deps"].Columns["DeptName"].Unique = true;

            dataGridView1.DataSource = ds.Tables["Emps"];
            //dataGridView1.DataSource = ds.Tables["Deps"];
            //dataGridView1.DataSource = ds.Tables[0];

            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly22;Integrated Security=True";

            cn.Open();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "Update Employees set Name=@Name,Basic=@Basic,DeptNo=@DeptNo where EmpNo=@EmpNo";

            //below is used when running query only once
            //cmdUpdate.Parameters.AddWithValue("@Name", objEmp.Name);


            //for da.Update use....
            //SqlParameter p = new SqlParameter();
            //p.ParameterName = "@Name";
            //p.SourceColumn = "Name";
            //p.SourceVersion = DataRowVersion.Current;
            //cmdUpdate.Parameters.Add(p);
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            //similarly add code for Insert
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


            //similarly add code for Delete
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;

            da.Update(ds, "Emps");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.WriteXmlSchema("Emps.xsd");
            ds.WriteXml("Emps.xml", XmlWriteMode.DiffGram);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXmlSchema("Emps.xsd");
            ds.ReadXml("Emps.xml", XmlReadMode.DiffGram);
            dataGridView1.DataSource = ds.Tables["Emps"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DataView dv = new DataView(ds.Tables["Emps"]);
            ////dv.Sort = "Name";
            ////dv.Sort = "Name desc";
            ////dv.Sort = "DeptNo,Name";
            //dv.RowFilter = $"DeptNo={textBox1.Text}";
            //dataGridView1.DataSource = dv;
            ds.Tables["Emps"].DefaultView.RowFilter = $"DeptNo={textBox1.Text}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ds.Tables["Emps"].DefaultView.RowFilter = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

