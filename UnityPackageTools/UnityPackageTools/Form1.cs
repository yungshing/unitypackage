using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityPackageTools
{
    public partial class Form1 : Form
    {
        UnityTools unityTools;
        Dictionary<int, UnityPackageInfo> menuPackageInfo;
        Task openFileTask = null;
        Task setRichTxt = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            unityTools = new UnityTools();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "UnityPackage文件|*.unitypackage";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            Task t = new Task(()=>
            {
                PathTools.DeleteTmpFile();
            });
            t.Start();
        }

        private void MenuTree_DragDrop(object sender, DragEventArgs e)
        {
            var filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            
            if (!filePath .EndsWith(".unitypackage"))
            {
                MessageBoxEx.Show(this,"不支持的文件！");
                return;
            }
            OpenFile(filePath);
        }

        private void CreateTree(string[] menu,int index)
        {
            var nodes = MenuTree.Nodes;
            for (int i = 0; i < menu.Length; i++)
            {
                bool isFound = false;
                int j;
                for (j = 0; j < nodes.Count; j++)
                {
                    if (nodes[j].Text == menu[i])
                    {
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    var tmp_tn = new TreeNode()
                    {
                        Text = menu[i],
                        Name = index.ToString(),
                    };
                   
                    tmp_tn.ImageIndex = 0;
                    string str = menu[i];
                    if (str.Contains("."))
                    {
                        tmp_tn.ContextMenuStrip = contextMenuStrip1;
                    }
                    var ut = unityTools.GetUnityFileType(str);
                    switch (ut)
                    {
                        case UnityTools.UnityFileType.Null:
                            tmp_tn.SelectedImageIndex = tmp_tn.ImageIndex = 0;
                            break;
                        case UnityTools.UnityFileType.CS:
                            tmp_tn.ImageIndex = tmp_tn.SelectedImageIndex = 5;
                            break;
                        case UnityTools.UnityFileType.JS:
                            break;
                        case UnityTools.UnityFileType.Image:
                            tmp_tn.ImageIndex = 8;
                            tmp_tn.SelectedImageIndex = 8;
                            break;
                        case UnityTools.UnityFileType.Text:
                            break;
                        case UnityTools.UnityFileType.Music:
                            tmp_tn.ImageIndex = 1;
                            tmp_tn.SelectedImageIndex = 1;
                            break;
                        case UnityTools.UnityFileType.Video:
                            tmp_tn.ImageIndex = 2;
                            tmp_tn.SelectedImageIndex = 2;
                            break;
                        case UnityTools.UnityFileType.DLL:
                            tmp_tn.ImageIndex = 4;
                            tmp_tn.SelectedImageIndex = 4;
                            break;
                        case UnityTools.UnityFileType.Unity:
                            tmp_tn.SelectedImageIndex = tmp_tn.ImageIndex = 6;
                            break;
                        case UnityTools.UnityFileType.FBX:
                            tmp_tn.SelectedImageIndex = tmp_tn.ImageIndex = 7;
                            break;
                        case UnityTools.UnityFileType.Other:
                            tmp_tn.SelectedImageIndex = tmp_tn.ImageIndex = 9;
                            break;
                        default:
                            tmp_tn.SelectedImageIndex = tmp_tn.ImageIndex = 9;
                            break;
                    }
                    nodes.Add(tmp_tn);
                }
                nodes = nodes[j].Nodes;
            }
        }

        private void CreateTreeAsync(string [] menu,int index)
        {
            if (MenuTree.InvokeRequired)
            {
                MenuTree.Invoke(new Action<string[],int>(CreateTreeAsync),menu,index);
            }
            else
            {
                CreateTree(menu,index);
            }
        }
        private void MenuTree_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
                
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MenuTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Img_Box.Hide();
            Content_rt.Hide();
            var str = e.Node.FullPath.ToLower();
            var ut = unityTools.GetUnityFileType(str);
            switch (ut)
            {
                case UnityTools.UnityFileType.Null:
                    break;
                case UnityTools.UnityFileType.CS:
                    goto case UnityTools.UnityFileType.Text;
                case UnityTools.UnityFileType.JS:
                    goto case UnityTools.UnityFileType.Text;
                case UnityTools.UnityFileType.Text:
                    Content_rt.Show();
                    var lines = File.ReadAllLines(menuPackageInfo[int.Parse(e.Node.Name)].assetPath);
                    Content_rt.Text = "";
                    setRichTxt = new Task(() =>
                    {
                        SetRichTextBoxTxt(lines.ToList());
                    });
                    setRichTxt.Start();
                    break;
                case UnityTools.UnityFileType.Image:
                    Img_Box.Show();
                    var bmp = new Bitmap(menuPackageInfo[int.Parse(e.Node.Name)].assetPath);
                    Img_Box.Image = bmp;
                    break;
                case UnityTools.UnityFileType.Music:
                    break;
                case UnityTools.UnityFileType.Video:
                    break;
                case UnityTools.UnityFileType.DLL:
                    break;
                case UnityTools.UnityFileType.Unity:
                    break;
                case UnityTools.UnityFileType.FBX:
                    break;
                case UnityTools.UnityFileType.Other:
                    break;
                default:
                    break;
            }
        }
        void SetRichTextBoxTxt(List<string> txt)
        {
            if (Content_rt.InvokeRequired)
            {
                Content_rt.Invoke(new Action<List<string>>(SetRichTextBoxTxt), txt);
            }
            else
            {
                for (int i = 0; i < txt.Count; i++)
                {
                    Content_rt.Text += txt[i] + "\n";
                }
            }
        }
        private void OpenFile_m2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog1.FileName);
            }
        }

        void OpenFile(string filePath)
        {
            if (openFileTask != null)
            {
                Tip_Lab.Text = "正在打开文件，请稍后......";
                return;
            }
            Tip_Lab.Text = "加载文件中......";
            DirectoryInfo[] directoryInfos;
            openFileTask = new Task(()=>
            {
                unityTools.UnPackage(filePath, DateTime.Now.ToFileTimeUtc().ToString(),SetTip);
                SetTip("读取文件中......");
                directoryInfos = unityTools.GetDirectorys();

                menuPackageInfo = unityTools.GetMuneList(directoryInfos,SetTip);

                SetMenuTreeAsync(menuPackageInfo);

                SetTip("加载成功");

                openFileTask = null;
            });

            openFileTask.Start();
            
        }
        void SetTip(string str)
        {
            if (Tip_Lab.InvokeRequired)
            {
                Tip_Lab.Invoke(new Action<string>(SetTip),str);
            }
            else
            {
                Tip_Lab.Text = str;
            }
        }

        void SetMenuTreeAsync(Dictionary<int, UnityPackageInfo> dic)
        {
            if (MenuTree.InvokeRequired)
            {
                MenuTree.Invoke(new Action<Dictionary<int, UnityPackageInfo>>(SetMenuTreeAsync),dic);
            }
            else
            {
                MenuTree.Nodes.Clear();
                foreach (var item in menuPackageInfo)
                {
                    CreateTree(item.Value.filePathSplit, item.Value.index);
                }
            }
        }
        private void SaveFile_ts_Click(object sender, EventArgs e)
        {
            var str = MenuTree.SelectedNode.FullPath;
            var m = menuPackageInfo[int.Parse(MenuTree.SelectedNode.Name)].assetPath;
            if (!Directory.Exists("save"))
            {
                Directory.CreateDirectory("save");
            }
            if (File.Exists(m))
            {
                if (!File.Exists("save/"+MenuTree.SelectedNode.Text))
                {
                    File.Copy(m, "save/"+MenuTree.SelectedNode.Text);
                    Tip_Lab.Text = "保存成功！！查看目录中的save文件夹";
                }
                else
                {
                    Tip_Lab.Text = "文件已存在！！";
                }
            }
        }

        private void About_m2_Click(object sender, EventArgs e)
        {
            new Help().ShowDialog(this);
        }
    }
}
