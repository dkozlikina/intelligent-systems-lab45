using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class Production
        {
            public Fact Target { get; set; }
            public HashSet<Fact> Facts { get; set; }

            public Production(Fact target, HashSet<Fact> facts)
            {
                Target = target;
                Facts = facts;
            }

            public override string ToString()
            {
                return $"{string.Join(", ", Facts)} -> {Target}";
            }
        }

        public class Fact
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public Production PrevProduction { get; set; }

            public Fact(string name, string text)
            {
                Name = name;
                Text = text;
            }

            public Fact(string name, string text, Production prevProduction)
            {
                Name = name;
                Text = text;
                PrevProduction = prevProduction;
            }

            public override bool Equals(object obj)
            {
                if (this == obj) return true;
                if (!(obj is Fact fact)) return false;
                return Name == fact.Name;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }

            public override string ToString()
            {
                return Text;
            }
        }

        HashSet<Production> Productions = new HashSet<Production>();
        HashSet<Fact> provedFacts = new HashSet<Fact>();
        Stack<string> stack = new Stack<string>();

        // Создаем словарь для хранения данных
        Dictionary<string, string> facts = new Dictionary<string, string>();
        Dictionary<string, string> prod = new Dictionary<string, string>();
        HashSet<string> axioms = new HashSet<string>();
        //List<Production> Productions = new List<Production>();

        List<Fact> all_facts = new List<Fact>();
        List<Production> all_prods = new List<Production>();

        // Укажите путь к файлу, который вы хотите считать
        string factsFilePath = "facts.txt";
        string prodFilePath = "prod.txt";

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Прямой вывод";
            textBox2.Text = "Обратный вывод";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void readFile(string factsFilePath, string prodFilePath)
        {
            try
            {
                // Считываем все строки из файла
                string[] lines = File.ReadAllLines(factsFilePath);

                // Обрабатываем каждую строку
                foreach (string line in lines)
                {
                    // Разделяем строку на ключ и значение
                    string[] parts = line.Split(':');

                    // Проверяем, что строка содержит корректные данные
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        // Добавляем данные в словарь
                        facts[key] = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при чтении строки: " + line);
                    }
                }

                // Считываем все строки из файла
                string[] lines_prod = File.ReadAllLines(prodFilePath);

                // Обрабатываем каждую строку
                foreach (string line in lines_prod)
                {
                    // Разделяем строку на ключ и значение
                    string[] parts = line.Split('>');

                    // Проверяем, что строка содержит корректные данные
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        // Добавляем данные в словарь
                        prod[key] = value;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при чтении строки: " + line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
            }
        }

        void directOutput()
        {
            readFile(factsFilePath, prodFilePath);
            //textBox1.Text += "reading file\n";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                //textBox1.Text += "checking " + i.ToString() + " CheckedItems\n";
                string film_id = (checkedListBox1.CheckedItems[i] as string).Split(':')[0];
                axioms.Add(film_id);
                //textBox1.Text += " film_id = " + film_id + " ";
                //textBox1.Text += " prod.Count.ToString() = " + prod.Count.ToString();
                //textBox1.Text += " facts.Count.ToString() = " + facts.Count.ToString();
                foreach (KeyValuePair<string, string> item in prod)
                {
                    //textBox1.Text += item.Key + " " + item.Value + " | ";
                    if (item.Value == film_id)
                    {
                        textBox1.Text += " " + film_id + " -> axioms: ";
                        foreach (string it in item.Key.Split(','))
                        {
                            if (!axioms.Contains(it))
                            {
                                axioms.Add(it);
                                textBox1.Text += facts[it] + ", ";
                            }

                        }

                        break;
                        //List<string> new_axioms = item.Key.Split(',');
                    }
                }
                textBox1.Text += Environment.NewLine;
            }

            int countAxioms = axioms.Count;
            while (true)
            {
                foreach (KeyValuePair<string, string> item in prod)
                {
                    bool isNewAxiom = true;
                    foreach (string it in item.Key.Split(','))
                    {
                        if (!axioms.Contains(it))
                        {
                            isNewAxiom = false;
                            break;
                        }
                    }
                    if (isNewAxiom && !axioms.Contains(item.Value))
                    {
                        axioms.Add(item.Value);
                        textBox1.Text += Environment.NewLine;
                        foreach (string it in item.Key.Split(','))
                        {
                            if (it.Length > 0)
                            {
                                textBox1.Text += facts[it] + ',';
                            }
                        }
                        textBox1.Text += " -> " + facts[item.Value];
                    }
                }

                if (axioms.Count == countAxioms)
                    break;
                countAxioms = axioms.Count;
            }
        }
        private static bool FactIsTarget(Production production, Fact currFact)
        {
            return production.Target == currFact
            && (currFact.PrevProduction == null || !production.Facts.Contains(currFact.PrevProduction.Target));
        }

        private static bool SolveBackwardIterative(List<Production> prods, HashSet<Fact> provedFacts, Fact targetFact)
        {
            HashSet<Production> prodSet = new HashSet<Production>(prods);
            Stack<Fact> needToProve = new Stack<Fact>();
            HashSet<Fact> visited = new HashSet<Fact>();
            needToProve.Push(targetFact);

            while (needToProve.Count > 0)
            {
                Fact currFact = needToProve.Peek();
                if (visited.Contains(currFact))
                {
                    needToProve.Pop();
                }
                visited.Add(currFact);
                HashSet<Production> prodSetCopy = new HashSet<Production>(prodSet);

                foreach (Production production in prodSet)
                {
                    if (FactIsTarget(production, currFact))
                    {
                        bool isSupersetOf = true;

                        HashSet<string> names = new HashSet<string>();
                        foreach (Fact f in provedFacts)
                        {
                            names.Add(f.Name);
                        }

                        foreach (Fact f in production.Facts)
                        {
                            if (!names.Contains(f.Name))
                            {
                                isSupersetOf = false;
                                break;
                            }
                        }

                        if (isSupersetOf)
                        {
                            prodSetCopy.RemoveWhere(deleteProduction =>
                            {
                                HashSet<Fact> factsOfProduction = new HashSet<Fact>(deleteProduction.Facts);
                                factsOfProduction.Add(deleteProduction.Target);
                                return factsOfProduction.IsSupersetOf(production.Facts);
                            });
                            Console.WriteLine($"Доказан факт: {production}");
                            provedFacts.Add(production.Target);
                            break;
                        }
                        else
                        {
                            foreach (Fact fact in production.Facts)
                            {
                                if
                                (!provedFacts.Contains(fact) && !visited.Contains(fact))
                                {
                                    needToProve.Push(fact);
                                }
                            }
                        }
                    }
                }

                prodSet = prodSetCopy;
                if (provedFacts.Contains(targetFact))
                {
                    return true;
                }
            }

            return false;
        }

        public bool mySolveBack(string goal)
        {
            List<string> nesses = new List<string>();
            nesses.Add(goal);
            foreach(string s in prod.First(x => x.Value == goal).Key.Split(','))
            {
                nesses.Add(facts[s]);
            }

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                string new_string = "";
                string film_id = (checkedListBox1.CheckedItems[i] as string).Split(':')[0];
                axioms.Add(film_id);
                foreach (KeyValuePair<string, string> item in prod)
                {
                    if (item.Value == film_id)
                    {
                        new_string += " " + film_id + " -> axioms: ";
                        foreach (string it in item.Key.Split(','))
                        {
                            axioms.Add(it);
                            new_string += facts[it] + ", ";

                        }
                        foreach(string s in nesses)
                        {
                            if (new_string.Contains(s))
                            {
                                stack.Push(new_string);
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            int countAxioms = axioms.Count;
            while (true)
            {
                foreach (KeyValuePair<string, string> item in prod)
                {
                    string new_string = "";
                    bool isNewAxiom = true;
                    foreach (string it in item.Key.Split(','))
                    {
                        if (!axioms.Contains(it))
                        {
                            isNewAxiom = false;
                            break;
                        }
                    }
                    if (isNewAxiom && !axioms.Contains(item.Value))
                    {
                        axioms.Add(item.Value);
                        new_string += Environment.NewLine;
                        foreach (string it in item.Key.Split(','))
                        {
                            if (it.Length > 0)
                            {
                                new_string += facts[it] + ',';
                            }
                        }
                        new_string += " -> " + facts[item.Value];

                        foreach (string s in nesses)
                        {
                            if ((item.Value[0] != 'f') || (item.Value == goal))
                            {
                                if (new_string.Contains(s))
                                {
                                    stack.Push(new_string);
                                    break;
                                }
                            }
                        }

                        if (item.Value == goal)
                            return true;
                    }
                }

                if (axioms.Count == countAxioms)
                    break;
                countAxioms = axioms.Count;
            }
            return false;
        }

        public void backOut(string goal)
        {
            readFile(factsFilePath, prodFilePath);


            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                string film_id = (checkedListBox1.CheckedItems[i] as string).Split(':')[0];
                axioms.Add(film_id);
                foreach (KeyValuePair<string, string> item in prod)
                {
                    if (item.Value == film_id)
                    {
                        HashSet<Fact> fcts = new HashSet<Fact>();
                        foreach(string s in item.Value.Split(','))
                        {
                            Fact n_fct = new Fact(s, facts[s]);
                            fcts.Add(n_fct);
                            provedFacts.Add(n_fct);
                        }
                        Productions.Add(new Production(new Fact(item.Value, facts[item.Value]), fcts));
                    }
                        
                }
            } 
            bool result = mySolveBack(goal);

            if (result)
            {
                textBox2.Text += "Доказан факт " + facts[goal];
                textBox2.Text += Environment.NewLine;
                textBox1.Text = "";
                textBox1.Text += stack.Count.ToString();
                textBox1.Text += Environment.NewLine;
                while (stack.Count > 0)
                {
                    textBox1.Text += stack.Pop();
                    textBox1.Text += Environment.NewLine;
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text += "Не может быть доказан целевой факт " + facts[goal];
                textBox2.Text += Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            axioms = new HashSet<string>();
            facts = new Dictionary<string, string>();
            prod = new Dictionary<string, string>();
            Productions = new HashSet<Production>();
            provedFacts = new HashSet<Fact>();
            textBox1.Text = "";
            directOutput();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                axioms = new HashSet<string>();
                facts = new Dictionary<string, string>();
                prod = new Dictionary<string, string>();
                Productions = new HashSet<Production>();
                provedFacts = new HashSet<Fact>();
                stack = new Stack<string>();
                string goal = checkedListBox2.CheckedItems[i].ToString().Split(':')[0];
                backOut(goal);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
