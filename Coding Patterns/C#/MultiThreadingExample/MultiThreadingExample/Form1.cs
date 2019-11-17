using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadingExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTimeConsumingWork_Click(object sender, EventArgs e)
        {
            btnTimeConsumingWork.Enabled = false;
            btnPrintNumbers.Enabled = false;

            // Create another THREAD to offload the work of
            // executing the time consuming method to it.
            // As a result the UI thread, is free to execute the
            // rest of the code and our application is more responsive.
            Thread workerThread = new Thread(DoTimeConsumingWork);
            workerThread.Start();
            //DoTimeConsumingWork();

            btnTimeConsumingWork.Enabled = true;
            btnPrintNumbers.Enabled = true;

        }

        private void DoTimeConsumingWork()
        {
            Thread.Sleep(10000);
        }

        private void btnPrintNumbers_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                listBoxNumbers.Items.Add(i);
            }
        }
    }
}
