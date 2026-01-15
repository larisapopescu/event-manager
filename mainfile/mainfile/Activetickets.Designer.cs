using System.ComponentModel;

namespace mainfile;

partial class Activetickets
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
        button1 = new System.Windows.Forms.Button();
        listBox1 = new System.Windows.Forms.ListBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(19, 16);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(279, 42);
        label1.TabIndex = 0;
        label1.Text = "Active tickets:";
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(203, 564);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(121, 40);
        button1.TabIndex = 2;
        button1.Text = "Return to menu";
        button1.UseVisualStyleBackColor = true;
        // 
        // listBox1
        // 
        listBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        listBox1.FormattingEnabled = true;
        listBox1.HorizontalScrollbar = true;
        listBox1.Location = new System.Drawing.Point(4, 64);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(330, 480);
        listBox1.TabIndex = 3;
        // 
        // Activetickets
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(listBox1);
        Controls.Add(button1);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Activetickets";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label1;

    #endregion
}