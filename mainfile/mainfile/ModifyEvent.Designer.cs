using System.ComponentModel;

namespace mainfile;

partial class ModifyEvent
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
        comboBox1 = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        textBox2 = new System.Windows.Forms.TextBox();
        textBox3 = new System.Windows.Forms.TextBox();
        label5 = new System.Windows.Forms.Label();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        label6 = new System.Windows.Forms.Label();
        numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        label7 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(12, 79);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(114, 28);
        comboBox1.TabIndex = 0;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(33, 22);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(270, 45);
        label1.TabIndex = 1;
        label1.Text = "Let\'s modify the event";
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(12, 142);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Choose a new name for your event";
        textBox1.Size = new System.Drawing.Size(314, 27);
        textBox1.TabIndex = 2;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(132, 79);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(183, 28);
        label2.TabIndex = 3;
        label2.Text = "Choose an event to modify";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.Location = new System.Drawing.Point(12, 111);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(328, 28);
        label3.TabIndex = 4;
        label3.Text = "New name(leave empty if you dont want to change):";
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.ForeColor = System.Drawing.Color.MidnightBlue;
        label4.Location = new System.Drawing.Point(12, 182);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(376, 28);
        label4.TabIndex = 5;
        label4.Text = "New description(leave empty if you dont want to change):";
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(12, 213);
        textBox2.Name = "textBox2";
        textBox2.PlaceholderText = "Choose a new description for your event";
        textBox2.Size = new System.Drawing.Size(314, 27);
        textBox2.TabIndex = 6;
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(12, 280);
        textBox3.Name = "textBox3";
        textBox3.PlaceholderText = "Choose a new location for your event";
        textBox3.Size = new System.Drawing.Size(314, 27);
        textBox3.TabIndex = 7;
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.ForeColor = System.Drawing.Color.MidnightBlue;
        label5.Location = new System.Drawing.Point(12, 249);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(328, 28);
        label5.TabIndex = 8;
        label5.Text = "New location(leave empty if you dont want to change):";
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new System.Drawing.Point(12, 360);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(133, 27);
        dateTimePicker1.TabIndex = 9;
        // 
        // label6
        // 
        label6.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label6.ForeColor = System.Drawing.Color.MidnightBlue;
        label6.Location = new System.Drawing.Point(12, 329);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(328, 28);
        label6.TabIndex = 10;
        label6.Text = "New date(leave empty if you dont want to change):";
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new System.Drawing.Point(12, 429);
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new System.Drawing.Size(143, 27);
        numericUpDown1.TabIndex = 11;
        // 
        // label7
        // 
        label7.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label7.ForeColor = System.Drawing.Color.MidnightBlue;
        label7.Location = new System.Drawing.Point(12, 398);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(328, 28);
        label7.TabIndex = 12;
        label7.Text = "New capacity(leave empty if you dont want to change):";
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(12, 482);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(143, 54);
        button1.TabIndex = 13;
        button1.Text = "Save changes";
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.Color.MidnightBlue;
        button2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button2.ForeColor = System.Drawing.Color.White;
        button2.Location = new System.Drawing.Point(172, 482);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(143, 54);
        button2.TabIndex = 14;
        button2.Text = "Cancel changes";
        button2.UseVisualStyleBackColor = false;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(204, 572);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(122, 27);
        button3.TabIndex = 15;
        button3.Text = "Return to menu";
        button3.UseVisualStyleBackColor = true;
        // 
        // ModifyEvent
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label7);
        Controls.Add(numericUpDown1);
        Controls.Add(label6);
        Controls.Add(dateTimePicker1);
        Controls.Add(label5);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Controls.Add(comboBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ModifyEvent";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label1;

    #endregion
}