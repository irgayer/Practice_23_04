using DL.DataAccess;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var repository = new ReceiversRepository())
            {
                var mail = new MyMail();

                mail.Run();
            }
        }
    }
}
