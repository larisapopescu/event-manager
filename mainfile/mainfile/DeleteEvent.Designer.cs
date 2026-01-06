using System.ComponentModel;

namespace mainfile;

partial class DeleteEvent
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
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 19.800001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(27, 59);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(269, 72);
        label1.TabIndex = 0;
        label1.Text = "Delete event";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(12, 219);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(196, 28);
        comboBox1.TabIndex = 1;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(11, 159);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(314, 33);
        label2.TabIndex = 2;
        label2.Text = "Choose an event to delete";
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(27, 303);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(267, 166);
        button1.TabIndex = 3;
        button1.Text = "delete event";
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(204, 568);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(121, 36);
        button2.TabIndex = 4;
        button2.Text = "Return to menu";
        button2.UseVisualStyleBackColor = true;
        // 
        // DeleteEvent
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "DeleteEvent";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Label label1;

    #endregion
}