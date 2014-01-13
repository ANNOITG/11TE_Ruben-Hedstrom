using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Microsoft.VisualBasic.FileIO;


namespace FileExplorer_TreeView
{
    class FileExplorer
    {
        public FileExplorer()
        {
        }

        public bool CreateTree(TreeView treeView)
        {
            bool returnValue = false;
                 
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {                    
                    TreeNode tree = new TreeNode();
                    if (drive.DriveType == DriveType.CDRom)
                    {
                        tree.ImageIndex = 1;
                        tree.SelectedImageIndex = 1;
                    }
                    else if (drive.DriveType == DriveType.Fixed)
                    {
                        tree.ImageIndex = 0;
                        tree.SelectedImageIndex = 0;
                    }
                    tree.Text = drive.Name;
                    tree.Nodes.Add("");
                    treeView.Nodes.Add(tree);
                    returnValue = true;
                }

            }
            catch (Exception)
            {
                returnValue = false;
            }
            return returnValue;            
        }
        public TreeNode EnumerateDirectory(TreeNode parentNode)
        {          
            try
            {
                DirectoryInfo rootdir;

                Char [] arr={'\\'};
                string [] nameList=parentNode.FullPath.Split(arr);
                string path = "";

                if (nameList.GetValue(0).ToString() == "Desktop")
                {
                    path = SpecialDirectories.Desktop+"\\";

                    for (int i = 1; i < nameList.Length; i++)
                    {
                        path = path + nameList[i] + "\\";
                    }

                    rootdir = new DirectoryInfo(path);
                }

                else
                {                   
                    rootdir = new DirectoryInfo(parentNode.FullPath + "\\");
                }
                
                parentNode.Nodes[0].Remove();
                foreach (DirectoryInfo dir in rootdir.GetDirectories())
                {
                    
                    TreeNode node = new TreeNode();
                    node.Text = dir.Name;
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }

                foreach (FileInfo file in rootdir.GetFiles())
                {
                    TreeNode node = new TreeNode();
                    node.Text = file.Name;
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    parentNode.Nodes.Add(node);
                }
            }

            catch (Exception)
            {
            }          
            return parentNode;
        }
    }
}
