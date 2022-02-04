using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Jk { get; set; }
        public string Jabatan { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
        public string NoTelp { get; set; }
    }
}
