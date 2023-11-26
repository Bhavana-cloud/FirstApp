using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpLib
{

    public class Employee : Person, EmployeeContract
    {
        public event EventHandler Join;
        public event EventHandler Resign;
        //ctor tab twice to create constructor
        //call base class constructor
        public Employee() : base()
        {
            this.ViewContract();
            this.Sign();
            this.EmpId = new Random(1000).Next();
            EmpUtils.EmpCount++;
        }
        public void TriggerJoinEvent()
        {
            this.Join.Invoke(this, null);
        }
        public void TriggerResignEvent()
        {
            this.Resign.Invoke(this, null);
        }
        //call current class's other constructor
        public Employee(string pAadhar) : this()
        {
            this.Aadhar = pAadhar;  
        }
        // in program.cs Employee you = new Employee{"aadhar number","+917865489375")
        public Employee(string pAadhar,string pMobile):base(pAadhar,pMobile)
        {
            this.ViewContract();
            this.Sign();
            this.EmpId = new Random(1000).Next();
        }
        //Variables inside a class are cknown as FILEDS and for private variables we use underscore indicating that it is private
        private bool _contractSigned = false;
        private bool _hasreadContract = false;
        public void Sign()
        {
            _contractSigned = true;
        }

        public void ViewContract()
        {
            _hasreadContract = true;
        }
        private int _empId;
        public int EmpId {
            get { return _empId; }
            private set { _empId = value; }
        }
        public string Designation { get; set; }
        public double Salary { get; set; }
        public DateTime DOJ { get; set; }
        public bool IsActive { get; set; }
        public string AttendTraining(string pTraining)
        {
            return $"{this.Name} attended a training {pTraining}";
        }
        public void FillTimesheet(List<string> pTasks)
        {
            var csvTasks = "";
            foreach (var task in pTasks)
            {
                csvTasks = $"{csvTasks},{task} on {DateTime.Now.ToShortDateString()}";
            }
        }
        public override string work()
        {
            return $"{this.Name} with {this.EmpId} works for 8hrs a day at KPMG";
        }
        public string work(string task)
        {
            return $"{this.Name} with {this.EmpId} has {task} assigned on {DateTime.Today}";
        }
        public void SetTaxInfo(string pTaxInfo)
        {
            this.TaxDetails = pTaxInfo;
        }

        public string GetTaxinfo()
        {
            return $"{this.Name}: Your tax details are:{this.TaxDetails}";
        }
    }
}

