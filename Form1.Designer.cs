namespace WinFormsApp4
{
    partial class Form1
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
            comboBox1 = new ComboBox();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar4 = new TrackBar();
            trackBar5 = new TrackBar();
            trackBar3 = new TrackBar();
            trackBar6 = new TrackBar();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            brgLabel = new Label();
            tempLabel = new Label();
            redLabel = new Label();
            greenLabel = new Label();
            blueLabel = new Label();
            whiteLabel = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            button8 = new Button();
            button5 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label9 = new Label();
            button2 = new Button();
            label8 = new Label();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            button7 = new Button();
            button6 = new Button();
            groupBox3 = new GroupBox();
            button3 = new Button();
            groupBox4 = new GroupBox();
            label12 = new Label();
            label11 = new Label();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            groupBox5 = new GroupBox();
            label13 = new Label();
            button9 = new Button();
            label10 = new Label();
            trackBar7 = new TrackBar();
            comboBox2 = new ComboBox();
            label3 = new Label();
            groupBox6 = new GroupBox();
            checkBox1 = new CheckBox();
            groupBox7 = new GroupBox();
            richTextBox1 = new RichTextBox();
            label14 = new Label();
            comboBox3 = new ComboBox();
            colorDialog1 = new ColorDialog();
            groupBox8 = new GroupBox();
            richTextBox2 = new RichTextBox();
            checkBox2 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar7).BeginInit();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1254, 560);
            comboBox1.Margin = new Padding(2, 3, 2, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(790, 49);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(85, 87);
            trackBar1.Margin = new Padding(2, 3, 2, 3);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 10;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(724, 114);
            trackBar1.SmallChange = 5;
            trackBar1.TabIndex = 4;
            trackBar1.Value = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // trackBar2
            // 
            trackBar2.LargeChange = 1;
            trackBar2.Location = new Point(85, 85);
            trackBar2.Margin = new Padding(2, 3, 2, 3);
            trackBar2.Maximum = 65;
            trackBar2.Minimum = 22;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(724, 114);
            trackBar2.TabIndex = 6;
            trackBar2.Value = 22;
            trackBar2.Scroll += trackBar2_Scroll;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(83, 205);
            trackBar4.Margin = new Padding(2, 3, 2, 3);
            trackBar4.Maximum = 255;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(724, 114);
            trackBar4.TabIndex = 9;
            trackBar4.ValueChanged += trackBar4_ValueChanged;
            // 
            // trackBar5
            // 
            trackBar5.Location = new Point(85, 325);
            trackBar5.Margin = new Padding(2, 3, 2, 3);
            trackBar5.Maximum = 255;
            trackBar5.Name = "trackBar5";
            trackBar5.Size = new Size(724, 114);
            trackBar5.TabIndex = 10;
            trackBar5.ValueChanged += trackBar5_ValueChanged;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(83, 96);
            trackBar3.Margin = new Padding(2, 3, 2, 3);
            trackBar3.Maximum = 255;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(724, 114);
            trackBar3.TabIndex = 8;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // trackBar6
            // 
            trackBar6.Location = new Point(85, 446);
            trackBar6.Margin = new Padding(2, 3, 2, 3);
            trackBar6.Maximum = 255;
            trackBar6.Name = "trackBar6";
            trackBar6.Size = new Size(724, 114);
            trackBar6.TabIndex = 11;
            trackBar6.ValueChanged += trackBar6_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1077, 563);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 41);
            label1.TabIndex = 7;
            label1.Text = "Select Bulb:";
            label1.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(39, 96);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(38, 41);
            label4.TabIndex = 10;
            label4.Text = "R";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Green;
            label5.Location = new Point(39, 205);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(39, 41);
            label5.TabIndex = 11;
            label5.Text = "G";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Blue;
            label6.Location = new Point(39, 336);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(37, 41);
            label6.TabIndex = 12;
            label6.Text = "B";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(39, 446);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(48, 41);
            label7.TabIndex = 13;
            label7.Text = "W";
            // 
            // brgLabel
            // 
            brgLabel.AutoSize = true;
            brgLabel.Location = new Point(828, 87);
            brgLabel.Margin = new Padding(2, 0, 2, 0);
            brgLabel.Name = "brgLabel";
            brgLabel.Size = new Size(97, 41);
            brgLabel.TabIndex = 14;
            brgLabel.Text = "label8";
            // 
            // tempLabel
            // 
            tempLabel.AutoSize = true;
            tempLabel.Location = new Point(828, 85);
            tempLabel.Margin = new Padding(2, 0, 2, 0);
            tempLabel.Name = "tempLabel";
            tempLabel.Size = new Size(97, 41);
            tempLabel.TabIndex = 15;
            tempLabel.Text = "label9";
            // 
            // redLabel
            // 
            redLabel.AutoSize = true;
            redLabel.Location = new Point(809, 96);
            redLabel.Margin = new Padding(2, 0, 2, 0);
            redLabel.Name = "redLabel";
            redLabel.Size = new Size(113, 41);
            redLabel.TabIndex = 16;
            redLabel.Text = "label10";
            // 
            // greenLabel
            // 
            greenLabel.AutoSize = true;
            greenLabel.Location = new Point(811, 205);
            greenLabel.Margin = new Padding(2, 0, 2, 0);
            greenLabel.Name = "greenLabel";
            greenLabel.Size = new Size(113, 41);
            greenLabel.TabIndex = 17;
            greenLabel.Text = "label11";
            // 
            // blueLabel
            // 
            blueLabel.AutoSize = true;
            blueLabel.Location = new Point(811, 312);
            blueLabel.Margin = new Padding(2, 0, 2, 0);
            blueLabel.Name = "blueLabel";
            blueLabel.Size = new Size(113, 41);
            blueLabel.TabIndex = 18;
            blueLabel.Text = "label12";
            // 
            // whiteLabel
            // 
            whiteLabel.AutoSize = true;
            whiteLabel.Location = new Point(811, 446);
            whiteLabel.Margin = new Padding(2, 0, 2, 0);
            whiteLabel.Name = "whiteLabel";
            whiteLabel.Size = new Size(113, 41);
            whiteLabel.TabIndex = 19;
            whiteLabel.Text = "label13";
            // 
            // button1
            // 
            button1.Location = new Point(85, 208);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(197, 60);
            button1.TabIndex = 5;
            button1.Text = "Set";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(1077, 41);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(967, 488);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New Bulb";
            // 
            // button8
            // 
            button8.Location = new Point(675, 270);
            button8.Margin = new Padding(2, 3, 2, 3);
            button8.Name = "button8";
            button8.Size = new Size(187, 57);
            button8.TabIndex = 7;
            button8.Text = "Remove";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button5
            // 
            button5.Location = new Point(347, 270);
            button5.Margin = new Padding(2, 3, 2, 3);
            button5.Name = "button5";
            button5.Size = new Size(243, 57);
            button5.TabIndex = 6;
            button5.Text = "Auto Scan";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 177);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 41);
            label2.TabIndex = 5;
            label2.Text = "Alias:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(121, 174);
            textBox2.Margin = new Padding(2, 3, 2, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(740, 47);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Green;
            label9.Location = new Point(121, 357);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(270, 41);
            label9.TabIndex = 3;
            label9.Text = "Bulb Added to List";
            label9.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(121, 270);
            button2.Margin = new Padding(2, 3, 2, 3);
            button2.Name = "button2";
            button2.Size = new Size(187, 57);
            button2.TabIndex = 2;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(56, 92);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(50, 41);
            label8.TabIndex = 1;
            label8.Text = "IP:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(121, 87);
            textBox1.Margin = new Padding(2, 3, 2, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(740, 47);
            textBox1.TabIndex = 0;
            textBox1.Text = "192.168.";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button7);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Controls.Add(brgLabel);
            groupBox2.Controls.Add(button1);
            groupBox2.Location = new Point(56, 41);
            groupBox2.Margin = new Padding(2, 3, 2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 3, 2, 3);
            groupBox2.Size = new Size(979, 295);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Brightness";
            // 
            // button7
            // 
            button7.Location = new Point(527, 208);
            button7.Margin = new Padding(2, 3, 2, 3);
            button7.Name = "button7";
            button7.Size = new Size(187, 57);
            button7.TabIndex = 16;
            button7.Text = "Turn On";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(733, 208);
            button6.Margin = new Padding(2, 3, 2, 3);
            button6.Name = "button6";
            button6.Size = new Size(187, 57);
            button6.TabIndex = 15;
            button6.Text = "Turn Off";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(trackBar2);
            groupBox3.Controls.Add(tempLabel);
            groupBox3.Location = new Point(56, 358);
            groupBox3.Margin = new Padding(2, 3, 2, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2, 3, 2, 3);
            groupBox3.Size = new Size(979, 295);
            groupBox3.TabIndex = 23;
            groupBox3.TabStop = false;
            groupBox3.Text = "Temperature";
            // 
            // button3
            // 
            button3.Location = new Point(85, 191);
            button3.Margin = new Padding(2, 3, 2, 3);
            button3.Name = "button3";
            button3.Size = new Size(197, 60);
            button3.TabIndex = 7;
            button3.Text = "Set";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(pictureBox1);
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(trackBar3);
            groupBox4.Controls.Add(trackBar4);
            groupBox4.Controls.Add(trackBar5);
            groupBox4.Controls.Add(trackBar6);
            groupBox4.Controls.Add(whiteLabel);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(blueLabel);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(greenLabel);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(redLabel);
            groupBox4.Controls.Add(label7);
            groupBox4.Location = new Point(56, 694);
            groupBox4.Margin = new Padding(2, 3, 2, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(2, 3, 2, 3);
            groupBox4.Size = new Size(979, 700);
            groupBox4.TabIndex = 24;
            groupBox4.TabStop = false;
            groupBox4.Text = "Color";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(576, 588);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(79, 41);
            label12.TabIndex = 22;
            label12.Text = "Hue:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(542, 629);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(113, 41);
            label11.TabIndex = 21;
            label11.Text = "label11";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(680, 566);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(243, 101);
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(85, 607);
            button4.Margin = new Padding(2, 3, 2, 3);
            button4.Name = "button4";
            button4.Size = new Size(197, 60);
            button4.TabIndex = 12;
            button4.Text = "Set";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label13);
            groupBox5.Controls.Add(button9);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(trackBar7);
            groupBox5.Controls.Add(comboBox2);
            groupBox5.Controls.Add(label3);
            groupBox5.Location = new Point(1077, 648);
            groupBox5.Margin = new Padding(2, 3, 2, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(2, 3, 2, 3);
            groupBox5.Size = new Size(967, 347);
            groupBox5.TabIndex = 25;
            groupBox5.TabStop = false;
            groupBox5.Text = "Scenes";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(848, 169);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(113, 41);
            label13.TabIndex = 5;
            label13.Text = "label13";
            // 
            // button9
            // 
            button9.Location = new Point(75, 262);
            button9.Margin = new Padding(2, 3, 2, 3);
            button9.Name = "button9";
            button9.Size = new Size(187, 57);
            button9.TabIndex = 4;
            button9.Text = "Set";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(75, 169);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(109, 41);
            label10.TabIndex = 3;
            label10.Text = "Speed:";
            // 
            // trackBar7
            // 
            trackBar7.LargeChange = 20;
            trackBar7.Location = new Point(197, 169);
            trackBar7.Margin = new Padding(2, 3, 2, 3);
            trackBar7.Maximum = 200;
            trackBar7.Minimum = 10;
            trackBar7.Name = "trackBar7";
            trackBar7.Size = new Size(651, 114);
            trackBar7.SmallChange = 10;
            trackBar7.TabIndex = 2;
            trackBar7.Value = 10;
            trackBar7.ValueChanged += trackBar7_ValueChanged;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(197, 90);
            comboBox2.Margin = new Padding(2, 3, 2, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(694, 49);
            comboBox2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 93);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 41);
            label3.TabIndex = 0;
            label3.Text = "Scene:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(checkBox2);
            groupBox6.Controls.Add(checkBox1);
            groupBox6.Location = new Point(1077, 1020);
            groupBox6.Margin = new Padding(2, 3, 2, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(2, 3, 2, 3);
            groupBox6.Size = new Size(967, 372);
            groupBox6.TabIndex = 26;
            groupBox6.TabStop = false;
            groupBox6.Text = "Settings";
            groupBox6.Enter += groupBox6_Enter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(46, 71);
            checkBox1.Margin = new Padding(7, 8, 7, 8);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(285, 45);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Immediate Mode";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(richTextBox1);
            groupBox7.Controls.Add(label14);
            groupBox7.Controls.Add(comboBox3);
            groupBox7.Location = new Point(2078, 41);
            groupBox7.Name = "groupBox7";
            groupBox7.RightToLeft = RightToLeft.No;
            groupBox7.Size = new Size(746, 615);
            groupBox7.TabIndex = 27;
            groupBox7.TabStop = false;
            groupBox7.Text = "Groups";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(26, 197);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(683, 385);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(26, 57);
            label14.Name = "label14";
            label14.Size = new Size(196, 41);
            label14.TabIndex = 1;
            label14.Text = "Select Group:";
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(24, 124);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(685, 49);
            comboBox3.TabIndex = 0;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(richTextBox2);
            groupBox8.Location = new Point(2078, 681);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(746, 713);
            groupBox8.TabIndex = 28;
            groupBox8.TabStop = false;
            groupBox8.Text = "State";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(24, 74);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(695, 613);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = "";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(46, 127);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(375, 45);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Sync State with Controls";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(2858, 1421);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "WiZ Connected Client";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar7).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar4;
        private TrackBar trackBar5;
        private TrackBar trackBar3;
        private TrackBar trackBar6;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label brgLabel;
        private Label tempLabel;
        private Label redLabel;
        private Label greenLabel;
        private Label blueLabel;
        private Label whiteLabel;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private Label label8;
        private TextBox textBox1;
        private Label label9;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button button3;
        private GroupBox groupBox4;
        private Button button4;
        private Label label2;
        private TextBox textBox2;
        private Button button5;
        private GroupBox groupBox5;
        private Label label10;
        private TrackBar trackBar7;
        private ComboBox comboBox2;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label11;
        private Label label12;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private GroupBox groupBox6;
        private Label label13;
        private CheckBox checkBox1;
        private GroupBox groupBox7;
        private Label label14;
        private ComboBox comboBox3;
        private RichTextBox richTextBox1;
        private ColorDialog colorDialog1;
        private GroupBox groupBox8;
        private RichTextBox richTextBox2;
        private CheckBox checkBox2;
    }
}