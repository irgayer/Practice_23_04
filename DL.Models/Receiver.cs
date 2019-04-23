﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Receiver : Entity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public ICollection<Mail> Mails { get; set; }

        public void Print()
        {
            Console.WriteLine($"Имя    : {FullName}");
            Console.WriteLine($"Адресс : {Address} ");
        }
    }
}
