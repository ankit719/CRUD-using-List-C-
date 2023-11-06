namespace crud_list_Demo
{
    public enum Dept { MKT,ADV,HR}
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Gender {  get; set; }
        public string Address { get; set; }

        public Dept Dept { get; set; }

    }
    interface IEmployeeRepositry
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int Id);

    }
    public class EmployeeDemo : IEmployeeRepositry
    {
        private static List<Employee> employees;
        public EmployeeDemo()
        {
            employees = new List<Employee> { new Employee() { Id=1,Name="Ankit",Salary=10000,Gender="Male",Address="pqr",Dept=Dept.MKT},
                new Employee() { Id=2,Name="atul",Salary=20000,Gender="Male",Address="dsr",Dept=Dept.HR},
                new Employee() { Id=3,Name="raj",Salary=30000,Gender="Male",Address="pqr",Dept=Dept.MKT},
                new Employee() { Id=4,Name="mayur",Salary=30000,Gender="Male",Address="lmr",Dept=Dept.ADV},
                new Employee() { Id=5,Name="divanshu",Salary=40000,Gender="Male",Address="nor",Dept=Dept.HR }

            };

        }
        public Employee Add(Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return emp;
            throw new NotImplementedException();
        }

        public Employee Delete(int Id)
        {
            Employee emp=employees.FirstOrDefault(e=> e.Id==Id);
            if (emp != null)
            {
                employees.Remove(emp);
            }
            return emp;
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
            throw new NotImplementedException();
        }

        public Employee Update(Employee emp)
        {
            Employee tmp=employees.FirstOrDefault(e=>e.Id==emp.Id);
            if(tmp != null)
            {
                tmp.Name = emp.Name;
                tmp.Salary = emp.Salary;
                tmp.Gender = emp.Gender;
                tmp.Address = emp.Address;
                tmp.Dept = emp.Dept;
            }
            return emp;
            throw new NotImplementedException();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeDemo obj=new EmployeeDemo();
            Display(obj);
            Employee tmp=new Employee() {Id=2,Name="raj2",Salary=4000,Dept=Dept.ADV,Gender="Male",Address="lmc"};
           // obj.Add(tmp);
           // Display(obj);
           // obj.Delete(2);
           // Display(obj);
           // Console.WriteLine(obj.GetEmployee(2).Name);
           obj.Update(tmp);
            Display(obj);



        }
        static void Display(EmployeeDemo obj)
        {
            foreach(Employee emp in obj.GetEmployees())
            {
                Console.WriteLine(emp.Id+" " + emp.Name + " " + emp.Gender + " " + emp.Address + " " + emp.Dept + " " + emp.Salary);
                    
            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}