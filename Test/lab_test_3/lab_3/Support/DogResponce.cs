using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Support
{
    internal class DogResponce
    {
        public string message { get; set; }
        public string status { get; set; }
        DogResponce() { message = ""; status = ""; }
        DogResponce(string message, string status) {this.message= message; this.status = status; }
    }
}
