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
            this.myConsole.Location = new System.Drawing.Point(12, 12);
            this.myConsole.Name = "myConsole";
            this.myConsole.Size = new System.Drawing.Size(272, 211);
            this.myConsole.TabIndex = 0;
            this.myConsole.Text = "";
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.ItemHeight = 15;
            this.ClientList.Location = new System.Drawing.Point(290, 39);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(120, 184);
            this.ClientList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "참여자";
            // 
            // ControlInput
            // 
            this.ControlInput.Location = new System.Drawing.Point(12, 229);
            this.ControlInput.Name = "ControlInput";
            this.ControlInput.Size = new System.Drawing.Size(272, 23);
            this.ControlInput.TabIndex = 3;
            this.ControlInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlInput_KeyDown);
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(290, 229);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(120, 23);
            this.Enter.TabIndex = 4;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            // 
            // ChatServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 266);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.ControlInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.myConsole);
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
    }
}