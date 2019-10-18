using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegregationPrinciple
{
    public class Document
    {
        
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        Document Scan();
    }

    

    public class Xero : IScanner, IPrinter
    {
        public Document Scan()
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
