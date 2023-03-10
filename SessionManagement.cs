using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewData["key1"] = "abc";
            ViewData["key2"] = 10;
            ViewBag.key3 = true;

            TempData["key4"] = "abc";

            Session["name"] = "Vikram";
            Session["id"] = 10;


            //return RedirectToAction("Index2");
            return View();
        }
        public ActionResult Index2()
        {
            string s;
            s = Session["name"].ToString();
            int id;
            id = (int)Session["id"];

            return View();
        }

        public ActionResult Index3()
        {
            string s;
            s = Session["name"].ToString();
            int id;
            id = (int)Session["id"];
            Session.Abandon();
            return View();
        }
    }
}

***************
**index1**

@{
    ViewBag.Title = "Index";
}

<h2>Index</h2>

key1 @ViewData["key1"].ToString()
<br />
@{
    int i = (int)ViewData["key2"];
    bool b = ViewBag.key3;
}
key2 @i
<br />

key3 @b
<br />
key4 @TempData["key4"].ToString()

****index2******

@{
    ViewBag.Title = "Index2";
}

<h2>Index2</h2>
@{
    //int i = (int)ViewData["key2"];
    //ViewData and ViewBag from Index are not available here
}
@*key4 @TempData["key4"].ToString()*@

********index3*********

@{
    ViewBag.Title = "Index3";
}

<h2>Index3</h2>


*************************************HtmlHelp*********************************
using HtmlHelpersExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelpersExample.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int EmpNo=1)
        {
            Employee o = new Employee();
            o.EmpNo = 1;
            o.Name = "Vik";
            o.Basic = 12345;
            o.DeptNo = 20;

            List<SelectListItem> objDepts = new List<SelectListItem>
            {
                new SelectListItem{Text= "SALES", Value= "10"},
                new SelectListItem{Text= "IT", Value= "20"},
                new SelectListItem{Text= "HR", Value= "30"},
            };
            //List<SelectListItem> objDepts = Department.GetDepts();

            o.Departments = objDepts;
            ViewBag.Departments = objDepts;

//@Html.DropDownListFor(model => model.DeptNo, Model.Departments)
//@Html.DropDownListFor(model => model.DeptNo, (IEnumerable<SelectListItem>)ViewBag.Departments)



            return View(o);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int EmpNo=1)
        {

            Employee o = new Employee();
            o.EmpNo = 1;
            o.Name = "Vik";
            o.Basic = 12345;
            o.DeptNo = 20;

            List<SelectListItem> objDepts = new List<SelectListItem>
            {
                new SelectListItem{Text= "SALES", Value= "10"},
                new SelectListItem{Text= "IT", Value= "20"},
                new SelectListItem{Text= "HR", Value= "30"},
            };
            //List<SelectListItem> objDepts2 = Department.GetDepts();
            o.Departments = objDepts;
            ViewBag.Departments = objDepts;
            return View(o);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int EmpNo, Employee objEmp)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

**********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelpersExample.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        
    }

}
************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlHelpersExample.Models
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
}

***********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HtmlHelpersExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EmpRoute",
                url: "{controller}/{action}/{EmpNo}",
                defaults: new { controller = "Employees", action = "Details", EmpNo = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}

**************
@model HtmlHelpersExample.Models.Employee

@{
    ViewBag.Title = "Details";
}

<h2>Details</h2>

@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()
    
<div class="form-horizontal">
    <h4>Employee</h4>
    <hr />
    ActionLink @Html.ActionLink("Go to Edit", "Edit")<br /><br />

    TextBox @Html.TextBox("txtBasic", "value")<br />

    <input type="text" name="txtBasic" value="value" />
    @*<input type="text" name="Basic" value=@Model.Basic />*@
    TextBoxFor @Html.TextBoxFor(model => model.Basic) <br /><br />

    CheckBox @Html.CheckBox("chk1")<br />
    CheckBoxFor @Html.CheckBoxFor(model => model.IsActive)<br /><br />


    @Html.RadioButton("btn1", "Yes") Yes<br />
    @Html.RadioButton("btn1", "No") No<br />
    @Html.RadioButton("btn1", "Maybe") Maybe<br /><br />

    @foreach (var item in Model.Departments)
    {
        @Html.RadioButtonFor(model => model.DeptNo, item.Value)
        @item.Text
        <br />
    }
    <br />

    DropDownList @Html.DropDownList("ddlDeptNo", Model.Departments)
    <br />


    DropDownListFor @Html.DropDownListFor(model => model.DeptNo, Model.Departments)
    <br />
    DropDownListFor @Html.DropDownListFor(model => model.DeptNo, (IEnumerable<SelectListItem>)ViewBag.Departments)

    <br />

    @Html.Password("txtPassword")<br />
    @Html.PasswordFor(model => model.Name)

    <br />
    @Html.TextAreaFor(model => model.Name)
    <br />


    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Save" class="btn btn-default" />
        </div>
    </div>
</div>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>


*********
@model HtmlHelpersExample.Models.Employee

@{
    ViewBag.Title = "Edit";
}

<h2>Edit</h2>

@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>Employee</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.EmpNo, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.EmpNo, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.EmpNo, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Basic, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Basic, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Basic, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.DeptNo, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(model => model.DeptNo, (IEnumerable<SelectListItem>)ViewBag.Departments, new { @class = "form-control" })
                @*@Html.DropDownListFor(model => model.DeptNo, Model.Departments, new { @class = "form-control" })*@
                @Html.ValidationMessageFor(model => model.DeptNo, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

*****************************