using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
      MemoryProfiler.LogMemoryFootPrint(0);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Form form = new Form();
      for (int i = 0; i <= 100000; i++)
      {
        ExportForm(form, i);
      }
    }

    private void ExportForm(Form form, int id)
    {
      //Fetch record by id and populate the form object

      TextBoxContent += new String('*', id);
      RichTextBox textbox = new RichTextBox() { Text = TextBoxContent };
      form.Controls.Add(textbox);

      //Export using the Third Party Export Component

      MemoryProfiler.LogMemoryFootPrint(id);
    }
  }
}
