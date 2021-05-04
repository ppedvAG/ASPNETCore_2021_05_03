using EFCoreWithMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWithMVC.ViewModels
{
    public class PersonVM
    {
        public Person PersonObj { get; set; }
        public int Salary { get; set; }
    }
}
