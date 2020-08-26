namespace UnityPackageTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File_m1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile_m2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_m1 = new System.Windows.Forms.ToolStripMenuItem();
            this.About_m2 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MenuTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Img_Box = new System.Windows.Forms.PictureBox();
            this.Content_rt = new System.Windows.Forms.RichTextBox();
            this.Tip_Lab = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveFile_ts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Box)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_m1,
            this.Help_m1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File_m1
            // 
            this.File_m1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile_m2});
            this.File_m1.Name = "File_m1";
            this.File_m1.Size = new System.Drawing.Size(44, 21);
            this.File_m1.Text = "文件";
            // 
            // OpenFile_m2
            // 
            this.OpenFile_m2.Name = "OpenFile_m2";
            this.OpenFile_m2.Size = new System.Drawing.Size(100, 22);
            this.OpenFile_m2.Text = "打开";
            this.OpenFile_m2.Click += new System.EventHandler(this.OpenFile_m2_Click);
            // 
            // Help_m1
            // 
            this.Help_m1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About_m2});
            this.Help_m1.Name = "Help_m1";
            this.Help_m1.Size = new System.Drawing.Size(44, 21);
            this.Help_m1.Text = "帮助";
            // 
            // About_m2
            // 
            this.About_m2.Name = "About_m2";
            this.About_m2.Size = new System.Drawing.Size(100, 22);
            this.About_m2.Text = "关于";
            this.About_m2.Click += new System.EventHandler(this.About_m2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MenuTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(560, 408);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 5;
            // 
            // MenuTree
            // 
            this.MenuTree.AllowDrop = true;
            this.MenuTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuTree.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuTree.ImageIndex = 0;
            this.MenuTree.ImageList = this.imageList1;
            this.MenuTree.Location = new System.Drawing.Point(2, 2);
            this.MenuTree.Name = "MenuTree";
            this.MenuTree.SelectedImageIndex = 0;
            this.MenuTree.Size = new System.Drawing.Size(180, 400);
            this.MenuTree.TabIndex = 0;
            this.MenuTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MenuTree_NodeMouseClick);
            this.MenuTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.MenuTree_DragDrop);
            this.MenuTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.MenuTree_DragEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "i_folder");
            this.imageList1.Images.SetKeyName(1, "i_music");
            this.imageList1.Images.SetKeyName(2, "i_video");
            this.imageList1.Images.SetKeyName(3, "i_js");
            this.imageList1.Images.SetKeyName(4, "i_dll");
            this.imageList1.Images.SetKeyName(5, "i_cs");
            this.imageList1.Images.SetKeyName(6, "i_unity");
            this.imageList1.Images.SetKeyName(7, "i_fbx");
            this.imageList1.Images.SetKeyName(8, "i_img");
            this.imageList1.Images.SetKeyName(9, "i_unknow");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Img_Box);
            this.panel1.Controls.Add(this.Content_rt);
            this.panel1.Location = new System.Drawing.Point(-1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 402);
            this.panel1.TabIndex = 1;
            // 
            // Img_Box
            // 
            this.Img_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Img_Box.Location = new System.Drawing.Point(0, 0);
            this.Img_Box.Name = "Img_Box";
            this.Img_Box.Size = new System.Drawing.Size(365, 400);
            this.Img_Box.TabIndex = 1;
            this.Img_Box.TabStop = false;
            // 
            // Content_rt
            // 
            this.Content_rt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content_rt.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Content_rt.Location = new System.Drawing.Point(0, 0);
            this.Content_rt.Name = "Content_rt";
            this.Content_rt.ReadOnly = true;
            this.Content_rt.Size = new System.Drawing.Size(365, 400);
            this.Content_rt.TabIndex = 0;
            this.Content_rt.Text = "";
            // 
            // Tip_Lab
            // 
            this.Tip_Lab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Tip_Lab.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tip_Lab.Location = new System.Drawing.Point(12, 439);
            this.Tip_Lab.Name = "Tip_Lab";
            this.Tip_Lab.Size = new System.Drawing.Size(550, 20);
            this.Tip_Lab.TabIndex = 6;
            this.Tip_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveFile_ts});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // SaveFile_ts
            // 
            this.SaveFile_ts.Name = "SaveFile_ts";
            this.SaveFile_ts.Size = new System.Drawing.Size(100, 22);
            this.SaveFile_ts.Text = "保存";
            this.SaveFile_ts.Click += new System.EventHandler(this.SaveFile_ts_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.Tip_Lab);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UnityPackage查看器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Img_Box)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File_m1;
        private System.Windows.Forms.ToolStripMenuItem OpenFile_m2;
        private System.Windows.Forms.ToolStripMenuItem Help_m1;
        private System.Windows.Forms.ToolStripMenuItem About_m2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView MenuTree;
        private System.Windows.Forms.RichTextBox Content_rt;
        private System.Windows.Forms.Label Tip_Lab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Img_Box;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SaveFile_ts;
    }
}

