using ExercicioLambda.Entities;
using System.Globalization;

Console.Write("Enter full path: ");
string path = @Console.ReadLine()!;
Console.Write("Enter salary: ");
double limit = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

List<Employee> employees = new List<Employee>();

try
{
    using (StreamReader sr = File.OpenText(path))
    {
        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine()!.Split(',');
            string name = line[0];
            string email = line[1];
            double salary = double.Parse(line[2], CultureInfo.InvariantCulture);

            employees.Add(new Employee(name, email, salary));
        }

        var emails = employees.Where(p => p.Salary > limit).OrderBy(p => p.Name).Select(p => p.Email);
        
        double sumSalary = employees.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
        
        Console.WriteLine("Email of people whose salary is more than " + limit.ToString("F2", CultureInfo.InvariantCulture) + ":");
        foreach (string email in emails)
        {
            Console.WriteLine(email);
        }


        Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sumSalary.ToString("F2", CultureInfo.InvariantCulture));


    }
}
catch (IOException e)
{
    Console.WriteLine("An error ocurred");
    Console.WriteLine(e.Message);
}