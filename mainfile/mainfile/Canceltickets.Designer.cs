using System.ComponentModel;

namespace mainfile;

partial class Canceltickets
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
        label2 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(8, 27);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(307, 43);
        label1.TabIndex = 0;
        label1.Text = "cancel a ticket";
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.HorizontalScrollbar = true;
        listBox1.Location = new System.Drawing.Point(12, 99);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(303, 344);
        listBox1.TabIndex = 1;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(12, 70);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(307, 26);
        label2.TabIndex = 2;
        label2.Text = "Choose a ticket to cancel";
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(44, 449);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(238, 81);
        button1.TabIndex = 3;
        button1.Text = "Cancel ticket";
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(197, 568);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(122, 31);
        button2.TabIndex = 4;
        button2.Text = "Return to menu";
        button2.UseVisualStyleBackColor = true;
        // 
        // Canceltickets
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label2);
        Controls.Add(listBox1);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Canceltickets";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}