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
            this.SuspendLayout();
            // 
            // myConsole
            // 
            this.myConsole.Location = new System.Drawing.Point(15, 16);
            this.myConsole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myConsole.Name = "myConsole";
            this.myConsole.Size = new System.Drawing.Size(349, 280);
            this.myConsole.TabIndex = 0;
            this.myConsole.Text = "";
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.ItemHeight = 20;
            this.ClientList.Location = new System.Drawing.Point(373, 52);
            this.ClientList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(153, 244);
            this.ClientList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "참여자";
            // 
            // ControlInput
            // 
            this.ControlInput.Location = new System.Drawing.Point(15, 305);
            this.ControlInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ControlInput.Name = "ControlInput";
            this.ControlInput.Size = new System.Drawing.Size(349, 27);
            this.ControlInput.TabIndex = 3;
            this.ControlInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlInput_KeyDown);
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(373, 305);
            this.Enter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(154, 31);
            this.Enter.TabIndex = 4;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.ControlEnter);
            // 
            // ChatServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 355);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.ControlInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.myConsole);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChatServerForm";
            this.Text = "ChatServerForm";
            this.Load += new System.EventHandler(this.ChatServerForm_Load);
            this.Click += new System.EventHandler(this.ControlEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox myConsole;
        private ListBox ClientList;
        private Label label1;
        private TextBox ControlInput;
        private Button Enter;
    }
}