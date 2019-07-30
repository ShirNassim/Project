using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory
{
   public class TDirectory
    {
        public string fullName { get; set; }
        public string phoneNum { get; set; }
       // public List<TDirectory> tDList = new List<TDirectory>();

        public override string ToString()
        {
            return "Name: " + fullName + "   Phone Number: " + phoneNum;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TDirectory objAsTDirectory = obj as TDirectory;
            if (objAsTDirectory == null) return false;
            else return Equals(objAsTDirectory);
        }

        public override int GetHashCode()
        {
            string SubString = phoneNum.Substring(1);
            int number = Int32.Parse(SubString);
            return number;
        }

        public bool Equals(TDirectory other)
        {
            if (other == null) return false;
            return (this.phoneNum.Equals(other.phoneNum));
        }

      
    } 
}
