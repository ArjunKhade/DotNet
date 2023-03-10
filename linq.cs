          //  var returnvalue = from single_object in collection select something
          //   IEnumerable<Employee> emps = from emp in lstEmp select emp;

            var emps = from emp in lstEmp select emp;
            var emps = from emp in lstEmp select emp.EmpNo;
            var emps = from e in lstEmp select e.Name;
            var emps = from emp in lstEmp select new { emp.Name, emp.EmpNo };
			
            var emps = from emp in lstEmp
                       where emp.Basic > 10000
                       select emp;

            var emps = from emp in lstEmp
                       where emp.Basic > 10000 && emp.Basic < 120000
                       select emp;

            var emps = from emp in lstEmp
                       where emp.Name.StartsWith("V")
                       select emp;

            var emps = from emp in lstEmp
                       orderby emp.Name
                       select emp;

            var emps = from emp in lstEmp
                       orderby emp.Name descending
                       select emp;

            var emps = from emp in lstEmp
                       orderby emp.DeptNo, emp.Name descending
                       select emp;

             var emps = from emp in lstEmp
                        join dept in lstDept
                        on emp.DeptNo equals dept.DeptNo
                        select emp;

             var emps = from emp in lstEmp
                        join dept in lstDept
                        on emp.DeptNo equals dept.DeptNo
                        select dept;

            var emps = from emp in lstEmp
                       join dept in lstDept
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp, dept };

            var emps = from emp in lstEmp
                       join dept in lstDept
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp.Name, dept.DeptName };

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo;

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select group1;

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select new { group1, Count = group1.Count(), Max = group1.Max(x => x.Basic), Min = group1.Min(x => x.Basic) };

            ----------------------------------------------------------------------


             var emps = lstEmp.Select(emp => emp);
            var emps = lstEmp.Select(emp => emp.Name);
            var emps = lstEmp.Select(emp => new { emp.EmpNo, emp.Name });

            var emps = lstEmp.Where(emp => emp.Basic > 10000);
            var emps = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp);
            var emps = lstEmp.Select(emp => emp).Where(emp => emp.Basic > 10000);

            var emps = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp.Name);
            var emps = lstEmp.OrderBy(emp => emp.Name);
            var emps = lstEmp.OrderByDescending(emp => emp.Name);
            var emps = lstEmp.OrderBy(emp => emp.DeptNo).ThenByDescending(emp => emp.Name);

            join

            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp);

            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept);
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp.DeptNo);
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept.DeptNo);
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp, dept });
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp.Name, dept.DeptName });



            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }
            Console.ReadLine();

            --------------------------------------------------
            Employee emp = lstEmp.Single(e => e.EmpNo == 1); //one record = okay
            Employee emp = lstEmp.Single(e => e.EmpNo == 10);  //no records = error
            Employee emp = lstEmp.Single(e => e.Basic > 5000); //multiple records - error
            Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 1); //one record = okay
            Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 10); //no records=null
            Employee emp = lstEmp.SingleOrDefault(e => e.Basic > 5000);//multiple records - error

            ---------------------------------------------------------