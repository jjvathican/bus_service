using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace bus_service2
{
    public partial class Form1 : Form
    {
        string[] details = new string[10];
        public Form1()
        {
            InitializeComponent();
           dateTimePicker3.Value = DateTime.Parse("11:11:11 PM");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            String temp = comboBox15.Text;
            comboBox15.Text = comboBox4.Text;
            comboBox4.Text = temp;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // dateTimePicker1.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
        }
        string connection = @"Data Source=C:\Users\jj\PycharmProjects\bus_root\bus_data.sqlite;Version=3;";
        //int det;
        

        public void collect(String s, ComboBox c,int i,int j)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                string query = s;

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);
                command.ExecuteNonQuery();
                SQLiteDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {   
                    c.Items.Add(dr.GetString(i)+","+dr.GetString(j));
                    // c = dr.GetString(1);

                }
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqliteCon.Close();
            }
        }
       
        int count=0;
        private void button12_Click(object sender, EventArgs e)
        {
            count = count + 1;
            label21.Text = (count).ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            count = count - 1;
            label21.Text = (count).ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Parse("11:11:11");
            var he = now.Minute;
            DateTime twoHoursLater = now + new TimeSpan(0,count,0);
            MessageBox.Show(he+" "+ twoHoursLater);

        }

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            string b = comboBox3.Text.Split(',')[0];
            //MessageBox.Show(""+comboBox3.Text);
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                string query = "select * from main_table where bus_number ='" + b + "'";   //  '" + textBox1.Text + "'and password='" + textBox2.Text + "'";

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);
                command.ExecuteNonQuery();
                SQLiteDataReader dr = command.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {

                    string[] row = new string[] { dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4) };
                    dataGridView4.Rows.Add(row);
                    //MessageBox.Show(dr.GetString(1));
                   
                    count++;
                }
                sqliteCon.Close();
                if (count >= 1)
                {
                    //groupBox1.Enabled = true;
                    //MessageBox.Show("welcome");
                    //groupBox1.Enabled = true;
                    //groupBox3.Enabled = true;
                }
                else
                {
                    // MessageBox.Show("wrong  username or password ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("no data"+ex.Message);
                sqliteCon.Close();
            }
        }

        private void combo_click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();

            collect("select * from bus order by bus_number", comboBox3, 1, 2);
           
        }
        void display()
        {
            dataGridView4.Rows.Clear();
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                string query = "select * from main_table";   //  '" + textBox1.Text + "'and password='" + textBox2.Text + "'";

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);
                command.ExecuteNonQuery();
                SQLiteDataReader dr = command.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {

                    string[] row = new string[] { dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4) };
                    dataGridView4.Rows.Add(row);
                    //MessageBox.Show(dr.GetString(1));
                    count++;
                }
                sqliteCon.Close();
                if (count >= 1)
                {
                    //  groupBox1.Enabled = true;
                    //MessageBox.Show("welcome");
                    //groupBox1.Enabled = true;
                    //groupBox3.Enabled = true;
                }
                else
                {
                    // MessageBox.Show("wrong  username or password ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqliteCon.Close();
            }
        }
        void display_bus()
        {
            dataGridView4.Rows.Clear();
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                string query = "select * from bus";   //  '" + textBox1.Text + "'and password='" + textBox2.Text + "'";

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);
                command.ExecuteNonQuery();
                SQLiteDataReader dr = command.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {

                    string[] row = new string[] { dr.GetString(0), dr.GetString(1), dr.GetString(2)};
                    dataGridView2.Rows.Add(row);
                    //MessageBox.Show(dr.GetString(1));
                    count++;
                }
                sqliteCon.Close();
                if (count >= 1)
                {
                    //  groupBox1.Enabled = true;
                    //MessageBox.Show("welcome");
                    //groupBox1.Enabled = true;
                    //groupBox3.Enabled = true;
                }
                else
                {
                    // MessageBox.Show("wrong  username or password ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqliteCon.Close();
            }
        }
        void display_place()
        {
            dataGridView4.Rows.Clear();
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                string query = "select * from place";   //  '" + textBox1.Text + "'and password='" + textBox2.Text + "'";

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);
                command.ExecuteNonQuery();
                SQLiteDataReader dr = command.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {

                    string[] row = new string[] { dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3) };
                    dataGridView3.Rows.Add(row);
                    //MessageBox.Show(dr.GetString(1));
                    count++;
                }
                sqliteCon.Close();
                if (count >= 1)
                {
                    //  groupBox1.Enabled = true;
                    //MessageBox.Show("welcome");
                    //groupBox1.Enabled = true;
                    //groupBox3.Enabled = true;
                }
                else
                {
                    // MessageBox.Show("wrong  username or password ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqliteCon.Close();
            }
        }
        private void vIEWALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display();
        }

        private void from_click(object sender, EventArgs e)
        {

            ComboBox c = (ComboBox)sender;
            c.Items.Clear();
            collect("select pincode,pin_name from place order by pincode",c, 0,1);
       
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void to_click(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            c.Items.Clear();
            collect("select pincode,pin_name from place order by pincode", c, 0,1);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //view details
            if (comboBox15.Text != comboBox4.Text)
            {
                string bus_num = comboBox3.Text.Split(',')[0];
                string from = comboBox15.Text.Split(',')[0];
                string to = comboBox4.Text.Split(',')[0];
                string stop_name = textBox6.Text;
                //dateTimePicker3.Format = DateTimePickerFormat.Custom;
                //dateTimePicker3.CustomFormat = "HH:mm:ss";

                string stop_time = dateTimePicker3.Value.ToString("HH:mm");
                MessageBox.Show(bus_num + " " + from + " " + to + " " + stop_name + " " + stop_time);
                SQLiteConnection sqliteCon = new SQLiteConnection(connection);
                try
                {
                    sqliteCon.Open();
                    //(bus_number, from, to, stop_name, stop_time)
                    string query = "INSERT INTO main_table  VALUES ('" + bus_num + "','" + from + "','" + to + "','" + stop_name + "','" + stop_time + "')";

                    SQLiteCommand command = new SQLiteCommand(query, sqliteCon);

                    if (command.ExecuteNonQuery() == 1)
                    {

                        MessageBox.Show("inserted");


                    }

                    sqliteCon.Close();
                    dataGridView4.Rows.Clear();
                    display();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    sqliteCon.Close();
                }
            }
            else { MessageBox.Show("what!! the same place"); }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            //........bus add..............
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                //(bus_number, from, to, stop_name, stop_time)
                string query = "INSERT INTO bus  VALUES ('" + comboBox8.Text + "','" + textBox2.Text + "','" + comboBox9.Text +  "')";

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);

                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("inserted");


                }

                sqliteCon.Close();
                dataGridView2.Rows.Clear();
                display_bus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqliteCon.Close();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            // addd places
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                //(bus_number, from, to, stop_name, stop_time)
                string query = "INSERT INTO place  VALUES ('" + comboBox11.Text + "','" + comboBox10.Text + "','" + comboBox12.Text + "','" + comboBox13.Text+  "')";

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);

                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("inserted");


                }

                sqliteCon.Close();
                dataGridView2.Rows.Clear();
                display_place();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqliteCon.Close();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            // search buttom
            string from = comboBox1.Text.Split(',')[0];
            string to = comboBox2.Text.Split(',')[0];
            dataGridView1.Rows.Clear();
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            try
            {
                sqliteCon.Open();
                string query = "select * from main_table where from_pin = '" + from + "'and to_pin='" + to + "'";

                SQLiteCommand command = new SQLiteCommand(query, sqliteCon);
                command.ExecuteNonQuery();
                SQLiteDataReader dr = command.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {

                    string[] row = new string[] { dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4) };
                    dataGridView1.Rows.Add(row);
                    //MessageBox.Show(dr.GetString(1));
                    count++;
                }
                sqliteCon.Close();
                if (count >= 1)
                {
                    //  groupBox1.Enabled = true;
                    //MessageBox.Show("welcome");
                    //groupBox1.Enabled = true;
                    //groupBox3.Enabled = true;
                }
                else
                {
                    // MessageBox.Show("wrong  username or password ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqliteCon.Close();
            }

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void cLEARALLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
