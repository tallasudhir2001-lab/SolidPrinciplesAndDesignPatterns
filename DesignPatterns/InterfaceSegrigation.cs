using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    /*
     states that "Clients should not be forced to depend on interfaces they do not use."
    In C#, this means that instead of creating large, "fat" interfaces with many methods, 
    it is better to create smaller, more specific interfaces tailored to the needs of different client classes. 
    */
    public class Document
    {
        public string name;
    }
    interface Imachine
    {
        void print(Document d);
        void scan(Document d);
        void fax(Document d);
    }
    public class multiFunctionPrinter : Imachine
    {
        public void fax(Document d)
        {
            //
        }

        public void print(Document d)
        {
            //
        }

        public void scan(Document d)
        {
            //
        }
    }
    //The above one is fine but what if we have a printer that is limited to only printing
    public class OldFashionedPrinter : Imachine
    {
        //even though it is not capabale of handling sacan and fax it is forced to implement it.So 
        public void fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void print(Document d)
        {
            throw new NotImplementedException();
        }

        public void scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    //So we need to segrigate our interface

    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public class Printer : IPrinter
    {
        public void Print(Document d)
        {
        }
    }
    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    //or we can do this as well
    public interface IMultiFunctionDevice : IPrinter, IScanner
    {

    }
    public class MultiFunctionDevice : IMultiFunctionDevice
    {
        public IScanner scanner;
        public IPrinter printer;
        public MultiFunctionDevice(IScanner scanner, IPrinter printer)
        {
            this.scanner = scanner;
            this.printer = printer;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
    internal class ProgramIS
    {
        static void MainIS(string[] args)
        {

        }
    }
}
