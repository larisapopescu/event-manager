using System.ComponentModel;

namespace mainfile;

partial class CreateEvent
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        textBox2 = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        textBox3 = new System.Windows.Forms.TextBox();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(36, 14);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(280, 30);
        label1.TabIndex = 0;
        label1.Text = "Let\'s create the event";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(12, 44);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(304, 30);
        label2.TabIndex = 1;
        label2.Text = "Name:";
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(12, 77);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Enter event\'s name";
        textBox1.Size = new System.Drawing.Size(313, 27);
        textBox1.TabIndex = 2;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.Location = new System.Drawing.Point(12, 107);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(304, 30);
        label3.TabIndex = 3;
        label3.Text = "Description:";
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(12, 129);
        textBox2.Name = "textBox2";
        textBox2.PlaceholderText = "Enter event\'s description";
        textBox2.Size = new System.Drawing.Size(313, 27);
        textBox2.TabIndex = 4;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.ForeColor = System.Drawing.Color.MidnightBlue;
        label4.Location = new System.Drawing.Point(12, 169);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(304, 30);
        label4.TabIndex = 5;
        label4.Text = "Location:";
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(13, 202);
        textBox3.Name = "textBox3";
        textBox3.PlaceholderText = "Enter event\'s location";
        textBox3.Size = new System.Drawing.Size(313, 27);
        textBox3.TabIndex = 6;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new System.Drawing.Point(12, 253);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(114, 27);
        dateTimePicker1.TabIndex = 7;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new System.Drawing.Point(13, 305);
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new System.Drawing.Size(89, 27);
        numericUpDown1.TabIndex = 8;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new System.Drawing.Point(18, 365);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(108, 64);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 9;
        pictureBox1.TabStop = false;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(156, 365);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(144, 60);
        button1.TabIndex = 10;
        button1.Text = "Import a picture";
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.Color.MidnightBlue;
        button2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button2.ForeColor = System.Drawing.Color.White;
        button2.Location = new System.Drawing.Point(57, 449);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(187, 72);
        button2.TabIndex = 11;
        button2.Text = "Create event";
        button2.UseVisualStyleBackColor = false;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(206, 566);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(120, 33);
        button3.TabIndex = 12;
        button3.Text = "Return to menu";
        button3.UseVisualStyleBackColor = true;
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.ForeColor = System.Drawing.Color.MidnightBlue;
        label5.Location = new System.Drawing.Point(151, 253);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(175, 30);
        label5.TabIndex = 13;
        label5.Text = "Choose event\'s date";
        // 
        // label6
        // 
        label6.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label6.ForeColor = System.Drawing.Color.MidnightBlue;
        label6.Location = new System.Drawing.Point(151, 302);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(175, 30);
        label6.TabIndex = 14;
        label6.Text = "Choose event\'s capacity";
        // 
        // CreateEvent
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(pictureBox1);
        Controls.Add(numericUpDown1);
        Controls.Add(dateTimePicker1);
        Controls.Add(textBox3);
        Controls.Add(label4);
        Controls.Add(textBox2);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "CreateEvent";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.NumericUpDown numericUpDown1;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    private System.Windows.Forms.TextBox textBox3;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}