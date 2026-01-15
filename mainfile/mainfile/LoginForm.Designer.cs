using System.ComponentModel;

namespace mainfile;

partial class LoginForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
        pictureBox1 = new System.Windows.Forms.PictureBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        panel1 = new System.Windows.Forms.Panel();
        label3 = new System.Windows.Forms.Label();
        textBox2 = new System.Windows.Forms.TextBox();
        panel2 = new System.Windows.Forms.Panel();
        button1 = new System.Windows.Forms.Button();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        button2 = new System.Windows.Forms.Button();
        pictureBox2 = new System.Windows.Forms.PictureBox();
        pictureBox3 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
        pictureBox1.Location = new System.Drawing.Point(170, 2);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(163, 131);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.800001F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(12, 155);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(292, 80);
        label1.TabIndex = 3;
        label1.Text = "Login";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        label2.Location = new System.Drawing.Point(8, 235);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(148, 33);
        label2.TabIndex = 4;
        label2.Text = "Username";
        // 
        // textBox1
        // 
        textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
        textBox1.Location = new System.Drawing.Point(12, 260);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Type username here";
        textBox1.Size = new System.Drawing.Size(292, 27);
        textBox1.TabIndex = 5;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.Color.MidnightBlue;
        panel1.Location = new System.Drawing.Point(12, 293);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(292, 1);
        panel1.TabIndex = 6;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        label3.Location = new System.Drawing.Point(12, 306);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(148, 33);
        label3.TabIndex = 7;
        label3.Text = "Password";
        // 
        // textBox2
        // 
        textBox2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
        textBox2.Location = new System.Drawing.Point(12, 332);
        textBox2.Name = "textBox2";
        textBox2.PlaceholderText = "Type password here";
        textBox2.Size = new System.Drawing.Size(292, 27);
        textBox2.TabIndex = 8;
        // 
        // panel2
        // 
        panel2.BackColor = System.Drawing.Color.MidnightBlue;
        panel2.Location = new System.Drawing.Point(12, 374);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(292, 1);
        panel2.TabIndex = 9;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(78, 381);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(155, 43);
        button1.TabIndex = 10;
        button1.Text = "Login";
        button1.UseVisualStyleBackColor = false;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.ForeColor = System.Drawing.Color.MidnightBlue;
        label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        label4.Location = new System.Drawing.Point(18, 460);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(138, 33);
        label4.TabIndex = 11;
        label4.Text = "Don\'t have an account?";
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.ForeColor = System.Drawing.Color.DarkSlateGray;
        label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        label5.Location = new System.Drawing.Point(166, 460);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(138, 33);
        label5.TabIndex = 12;
        label5.Text = "Sign up";
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(226, 564);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(93, 32);
        button2.TabIndex = 13;
        button2.Text = "Exit page";
        button2.UseVisualStyleBackColor = true;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = ((System.Drawing.Image)resources.GetObject("pictureBox2.Image"));
        pictureBox2.Location = new System.Drawing.Point(121, 238);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new System.Drawing.Size(35, 20);
        pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox2.TabIndex = 14;
        pictureBox2.TabStop = false;
        // 
        // pictureBox3
        // 
        pictureBox3.Image = ((System.Drawing.Image)resources.GetObject("pictureBox3.Image"));
        pictureBox3.Location = new System.Drawing.Point(121, 306);
        pictureBox3.Name = "pictureBox3";
        pictureBox3.Size = new System.Drawing.Size(35, 20);
        pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox3.TabIndex = 15;
        pictureBox3.TabStop = false;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(pictureBox3);
        Controls.Add(pictureBox2);
        Controls.Add(button2);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(button1);
        Controls.Add(panel2);
        Controls.Add(textBox2);
        Controls.Add(label3);
        Controls.Add(panel1);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.PictureBox pictureBox3;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Panel panel2;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.PictureBox pictureBox1;

    #endregion
}