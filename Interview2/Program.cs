using Interview2.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> communications = new List<object> {
            new Email { From = "mdarabseh@iom.int", To = "mdarabseh@iom.int", Body = "test body", Subject = "subj", IsBodyHtml = false },
            new SMS { From = "IOM Germany", To = "96278880999", Body = "test body", Subject = "subj"}
            };

            foreach (var obj in communications)
            {                
                Sender.Send(obj);
            }

            Console.ReadLine();
        }


    }
    
}
