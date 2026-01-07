using System.ComponentModel;

namespace mainfile;

partial class History
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
        listBox1 = new System.Windows.Forms.ListBox();
        button1 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(23, 17);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(261, 34);
        label1.TabIndex = 0;
        label1.Text = "History";
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.HorizontalScrollbar = true;
        listBox1.Location = new System.Drawing.Point(12, 66);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(310, 484);
        listBox1.TabIndex = 1;
        // 
        // button1
        // 
        button1.ForeColor = System.Drawing.Color.Black;
        button1.Location = new System.Drawing.Point(204, 572);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(122, 27);
        button1.TabIndex = 2;
        button1.Text = "Return to menu";
        button1.UseVisualStyleBackColor = true;
        // 
        // History
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button1);
        Controls.Add(listBox1);
        Controls.Add(label1);
        ForeColor = System.Drawing.Color.White;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "History";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label1;

    #endregion
}