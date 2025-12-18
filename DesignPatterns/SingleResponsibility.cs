using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Journal
    {
        public readonly List<string> entries = new List<string>();
        public static int count = 0;

        public int AddEntry(string entry)
        {
            entries.Add($"{++count} : {entry}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Persistance
    {
        /*
         Here we can write SaveJournal method in in Journal Class itself but We will have two reasons to change the class
        1. Maintaing Journals
        2. Saving Journals

        But Now persistance of Journals is handled by this class.
          */
        public void SaveJournal(Journal journal, string filePath, bool overWrite)
        {
            if (overWrite || !File.Exists(filePath))
            {
                File.WriteAllText(filePath, journal.ToString());
            }
        }
    }
    class ProgramSR
    {
        static void MainSP(string[] args)
        {
            Journal journal = new Journal();
            journal.AddEntry("journal 1");
            journal.AddEntry("journal 2");
            journal.RemoveEntry(0);

            Persistance p = new Persistance();
            string fileName = @"C:\Journal.txt";
            p.SaveJournal(journal, fileName, true);
            Process.Start(fileName);
        }
    }
}
