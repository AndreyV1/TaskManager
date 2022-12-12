using TaskManagerCommandsLib;
using System.Diagnostics;
using System.ComponentModel.Design;
using TaskManagerCommandsLib.Commands;

public partial class Form1 : Form
{
    Manager manager = new Manager();
    StartProcess process = new StartProcess();
    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        LoadTable();
        ListBox_1.Items.AddRange(process.ReturnAppsNames());
    }
    private void LoadTable()
    {
        string[] pid = manager.ExecuteCommand("GPID").Split(' ');
        string[] pName = manager.ExecuteCommand("GPNAME").Split('\\');
        dataGridView1.Rows.Clear();
        dataGridView1.Rows.Add(pid.Length);
        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        {
            dataGridView1[0, i].Value = pid[i];
            dataGridView1[1, i].Value = pName[i];

        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        LoadTable();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        int currentRow = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
        manager.ExecuteCommand("KP " + (dataGridView1[0, currentRow]).Value.ToString());
        LoadTable();
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
        int currentRow = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
        manager.ExecuteCommand("KP " + dataGridView1[1, currentRow].Value.ToString());
        LoadTable();
    }

    private void StartProcess_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void button4_Click(object sender, EventArgs e)
    {
        manager.ExecuteCommand("SP " + ListBox_1.SelectedItem.ToString());
    }
}