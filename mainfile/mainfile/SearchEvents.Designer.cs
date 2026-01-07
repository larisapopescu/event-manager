using System.ComponentModel;

namespace mainfile;

partial class SearchEvents
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
        button5 = new System.Windows.Forms.Button();
        comboBox1 = new System.Windows.Forms.ComboBox();
        textBox1 = new System.Windows.Forms.TextBox();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        button1 = new System.Windows.Forms.Button();
        listBox1 = new System.Windows.Forms.ListBox();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        label2 = new System.Windows.Forms.Label();
        button2 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(6, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(323, 36);
        label1.TabIndex = 0;
        label1.Text = "Search event by:";
        // 
        // button5
        // 
        button5.Location = new System.Drawing.Point(206, 575);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(123, 25);
        button5.TabIndex = 5;
        button5.Text = "Return to menu";
        button5.UseVisualStyleBackColor = true;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(12, 65);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(175, 28);
        comboBox1.TabIndex = 6;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(13, 116);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Enter text here";
        textBox1.Size = new System.Drawing.Size(160, 27);
        textBox1.TabIndex = 7;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new System.Drawing.Point(206, 116);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(122, 27);
        dateTimePicker1.TabIndex = 8;
        dateTimePicker1.Visible = false;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(12, 158);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(147, 33);
        button1.TabIndex = 9;
        button1.Text = "Search event";
        button1.UseVisualStyleBackColor = false;
        // 
        // listBox1
        // 
        listBox1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        listBox1.ForeColor = System.Drawing.Color.MidnightBlue;
        listBox1.FormattingEnabled = true;
        listBox1.Location = new System.Drawing.Point(13, 210);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(221, 64);
        listBox1.TabIndex = 10;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new System.Drawing.Point(13, 280);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(221, 139);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 11;
        pictureBox1.TabStop = false;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(8, 435);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(319, 137);
        label2.TabIndex = 12;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.Color.MidnightBlue;
        button2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button2.ForeColor = System.Drawing.Color.White;
        button2.Location = new System.Drawing.Point(179, 158);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(147, 33);
        button2.TabIndex = 13;
        button2.Text = "View details";
        button2.UseVisualStyleBackColor = false;
        // 
        // SearchEvents
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button2);
        Controls.Add(label2);
        Controls.Add(pictureBox1);
        Controls.Add(listBox1);
        Controls.Add(button1);
        Controls.Add(dateTimePicker1);
        Controls.Add(textBox1);
        Controls.Add(comboBox1);
        Controls.Add(button5);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "SearchEvents";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Button button5;

    private System.Windows.Forms.Label label1;

    #endregion
}