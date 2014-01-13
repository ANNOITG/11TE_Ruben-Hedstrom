using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileExplorer_TreeView
{
    public partial class Form1 : Form
    {
       // Initialize FileExplorer class
        FileExplorer fe = new FileExplorer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

               
            


        }

        private void trwFileExplorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode node = fe.EnumerateDirectory(e.Node);
            }          
                    
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         // Create file tree            
            fe.CreateTree(this.trwFileExplorer);
        }

             

    }
}