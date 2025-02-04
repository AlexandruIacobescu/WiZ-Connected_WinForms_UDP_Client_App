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
            loadButton.Location = new Point(44, 688);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(188, 58);
            loadButton.TabIndex = 0;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 41;
            listBox1.Location = new Point(44, 45);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(571, 619);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(1160, 688);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(188, 58);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(258, 688);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(358, 58);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh Scenarios";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(650, 45);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(698, 617);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // msgLabel
            // 
            msgLabel.AutoSize = true;
            msgLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            msgLabel.Location = new Point(650, 705);
            msgLabel.Name = "msgLabel";
            msgLabel.Size = new Size(104, 41);
            msgLabel.TabIndex = 5;
            msgLabel.Text = "label1";
            msgLabel.Visible = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 819);
            Controls.Add(msgLabel);
            Controls.Add(richTextBox1);
            Controls.Add(refreshButton);
            Controls.Add(closeButton);
            Controls.Add(listBox1);
            Controls.Add(loadButton);
            Name = "Form2";
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