using System.ComponentModel;

namespace mainfile;

partial class SalesStatus
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
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(12, 20);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(287, 41);
        label1.TabIndex = 0;
        label1.Text = "sales status";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(12, 131);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(204, 28);
        comboBox1.TabIndex = 1;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(12, 87);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(161, 41);
        label2.TabIndex = 2;
        label2.Text = "Choose an event";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.Location = new System.Drawing.Point(12, 194);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(314, 292);
        label3.TabIndex = 3;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(203, 556);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(123, 34);
        button1.TabIndex = 4;
        button1.Text = "Return to menu";
        button1.UseVisualStyleBackColor = true;
        // 
        // SalesStatus
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "SalesStatus";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}