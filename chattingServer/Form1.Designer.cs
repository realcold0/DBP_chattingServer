namespace chattingServer
{
    partial class ChatServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myConsole = new System.Windows.Forms.RichTextBox();
            this.ClientList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ControlInput = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SendNoticeAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myConsole
            // 
            this.myConsole.Location = new System.Drawing.Point(13, 16);
            this.myConsole.Margin = new System.Windows.Forms.Padding(4);
            this.myConsole.Name = "myConsole";
            this.myConsole.Size = new System.Drawing.Size(350, 288);
            this.myConsole.TabIndex = 0;
            this.myConsole.Text = "";
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.ItemHeight = 20;
            this.ClientList.Location = new System.Drawing.Point(381, 40);
            this.ClientList.Margin = new System.Windows.Forms.Padding(4);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(155, 264);
            this.ClientList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "참여자";
            // 
            // ControlInput
            // 
            this.ControlInput.Location = new System.Drawing.Point(13, 312);
            this.ControlInput.Margin = new System.Windows.Forms.Padding(4);
            this.ControlInput.Name = "ControlInput";
            this.ControlInput.Size = new System.Drawing.Size(350, 27);
            this.ControlInput.TabIndex = 3;
            this.ControlInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlInput_KeyDown);
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(381, 312);
            this.Enter.Margin = new System.Windows.Forms.Padding(4);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(155, 27);
            this.Enter.TabIndex = 4;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.ControlEnter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 397);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 27);
            this.textBox1.TabIndex = 5;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendNoticeTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "전체 공지";
            // 
            // SendNoticeAll
            // 
            this.SendNoticeAll.Location = new System.Drawing.Point(381, 397);
            this.SendNoticeAll.Name = "SendNoticeAll";
            this.SendNoticeAll.Size = new System.Drawing.Size(155, 27);
            this.SendNoticeAll.TabIndex = 7;
            this.SendNoticeAll.Text = "공지하기";
            this.SendNoticeAll.UseVisualStyleBackColor = true;
            this.SendNoticeAll.Click += new System.EventHandler(this.SendNoticeAll_Func);
            // 
            // ChatServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 436);
            this.Controls.Add(this.SendNoticeAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.ControlInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.myConsole);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatServerForm";
            this.Text = "ChatServerForm";
            this.Load += new System.EventHandler(this.ChatServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox myConsole;
        private ListBox ClientList;
        private Label label1;
        private TextBox ControlInput;
        private Button Enter;
        private TextBox textBox1;
        private Label label2;
        private Button SendNoticeAll;
    }
}