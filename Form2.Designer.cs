namespace WinFormsApp4
{
    partial class Form2
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
            loadButton = new Button();
            listBox1 = new ListBox();
            closeButton = new Button();
            refreshButton = new Button();
            richTextBox1 = new RichTextBox();
            msgLabel = new Label();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.Location = new Point(18, 252);
            loadButton.Margin = new Padding(1, 1, 1, 1);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(77, 21);
            loadButton.TabIndex = 0;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(18, 16);
            listBox1.Margin = new Padding(1, 1, 1, 1);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(237, 229);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(478, 252);
            closeButton.Margin = new Padding(1, 1, 1, 1);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(77, 21);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(106, 252);
            refreshButton.Margin = new Padding(1, 1, 1, 1);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(147, 21);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh Scenarios";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(268, 16);
            richTextBox1.Margin = new Padding(1, 1, 1, 1);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(290, 228);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // msgLabel
            // 
            msgLabel.AutoSize = true;
            msgLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            msgLabel.Location = new Point(268, 258);
            msgLabel.Margin = new Padding(1, 0, 1, 0);
            msgLabel.Name = "msgLabel";
            msgLabel.Size = new Size(40, 15);
            msgLabel.TabIndex = 5;
            msgLabel.Text = "label1";
            msgLabel.Visible = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 300);
            Controls.Add(msgLabel);
            Controls.Add(richTextBox1);
            Controls.Add(refreshButton);
            Controls.Add(closeButton);
            Controls.Add(listBox1);
            Controls.Add(loadButton);
            Margin = new Padding(1, 1, 1, 1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Load Scenario";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadButton;
        private ListBox listBox1;
        private Button closeButton;
        private Button refreshButton;
        private RichTextBox richTextBox1;
        private Label msgLabel;
    }
}