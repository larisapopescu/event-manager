using System.ComponentModel;

namespace mainfile;

partial class ViewEventDetail
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
        label3 = new System.Windows.Forms.Label();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        button1 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(12, 21);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(300, 34);
        label1.TabIndex = 0;
        label1.Text = "View event\'s detail";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.Location = new System.Drawing.Point(12, 192);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(314, 410);
        label3.TabIndex = 3;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new System.Drawing.Point(12, 58);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(167, 131);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 4;
        pictureBox1.TabStop = false;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(201, 70);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(125, 33);
        button1.TabIndex = 5;
        button1.Text = "Return to menu";
        button1.UseVisualStyleBackColor = true;
        // 
        // ViewEventDetail
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(button1);
        Controls.Add(pictureBox1);
        Controls.Add(label3);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ViewEventDetail";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Label label1;

    #endregion
}