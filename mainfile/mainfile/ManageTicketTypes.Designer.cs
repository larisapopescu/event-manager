using System.ComponentModel;

namespace mainfile;

partial class ManageTicketTypes
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
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        comboBox2 = new System.Windows.Forms.ComboBox();
        numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        numericUpDown2 = new System.Windows.Forms.NumericUpDown();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        lblEventInfo = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(12, 100);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(138, 28);
        comboBox1.TabIndex = 0;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(27, 19);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(272, 45);
        label1.TabIndex = 1;
        label1.Text = "Manage ticket types";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(12, 64);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(138, 24);
        label2.TabIndex = 2;
        label2.Text = "Choose an event";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.Location = new System.Drawing.Point(12, 272);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(253, 24);
        label3.TabIndex = 3;
        label3.Text = "Choose ticket type";
        // 
        // comboBox2
        // 
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new System.Drawing.Point(12, 299);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new System.Drawing.Size(138, 28);
        comboBox2.TabIndex = 4;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new System.Drawing.Point(12, 384);
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new System.Drawing.Size(138, 27);
        numericUpDown1.TabIndex = 5;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.ForeColor = System.Drawing.Color.MidnightBlue;
        label4.Location = new System.Drawing.Point(12, 342);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(253, 24);
        label4.TabIndex = 6;
        label4.Text = "Choose number of tickets\r\n";
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.ForeColor = System.Drawing.Color.MidnightBlue;
        label5.Location = new System.Drawing.Point(12, 414);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(253, 24);
        label5.TabIndex = 7;
        label5.Text = "Choose price of the  ticket\r\n";
        // 
        // numericUpDown2
        // 
        numericUpDown2.Location = new System.Drawing.Point(12, 456);
        numericUpDown2.Name = "numericUpDown2";
        numericUpDown2.Size = new System.Drawing.Size(138, 27);
        numericUpDown2.TabIndex = 8;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(88, 489);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(138, 76);
        button1.TabIndex = 9;
        button1.Text = "Save ticket/s";
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(207, 571);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(119, 28);
        button2.TabIndex = 10;
        button2.Text = "Return to menu";
        button2.UseVisualStyleBackColor = true;
        // 
        // lblEventInfo
        // 
        lblEventInfo.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblEventInfo.ForeColor = System.Drawing.Color.MidnightBlue;
        lblEventInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        lblEventInfo.Location = new System.Drawing.Point(4, 131);
        lblEventInfo.Name = "lblEventInfo";
        lblEventInfo.Size = new System.Drawing.Size(331, 127);
        lblEventInfo.TabIndex = 11;
        // 
        // ManageTicketTypes
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(lblEventInfo);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(numericUpDown2);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(numericUpDown1);
        Controls.Add(comboBox2);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(comboBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ManageTicketTypes";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblEventInfo;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown numericUpDown2;
    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.NumericUpDown numericUpDown1;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboBox2;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ComboBox comboBox1;

    #endregion
}