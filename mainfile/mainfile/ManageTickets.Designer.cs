using System.ComponentModel;

namespace mainfile;

partial class ManageTickets
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
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(12, 56);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(337, 51);
        label1.TabIndex = 0;
        label1.Text = "Managing personal tickets";
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(31, 123);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(275, 105);
        button1.TabIndex = 1;
        button1.Text = "Active tickets";
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.Color.MidnightBlue;
        button2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button2.ForeColor = System.Drawing.Color.White;
        button2.Location = new System.Drawing.Point(31, 264);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(275, 105);
        button2.TabIndex = 2;
        button2.Text = "Purchase history";
        button2.UseVisualStyleBackColor = false;
        // 
        // button3
        // 
        button3.BackColor = System.Drawing.Color.MidnightBlue;
        button3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button3.ForeColor = System.Drawing.Color.White;
        button3.Location = new System.Drawing.Point(31, 405);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(275, 105);
        button3.TabIndex = 3;
        button3.Text = "Cancel a ticket";
        button3.UseVisualStyleBackColor = false;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(178, 564);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(148, 35);
        button4.TabIndex = 4;
        button4.Text = "Return to menu";
        button4.UseVisualStyleBackColor = true;
        // 
        // ManageTickets
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ManageTickets";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label1;

    #endregion
}