using Shapes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ShapeApp
{
    [Serializable]
    public partial class Form1 : Form
    {
        BindingSource shapeBinding = new BindingSource();
        public Form1()
        {
            InitializeComponent();

            SetupData();
        }
        private void SetupData()
        {
            comboBox1.SelectedItem = ("0");
            comboBox2.SelectedItem = ("0");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");

        }
        static ShapeList pts = new ShapeList();
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int i = pts.NextIndex;

            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && textBox2.Text != "" && textBox2.Text != "0")
            {
                double x = 0;
                double.TryParse(textBox2.Text, out x);
                string n = (textBox1.Text);
                ShapeList pts1 = new ShapeList();

                if (comboBox2.SelectedItem == "Sphere")
                {
                    pts[i] = new Sphere(x);
                    pts[i].Name = n;
                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[i].lenth));
                    shapeBinding.DataSource = pts[i];
                    listBox1.Items.Add(pts[i]);
                    MessageBox.Show(pts[i].Name + " Sphere Added!");

                    listBox1.DisplayMember = "Display";
                    i++;



                }
                if (comboBox2.SelectedItem == "Square")
                {
                    pts[i] = new Square(x);
                    pts[i].Name = n;
                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[i].lenth));
                    shapeBinding.DataSource = pts[i];
                    listBox1.Items.Add(pts[i]);
                    MessageBox.Show(pts[i].Name + " Square Added!");
                    listBox1.DisplayMember = "Display";
                    i++;

                }
                else if (comboBox2.SelectedItem == "Circle")
                {
                    pts[i] = new Circle(x);
                    pts[i].Name = n;
                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[i].lenth));
                    shapeBinding.DataSource = pts[i];
                    listBox1.Items.Add(pts[i]);
                    MessageBox.Show(pts[i].Name + " Circle Added!");
                    listBox1.DisplayMember = "Display";
                    i++;

                }
                else if (comboBox2.SelectedItem == "Cube")
                {
                    pts[i] = new Cube(x);
                    pts[i].Name = n;
                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[i].lenth));
                    shapeBinding.DataSource = pts[i];
                    listBox1.Items.Add(pts[i]);
                    MessageBox.Show(pts[i].Name + " Cube Added!");

                    listBox1.DisplayMember = "Display";

                    i++;

                }

            }
            else
            {
                MessageBox.Show("Error!");
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "0";
            if (comboBox1.SelectedItem != null)
            {
                s = comboBox1.SelectedItem.ToString();
                if (s == "2")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Square");
                    comboBox2.Items.Add("Circle");
                }
                if (s == "3")
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Cube");
                    comboBox2.Items.Add("Sphere");
                }

            }
            else
            {
                MessageBox.Show("Please select dim");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //!!!!
                    formatter.Serialize(stream, pts);

                }
            }
        }


        private void button3_Click(object sender, EventArgs e)

        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                while (pts.NextIndex > 0)
                {
                    pts.Remove(0);
                    listBox1.Items.RemoveAt(0);
                }
                listBox1.Invalidate();
                button5.Invalidate();
                if (g != null)
                    g.Clear(Color.SkyBlue);

                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                pts = (ShapeList)binaryFormatter.Deserialize(stream);
            }
            int i;
            for (i = 0; i < pts.NextIndex; i++)
            {
                listBox1.Items.Add(pts[i]);
                listBox1.DisplayMember = "Display";
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Display";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                pts.Remove(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (g != null)
                    g.Clear(Color.SkyBlue);
            }
            else
                MessageBox.Show("Please select item");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            while (pts.NextIndex > 0)
            {
                pts.Remove(0);
                listBox1.Items.RemoveAt(0);
            }
            listBox1.Invalidate();
            button5.Invalidate();
            if (g != null)
                g.Clear(Color.SkyBlue);

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Error! Please select item.");

            }

            else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && textBox2.Text != "" && textBox2.Text != "0")
            {

                double x = 0;
                double.TryParse(textBox2.Text, out x);
                string n = (textBox1.Text);
                ShapeList pts1 = new ShapeList();

                if (comboBox2.SelectedItem == "Sphere")
                {
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    //pts.Remove(index);
                    pts[index] = new Sphere(x);
                    pts[index].Name = n;
                    listBox1.Items.Insert(index, pts[index]);

                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[index].lenth));




                    listBox1.DisplayMember = "Display";
                    i++;




                }
                if (comboBox2.SelectedItem == "Square")
                {
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    //pts.Remove(index);


                    pts[index] = new Square(x);
                    pts[index].Name = n;
                    listBox1.Items.Insert(index, pts[index]);

                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[index].lenth));

                    MessageBox.Show(pts[index].Name);
                    listBox1.DisplayMember = "Display";
                    i++;

                }
                else if (comboBox2.SelectedItem == "Circle")
                {
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    //pts.Remove(index);


                    pts[index] = new Circle(x);
                    pts[index].Name = n;
                    listBox1.Items.Insert(index, pts[index]);

                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[index].lenth));

                    MessageBox.Show(pts[index].Name);
                    listBox1.DisplayMember = "Display";
                    i++;

                }
                else if (comboBox2.SelectedItem == "Cube")
                {
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    //pts.Remove(index);


                    pts[index] = new Cube(x);
                    pts[index].Name = n;
                    listBox1.Items.Insert(index, pts[index]);

                    Console.WriteLine(string.Format("The Lenth is {0:N}\n", pts[index].lenth));

                    MessageBox.Show(pts[index].Name);
                    listBox1.DisplayMember = "Display";


                    i++;


                }





            }


            else
            {

                MessageBox.Show("Error!");


            }
        }
        Pen p = new Pen(Color.Black, 3);
        Graphics g;
        Rectangle shape = new Rectangle(390, 230, 100, 100);
        private void button6_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (listBox1.SelectedIndex >= 0)
            {
                if (pts[index].GetType() == typeof(Circle))
                {
                    int i;
                    Pen p = new Pen(Color.Black, 3);
                    g = this.CreateGraphics();
                    Rectangle shape = new Rectangle(380, 230, 100, 100);
                    g.DrawEllipse(p, shape);

                }
                else if (pts[index].GetType() == typeof(Square))
                {
                    int i;
                    g = this.CreateGraphics();
                    Rectangle shape = new Rectangle(390, 230, 100, 100);
                    g.DrawRectangle(p, shape);
                }
                else if (pts[index].GetType() == typeof(Sphere))
                {
                    int i;
                    g = this.CreateGraphics();
                    Rectangle shape = new Rectangle(390, 230, 100, 100);
                    g.DrawEllipse(p, shape);
                    g.DrawBezier(p, 390, 270, 420, 290, 450, 290, 488, 270);
                }
                else if (pts[index].GetType() == typeof(Cube))
                {
                    int i;
                    g = this.CreateGraphics();
                    Rectangle shape = new Rectangle(390, 250, 100, 100);
                    g.DrawRectangle(p, shape);
                    g.DrawLine(p, 390, 250, 420, 210);
                    g.DrawLine(p, 490, 250, 520, 210);
                    g.DrawLine(p, 490, 350, 520, 310);
                    g.DrawLine(p, 520, 210, 520, 310);
                    g.DrawLine(p, 490, 210, 520, 210);



                }



            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i >= 0)
            {
                pts[i].Name = (textBox1.Text);
                listBox1.Items.RemoveAt(i);
                listBox1.Items.Insert(i, pts[i]);
            }
            else
            {

                MessageBox.Show("Error! Please select item.");


            }
        }

    }
}

