// See https://aka.ms/new-console-template for more information

using EmpLib;

Person Bhavana = new Person();
Bhavana.Name = "Bhavana";
Console.WriteLine(Bhavana.Eat());

Person person = new Person();
person.Name = "person";
Console.WriteLine(person.Eat());

//1st technique
/*Person kiran = new Employee();
kiran.Name = "kiran";
((Employee)kiran).Designation = "Analyst";*/
// base = new derived();
// person p = new employee()
// employeeContract p = new employee()

//2nd technique
Person kiran = new Employee() {  Designation = "Intern", DOJ = DateTime.Now.AddMonths(-1) };
kiran.Name = "kiran";
((Employee)kiran).Designation = "Analyst";
Console.WriteLine(kiran.work());
Console.WriteLine(((Employee)kiran).AttendTraining("C2C"));

EmployeeContract sophiarobo = new Employee();

Father SharmajiFather = new Father();
Console.WriteLine($"Sharmaji's Father : {SharmajiFather.settle()}");
Console.WriteLine($"Sharmaji's Father gets married:{SharmajiFather.getmarried()}"); 
Console.WriteLine($"Sharmaji's father's concept of drawing (Using abstract): {SharmajiFather.Drawing()}");
Console.WriteLine($"Sharmaji's father's concept of drawing (Using abstract): {SharmajiFather.WhatIsDating()}");

Father Sharmaji = new Child();
Console.WriteLine($"Sharmaji:{Sharmaji.settle()}");
Console.WriteLine($"sharmaji gets married: {Sharmaji.getmarried()}");
Console.WriteLine($"Sharmaji's concept of drawing (using abstract): {Sharmaji.Drawing()}");
Console.WriteLine($"Sharmaji's concept of drawing (using abstract): {Sharmaji.WhatIsDating()}");

//no virtual, modification disallowed by base class,forced modify using "new" keyword.forced execution of derived class using
//typecasting((child)sharmajiV2).getmarried()
Father SharmajiV2 = new Child();
Console.WriteLine($"Sharmaji V2 gets married: {((Child)SharmajiV2).getmarried()}");


//See Overloading-Compile-time polymorphism below
Employee Vidyasagar = new Employee();
Vidyasagar.Name = "Vidyasagar";
Vidyasagar.Designation = "Security Systems Analyst";
Console.WriteLine(Vidyasagar.work());
Console.WriteLine(Vidyasagar.work("Solving bugs"));

//Exposing non-public information through public methods
Employee Srikar = new Employee();
Srikar.SetTaxInfo("I'm eligible in the 20% tax payer category");
Console.WriteLine(Srikar.GetTaxinfo());

//test calling one constructor from another
Person keerthi = new Person("178965748765","+918713574394");
//this constructor should call the constructor that seta aadhar number
Console.WriteLine($"Aadhar :{keerthi.Aadhar} | Mobile Number : { keerthi.MobileNumber}");

Console.WriteLine($"total employee count:{EmpUtils.EmpCount}");

//adding employee to temporary DB = using static List<Employee>
EmpUtils.EmpDb.Add(Srikar);
EmpUtils.EmpDb.Add(Vidyasagar);
EmpUtils.EmpDb.Add(new Employee("758493650747", "918764562879"){Name ="Bhavana", Designation="Analyst",Salary=87645});
EmpUtils.EmpDb.Add(new Employee("718768448339", "9187648467879") { Name = "Brinda", Designation = "Analyst", Salary = 87960 });
EmpUtils.EmpDb.Add(new Employee("758648300747", "9187675832879") { Name = "abs", Designation = "Analyst", Salary = 70000 });

//get all Employees whose addhar card start with 75

var resultlist=EmpUtils.EmpDb.Where((emp) => emp.Aadhar !=null && emp.Aadhar.StartsWith("75"));
resultlist.ToList().ForEach((emp) => Console.WriteLine($"{emp.Name} | {emp.Aadhar}"));


//get all employee whose salary >80k
var res = EmpUtils.EmpDb.Where((emp) => emp.Salary > 80000);
res.ToList().ForEach((emp) => Console.WriteLine($"{emp.Name} | {emp.Aadhar} | {emp.Salary} "));
