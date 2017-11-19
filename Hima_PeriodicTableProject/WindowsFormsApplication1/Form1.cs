using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    //Dear nerds, I fixed this shit.  -Jon.
    public partial class Form1 : Form
    {
        BindingSource bindingSource = new BindingSource();
        Elements elements = new Elements();
        int characterCount = 0;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource;
            PopulateElementList();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = from ele in elements.ElementDictionary
                                       orderby ele.Value.Name
                                       select new
                                       {
                                           AtomicNumber = ele.Value.AtomicNumber,
                                           Name = ele.Value.Name,
                                           Symbol = ele.Key,
                                           Mass = ele.Value.AtomicMass
                                       };
            dataGridView1.Columns[0].HeaderText = "Atomic Number";
        }

        private void btnSortAtomic_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = from ele in elements.ElementDictionary
                                       orderby ele.Value.AtomicNumber
                                       select new
                                       {
                                           AtomicNumber = ele.Value.AtomicNumber,
                                           Name = ele.Value.Name,
                                           Symbol = ele.Key,
                                           Mass = ele.Value.AtomicMass
                                       };
            dataGridView1.Columns[0].HeaderText = "Atomic Number";
        }

        private void btnSingleChar_Click(object sender, EventArgs e)
        {
            bindingSource.DataSource = from ele in elements.ElementDictionary
                                       where ele.Key.Length == 1
                                       orderby ele.Value.Name
                                       select new
                                       {
                                           AtomicNumber = ele.Value.AtomicNumber,
                                           Name = ele.Value.Name,
                                           Symbol = ele.Key,
                                           Mass = ele.Value.AtomicMass
                                       };
            dataGridView1.Columns[0].HeaderText = "Atomic Number";
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            characterCount = 0;
            double dMolarMass = 0;
            int iTemp = 0;
            int useless;
            Dictionary<string, int> matchdict = new Dictionary<string, int>();
            string s = @"[A-Z]{1}[a-z]{0,1}\d{0,99}";

            Regex regex = new Regex(s);
            MatchCollection mc = regex.Matches(tbInput.Text);

            tbMolarMass.Clear();
            
            foreach (Match item in mc)
            {
                //Probably could be done much more cleanly with some
                //kind of recursion. Isolates the characters from the integers in 
                //the match collection and checks
                //if the dictionary contains them.  If so, they are processed, if not, they
                //are truncated and re-checked for matches (this fixes the 'Hi' problem, 
                //it checks for a match on the 'H' after failing the check on Hi).
                
                string storage = item.ToString();
                if (storage.Length > 1)
                {
                    char[] checkSecond = storage.ToCharArray();
                    if (!int.TryParse(checkSecond[1].ToString(), out useless))
                    {
                        if (!elements.ElementDictionary.Keys.Contains(storage.Substring(0, 2)))
                        {
                            storage = storage.Remove(1);
                            if (elements.ElementDictionary.Keys.Contains(storage))
                                characterCount++;
                        }
                        else
                            characterCount += storage.Length;
                    }
                    else if(elements.ElementDictionary.Keys.Contains(storage.Remove(1)))
                        characterCount += storage.Length;
                }
                else if(elements.ElementDictionary.Keys.Contains(storage))
                    characterCount++;

                string name = "";
                string nums = "";
                int num = 0;
                foreach (char value in storage)
                {
                    if (int.TryParse(value.ToString(), out num))
                        nums += num.ToString();
                    else
                        name += value.ToString();
                    iTemp++;
                }
                if (nums == "")
                    nums = "1";
                if (matchdict.ContainsKey(name))
                    matchdict[name] += int.Parse(nums);
                else
                    matchdict.Add(name, int.Parse(nums));
            }

            foreach (KeyValuePair<string, int> thing in matchdict)
                Console.WriteLine(thing.Key + " :: " + thing.Value);
            //dictionary should be good after here

            bindingSource.DataSource = from ele in elements.ElementDictionary
                                       where matchdict.ContainsKey(ele.Key)

                                       select new
                                       {
                                           Element = ele.Value.Name,
                                           Count = matchdict[ele.Key],
                                           Mass = ele.Value.AtomicMass,
                                           TotalMass = ele.Value.AtomicMass * matchdict[ele.Key],
                                       };
            dataGridView1.Columns[0].HeaderText = "Atomic Number";

            foreach (DataGridViewRow entry in dataGridView1.Rows)
                if (entry.Cells.Count > 3)
                    dMolarMass += double.Parse(entry.Cells[3].Value.ToString());

            tbMolarMass.Text = dMolarMass.ToString();
            if (tbInput.Text.Length == 0)
                PopulateElementList();

            string s2 = "";
            foreach (Match value in mc)
                s2 += value.ToString();

            if (characterCount == tbInput.Text.Length)
                tbMolarMass.ForeColor = Color.Green;
            else if (characterCount < tbInput.Text.Length)
                tbMolarMass.ForeColor = Color.Yellow;
            if (characterCount == 0 && tbInput.Text.Length != 0)
                tbMolarMass.ForeColor = Color.Red;
            if (s2.Length == 0 && tbInput.Text.Length == 0)
                tbMolarMass.ForeColor = Color.Black;
        }

        public void PopulateElementList()
        {
            bindingSource.DataSource = from ele in elements.ElementDictionary
                                       select new
                                       {
                                           AtomicNumber = ele.Value.AtomicNumber,
                                           Name = ele.Value.Name,
                                           Symbol = ele.Key,
                                           Mass = ele.Value.AtomicMass
                                       };
            dataGridView1.Columns[0].HeaderText = "Atomic Number";
        }
    }
}
