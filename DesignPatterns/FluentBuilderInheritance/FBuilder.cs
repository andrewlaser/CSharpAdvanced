using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public class Employee
    {
        public string Name;
        public string Position;
        public DateTime DateOfBirth;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(DateOfBirth)}: {DateOfBirth}";
        }
    }

    public abstract class EmployeeBuilder
    {
        protected Employee Employee;

        public EmployeeBuilder()
        {
            Employee = new Employee();
        }

        public Employee Build() => Employee;
    }


    public class EmployeeInfoBuilder<T>: EmployeeBuilder where T: EmployeeInfoBuilder<T>
    {
        public T SetName(string name)
        {
            Employee.Name = name;
            return (T) this;
        }
    }

    public class EmployeePositionBuilder<T> : EmployeeInfoBuilder<EmployeePositionBuilder<T>>
        where T : EmployeePositionBuilder<T>
    {
        public T WorksAs(string position)
        {
            Employee.Position = position;
            return (T) this;
        }
    }



   


    public class EmployeeBuilderDirector : EmployeePositionBuilder<EmployeeBuilderDirector>
    {
        public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
    }

    class FBuilder
    {
        //static void Main(string[] args)
        //{
        //    var employee = EmployeeBuilderDirector.NewEmployee.SetName("Name").WorksAs("position")
        //        .Build();
        //    Console.WriteLine(employee.ToString());
        //    Console.ReadKey();

        //}
    }
}
