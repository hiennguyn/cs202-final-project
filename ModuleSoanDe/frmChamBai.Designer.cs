
namespace ModuleSoanDe
{
    partial class frmChamBai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listviewScore = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbFile = new System.Windows.Forms.ListBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnChonFileDapAn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTinhDiem = new System.Windows.Forms.Button();
            this.btnInBangDiem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listviewScore
            // 
            this.listviewScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewScore.BackColor = System.Drawing.Color.GhostWhite;
            this.listviewScore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listviewScore.FullRowSelect = true;
            this.listviewScore.GridLines = true;
            this.listviewScore.HideSelection = false;
            this.listviewScore.Location = new System.Drawing.Point(392, 164);
            this.listviewScore.Name = "listviewScore";
            this.listviewScore.Size = new System.Drawing.Size(561, 284);
            this.listviewScore.TabIndex = 13;
            this.listviewScore.UseCompatibleStateImageBehavior = false;
            this.listviewScore.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Test ID";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 125;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Right Answer";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Score";
            this.columnHeader5.Width = 105;
            // 
            // lbFile
            // 
            this.lbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFile.FormattingEnabled = true;
            this.lbFile.ItemHeight = 20;
            this.lbFile.Location = new System.Drawing.Point(47, 164);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(285, 284);
            this.lbFile.TabIndex = 12;
            // 
            // btnTim
            // 
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(560, 39);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(180, 40);
            this.btnTim.TabIndex = 10;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderPath.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderPath.Location = new System.Drawing.Point(275, 39);
            this.txtFolderPath.Multiline = true;
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(251, 40);
            this.txtFolderPath.TabIndex = 9;
            this.txtFolderPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragDrop);
            this.txtFolderPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragEnter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(43, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Đường dẫn thư mục";
            // 
            // btnChonFileDapAn
            // 
            this.btnChonFileDapAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonFileDapAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.btnChonFileDapAn.FlatAppearance.BorderSize = 0;
            this.btnChonFileDapAn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnChonFileDapAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonFileDapAn.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonFileDapAn.ForeColor = System.Drawing.Color.White;
            this.btnChonFileDapAn.Location = new System.Drawing.Point(761, 39);
            this.btnChonFileDapAn.Name = "btnChonFileDapAn";
            this.btnChonFileDapAn.Size = new System.Drawing.Size(192, 40);
            this.btnChonFileDapAn.TabIndex = 10;
            this.btnChonFileDapAn.Text = "Chọn file đáp án";
            this.btnChonFileDapAn.UseVisualStyleBackColor = false;
            this.btnChonFileDapAn.Click += new System.EventHandler(this.btnChonFileDapAn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label1.Location = new System.Drawing.Point(43, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh sách file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.label2.Location = new System.Drawing.Point(388, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bảng điểm";
            // 
            // btnTinhDiem
            // 
            this.btnTinhDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTinhDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.btnTinhDiem.FlatAppearance.BorderSize = 0;
            this.btnTinhDiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnTinhDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhDiem.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhDiem.ForeColor = System.Drawing.Color.White;
            this.btnTinhDiem.Location = new System.Drawing.Point(47, 495);
            this.btnTinhDiem.Name = "btnTinhDiem";
            this.btnTinhDiem.Size = new System.Drawing.Size(180, 40);
            this.btnTinhDiem.TabIndex = 10;
            this.btnTinhDiem.Text = "Tính điểm";
            this.btnTinhDiem.UseVisualStyleBackColor = false;
            this.btnTinhDiem.Click += new System.EventHandler(this.btnTinhDiem_Click);
            // 
            // btnInBangDiem
            // 
            this.btnInBangDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInBangDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(78)))));
            this.btnInBangDiem.FlatAppearance.BorderSize = 0;
            this.btnInBangDiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnInBangDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBangDiem.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBangDiem.ForeColor = System.Drawing.Color.White;
            this.btnInBangDiem.Location = new System.Drawing.Point(773, 495);
            this.btnInBangDiem.Name = "btnInBangDiem";
            this.btnInBangDiem.Size = new System.Drawing.Size(180, 40);
            this.btnInBangDiem.TabIndex = 10;
            this.btnInBangDiem.Text = "In bảng điểm";
            this.btnInBangDiem.UseVisualStyleBackColor = false;
            this.btnInBangDiem.Click += new System.EventHandler(this.btnInBangDiem_Click);
            // 
            // frmChamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1057, 627);
            this.Controls.Add(this.listviewScore);
            this.Controls.Add(this.lbFile);
            this.Controls.Add(this.btnChonFileDapAn);
            this.Controls.Add(this.btnInBangDiem);
            this.Controls.Add(this.btnTinhDiem);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Name = "frmChamBai";
            this.Text = "frmChamBai";
            this.Load += new System.EventHandler(this.frmChamBai_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listviewScore;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListBox lbFile;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnChonFileDapAn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTinhDiem;
        private System.Windows.Forms.Button btnInBangDiem;
    }
}