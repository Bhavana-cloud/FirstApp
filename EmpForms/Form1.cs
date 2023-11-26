using EmpLib;

namespace EmpForms
{
    public partial class Form1 : Form
    {
        Employee kpmgemp = new Employee();
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click2;
            button1.Click += Button1_Click3;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;

            kpmgemp.Join += Bhavana_Join;
            kpmgemp.Join += kiran_Join;
            kpmgemp.Join += Keerthi_Join;

            kpmgemp.Resign += Bhavana_Resign;
            kpmgemp.Resign += kiran_Resign;
            kpmgemp.Resign += Keerthi_Resign;

        }

        private void Button3_Click(object? sender, EventArgs e)
        {
            kpmgemp.TriggerResignEvent();
        }

        private void Keerthi_Resign(object? sender, EventArgs e)
        {
            MessageBox.Show("Keerthi Resigned");

        }

        private void kiran_Resign(object? sender, EventArgs e)
        {
            MessageBox.Show("kiran Resigned");

        }

        private void Bhavana_Resign(object? sender, EventArgs e)
        {
            MessageBox.Show("Bhavana Resigned");
        }

        private void Keerthi_Join(object? sender, EventArgs e)
        {
            MessageBox.Show("keerthi joined KPMG succesfully");
        }

        private void kiran_Join(object? sender, EventArgs e)
        {
            MessageBox.Show("kiran joined KPMG succesfully");
        }

        private void Bhavana_Join(object? sender, EventArgs e)
        {
            MessageBox.Show("Bhavana joined KPMG succesfully");
        }
        private void Button2_Click(object? sender, EventArgs e)
        {
            kpmgemp.TriggerJoinEvent();
        }

        private void Button1_Click3(object? sender, EventArgs e)
        {
            MessageBox.Show("You clicked this button thrice");
        }

        private void Button1_Click2(object? sender, EventArgs e)
        {
            MessageBox.Show("You clicked this button twice");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you clicked the button");
        }
    }
}