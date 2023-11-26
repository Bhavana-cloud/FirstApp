using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpLib
{
    public class Father : Talents
    { //permetting different logic in derived 
        public virtual string settle()
        {
            return "Get a government Job,Retire bu 60 yrs ans settle in native";
        }
        public string getmarried() {
            return "Match horoscope , marry person from same custom, settle";
        }

        public override string WhatIsDating()
        {
            return "dating";
        }

        public override string Drawing()
        {
            return "Drawing";
        }
    }
    public class Child : Father {
        public override string settle()
        {
            string howtolive = "get a job,visit countries , live outside";
            howtolive = $"{howtolive} and later follow this : {base.settle()}";
            return howtolive;
        }
        new public string getmarried()
        {
            return "register marriage,surprise parents,settle abroad";//encapsulation
        }
        public override string Drawing()
        {
            return "Drawing portraits, Tanjore Paintings";
        }
        public override string WhatIsDating()
        {
            return "Dating yes";
        }

    } 
    




    //abstarct == incomplete
    public abstract class Talents
    {
        public abstract string WhatIsDating();
        public abstract string Drawing();



    }
}
