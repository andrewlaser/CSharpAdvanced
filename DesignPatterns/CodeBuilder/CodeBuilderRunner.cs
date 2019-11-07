using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder
{
    public class Field
    {
        public string Name, Type;

        public Field(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Type)}: {Type}";
        }
    }

    public class CodeBuilder
    {
        public List<Field> Fields;

        private string _className;
        public CodeBuilder(string className)
        {
            _className = className;
            Fields = new List<Field>();
        }

        public CodeBuilder AddField(string name, string type)
        {
            Fields.Add(new Field(name, type));
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"public class {_className}\n");
            sb.Append("{\n");
            foreach (var field in Fields)
            {
                sb.Append($"  public {field.Type} {field.Name};\n");
            }
            
            sb.Append("}");
            return sb.ToString();
        }
    }

    class CodeBuilderRunner
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
