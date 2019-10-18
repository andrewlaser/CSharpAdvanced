using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveAt(int index)
        {
            entries.RemoveAt(index);
            count--;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite)
        {
            if(overwrite || !File.Exists(filename))
            File.WriteAllText(filename, j.ToString());
        }

    }

    class SingleResponsibility
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("entry1");
            j.AddEntry("entry2");
            Console.WriteLine(j);


            Console.ReadKey();

        }
    }
}
