using System.ComponentModel;

namespace mainfile;

partial class BuyingTickets
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
        comboBox1 = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        comboBox2 = new System.Windows.Forms.ComboBox();
        numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        label4 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(32, 26);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(277, 35);
        label1.TabIndex = 0;
        label1.Text = "Buy tickets";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(22, 108);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(199, 28);
        comboBox1.TabIndex = 1;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(12, 70);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(277, 35);
        label2.TabIndex = 2;
        label2.Text = "Choose an event";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.Location = new System.Drawing.Point(8, 180);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(277, 35);
        label3.TabIndex = 3;
        label3.Text = "Choose ticket\'s type";
        // 
        // comboBox2
        // 
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new System.Drawing.Point(22, 218);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new System.Drawing.Size(199, 28);
        comboBox2.TabIndex = 4;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new System.Drawing.Point(32, 348);
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new System.Drawing.Size(142, 27);
        numericUpDown1.TabIndex = 5;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.ForeColor = System.Drawing.Color.MidnightBlue;
        label4.Location = new System.Drawing.Point(8, 310);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(318, 35);
        label4.TabIndex = 6;
        label4.Text = "Choose number of tickets you want to buy";
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(32, 427);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(253, 106);
        button1.TabIndex = 7;
        button1.Text = "Buy ticket/s";
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(195, 566);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(130, 31);
        button2.TabIndex = 8;
        button2.Text = "Return to menu";
        button2.UseVisualStyleBackColor = true;
        // 
        // BuyingTickets
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label4);
        Controls.Add(numericUpDown1);
        Controls.Add(comboBox2);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "BuyingTickets";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboBox2;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Label label1;

    #endregion
}