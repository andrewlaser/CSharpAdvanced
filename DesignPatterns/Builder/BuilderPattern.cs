using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int _indentSize = 2;

        public HtmlElement()
        {
            
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new  StringBuilder();
            var i = new string(' ', _indentSize * indent);
            sb.Append($"{i}<{Name}>");
            sb.Append("\n");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', _indentSize * (indent+1)));
                sb.Append(Text);
                sb.Append("\n");
                }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent+1));
            }
            sb.Append($"{i}</{Name}>");
            sb.Append("\n");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string _rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            _rootName = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement{Name = root.Name};
        }
    }

    class BuilderPattern
    {
        static void Main(string[] args)
        {
            //var hello = "hello";
            //var sb = new StringBuilder();
            //sb.Append("<p>");
            //sb.Append(hello);
            //sb.Append("</p>");
            //Console.WriteLine(sb);

            //List<string> words = new List<string> {"hello", "world"};

            //sb.Clear();
            //sb.Append("<ul>");
            //foreach (var w in words)
            //{
            //    sb.Append($"<li>{w}</li>");
            //}
            //sb.Append("</ul>");
            //Console.WriteLine(sb);


            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello").AddChild("li", "World");
            Console.WriteLine(builder.ToString());


            Console.ReadKey();

        }
    }
}
