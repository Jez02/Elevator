using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;

namespace Lift_assignmentn
{
    public partial class Form1 : Form
    {

        private int lift_status;
        System.Windows.Forms.Timer mytimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer6 = new System.Windows.Forms.Timer();

        System.Timers.Timer t;

        System.Timers.Timer t2timer;

        System.Timers.Timer t3timer;


        private int height = 400;
        private int moveHieght = 400;


        int doormove = 10;

        private void timerstart()
        {
            timer6.Interval = 5000;
            timer6.Tick += new EventHandler(timer1_Tick);
            timer6.Start();
            doorpos = "doors closed";
            listBox1.Items.Add(DateTime.Now.ToString("h:mm:ss tt") + ": (doors closed)");

        }

        public Form1()
        {
            InitializeComponent();
            t2timer = new System.Timers.Timer();
            t2timer.Interval = 400;
            t2timer.Elapsed += onTimeEvent;

            t3timer = new System.Timers.Timer();
            t3timer.Interval = 500;
            t3timer.Elapsed += onTimeEventdown;

            listBox3.BringToFront();
            pictureBox4.BringToFront();
            pictureBox1.SendToBack();
            pictureBox3.SendToBack();


        }



        private void onTimeEventdown(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                t3timer.Interval = 500;
                movepictureBox2down();
            }));
        }
        private string doorpos = "";

        private bool completed = false;
        private bool movecomp = false;
        private void movepictureBox2down()
        {
            int screenHeight = this.ClientSize.Height; 
                                                       

            if (pictureBox2.Top < 260)
            {
                moveHieght += 10;
                pictureBox2.Top += 10;

                pictureBox5.Top += 10;
                pictureBox6.Top += 10;

                if (!movecomp)
                {
                    pictureBox5.Left -= 30;
                    pictureBox6.Left += 30;
                    pictureBox10.Left -= 30;
                    pictureBox11.Left += 30;
                    movecomp = true;
                }

                if (moveHieght < 600)
                {
                    t3timer.Interval = 100;
                }
                else
                {
                    moveHieght = 400;
                    t3timer.Start();
                    completed = true;
                }
            }
            else
            {
                t3timer.Stop();
                if (completed)
                {
                    pictureBox5.Left += 30;
                    pictureBox6.Left -= 30;
                    pictureBox9.Left += 30;
                    pictureBox8.Left -= 30;
                    movecomp = false;
                    doorpos = "doors open";
                    listBox1.Items.Add(DateTime.Now.ToString("h:mm:ss tt") + ": (doors opened)");

                }
            }
        }
        private void firstsetuppicturebox2(object sender, EventArgs e)
        {

        }


        private void onTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                t2timer.Interval = 100;
                movepictureBox2();
            }));
        }

        private bool compup = false;
        private bool closedoor = false;
        private void movepictureBox2()
        {

            if (pictureBox2.Top > 53)
            {
                moveHieght += 10;
                pictureBox2.Top -= 10;
                pictureBox5.Top -= 10;
                pictureBox6.Top -= 10;

                if (!closedoor)
                {
                    pictureBox5.Left -= 30;
                    pictureBox6.Left += 30;
                    pictureBox9.Left -= 30;
                    pictureBox8.Left += 30;
                    closedoor = true;
                }

                if (moveHieght < 600)
                {
                    t2timer.Interval = 100;
                }
                else
                {
                    moveHieght = 400;
                    t2timer.Start();
                    compup = true;
                }
            }
            else
            {
                t2timer.Stop();
                if (compup)
                {
                    pictureBox5.Left += 30;
                    pictureBox6.Left -= 30;
                    pictureBox10.Left += 30;
                    pictureBox11.Left -= 30;
                    compup = false;
                    closedoor = false;
                    doorpos = "doors opened";
                    listBox1.Items.Add(DateTime.Now.ToString("h:mm:ss tt") + ": (doors opened)");

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lift_status = 0;
            pictureBox1.Visible = true;
            pictureBox3.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private string liftdirection = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if (lift_status == 0)
            {
                listBox4.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox2.Items.Add("   1");
                listBox3.Items.Add("   1");
                listBox4.Items.Add("   1");
                lift_status = 1;
                timerstart();
                t2timer.Interval = 100;
                t2timer.Start();
                liftdirection = "lift went up";
                listBox1.Items.Add(DateTime.Now.ToString("h:mm:ss tt") + ": (Lift went up)");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lift_status == 0)
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox2.Items.Add("   G");
                listBox3.Items.Add("   G");
                listBox4.Items.Add("   G");
                timerstart();
                lift_status = 1;
                t3timer.Interval = 100;
                t3timer.Start();
                liftdirection = "lift went down";
                listBox1.Items.Add(DateTime.Now.ToString("h:mm:ss tt") + ": (Lift went down)");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string dbconnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/jezco/OneDrive/Desktop/Lift assignmentn - Copy (3)/Database31.accdb;";
            string dbcommand = "Select ID, time, position, door position from lift_db;";

            OleDbConnection conn = new OleDbConnection(dbconnection);
            OleDbCommand comm = new OleDbCommand(dbcommand, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);


            try
            {
                conn.Open();
                adapter.Fill(ds, "lift_db");

                listBox1.Items.Clear();

                foreach (DataRow row in ds.Tables["lift_db"].Rows)
                {
                    string ID = row["ID"].ToString();
                    string time = row["time"].ToString();
                    string position = row["position"].ToString();
                    string name = row["door position"].ToString();

                    listBox1.Items.Add($"ID: {ID}, time: {time}, position: {position}, door position: {position}");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lift_status == 0)
            {
                listBox4.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox2.Items.Add("    1");
                listBox3.Items.Add("    1");
                listBox4.Items.Add("    1");
                lift_status = 1;
                timerstart();
                t2timer.Interval = 100;
                t2timer.Start();
                liftdirection = "lift went up";
                listBox1.Items.Add(DateTime.Now.ToString("h:mm:ss tt") + ": (Lift went up)");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lift_status == 0)
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox2.Items.Add("   G");
                listBox3.Items.Add("   G");
                listBox4.Items.Add("   G");
                timerstart();
                lift_status = 1;
                t3timer.Interval = 100;
                t3timer.Start();
                liftdirection = "lift went down";
                listBox1.Items.Add(DateTime.Now.ToString("h:mm:ss tt") + ": (Lift went down)");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void liftdbBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }


        private void button6_Click_1(object sender, EventArgs e)
        {
            string dbconnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/jezco/OneDrive/Desktop/Lift assignmentn - Copy (3)/Database31.accdb;";
            string insertCommand = "INSERT INTO lift_db ([time], [position], [door position]) VALUES (@time, @position, @door_position)";

            OleDbConnection conn = new OleDbConnection(dbconnection);
            OleDbCommand comm = new OleDbCommand(insertCommand, conn);

            comm.Parameters.AddWithValue("@time", DateTime.Now.ToString("h:mm:ss tt"));
            comm.Parameters.AddWithValue("@direction", liftdirection);
            comm.Parameters.AddWithValue("@door_position", doorpos);

            try
            {
                conn.Open();
                int rowsAffected = comm.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    listBox1.Items.Add("Data saved successfully.");
                }
                else
                {
                    listBox1.Items.Add("No data was saved.");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}



   