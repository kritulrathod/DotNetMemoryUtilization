using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetMemoryUtilization
{
  public partial class Form1 : Form
  {
    string TextBoxContent;

    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var watch = new System.Diagnostics.Stopwatch();

      watch.Start();

      for (int i = 0; i <= 100000; i++)
      {
        ExportForm(i);
      }

      watch.Stop();
      Debug.WriteLine($@"TotalSeconds: {watch.Elapsed.TotalSeconds}");
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var watch = new System.Diagnostics.Stopwatch();

      watch.Start();

      Parallel.For(0, 100000, i =>
      {
        ExportForm(i);
      });

      watch.Stop();
      Debug.WriteLine($@"TotalSeconds: {watch.Elapsed.TotalSeconds}");
    }

    private void ExportForm(int id)
    {
      using (Form form = new Form())
      {
        //Fetch record by id and populate the form object

        TextBoxContent += new String('*', id);
        using (RichTextBox textbox = new RichTextBox() { Text = TextBoxContent })
        {
          form.Controls.Add(textbox);
        }

        //Export using the Third Party Export Component

        ForceGarbageCollect();
        TextBoxContent = string.Empty;
      }
    }

    private static void ForceGarbageCollect()
    {
      GC.Collect();
    }
  }
}
