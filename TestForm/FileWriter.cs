using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    class FileWriter
    {
            
        public void test()
        {
            using (StreamWriter writer =
                   new StreamWriter("c:\\important.txt"))
            {
                writer.Write("Word ");
                writer.WriteLine("word 2");
                writer.WriteLine("Line");
            }
        }

       

    }
}
