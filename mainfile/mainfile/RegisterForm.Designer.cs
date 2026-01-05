using System.ComponentModel;

namespace mainfile;

partial class RegisterForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        textBox2 = new System.Windows.Forms.TextBox();
        panel1 = new System.Windows.Forms.Panel();
        panel2 = new System.Windows.Forms.Panel();
        button1 = new System.Windows.Forms.Button();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        pictureBox2 = new System.Windows.Forms.PictureBox();
        radioButton1 = new System.Windows.Forms.RadioButton();
        radioButton2 = new System.Windows.Forms.RadioButton();
        label4 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Goudy Stout", 18F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.MidnightBlue;
        label1.Location = new System.Drawing.Point(3, 98);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(339, 62);
        label1.TabIndex = 0;
        label1.Text = "Register";
        label1.UseWaitCursor = true;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.MidnightBlue;
        label2.Location = new System.Drawing.Point(12, 183);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(171, 25);
        label2.TabIndex = 1;
        label2.Text = "Choose an username";
        label2.UseWaitCursor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(12, 211);
        textBox1.Name = "textBox1";
        textBox1.PlaceholderText = "Type username here";
        textBox1.Size = new System.Drawing.Size(314, 27);
        textBox1.TabIndex = 5;
        textBox1.UseWaitCursor = true;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.MidnightBlue;
        label3.Location = new System.Drawing.Point(12, 271);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(171, 25);
        label3.TabIndex = 3;
        label3.Text = "Choose a password\r\n\r\n";
        label3.UseWaitCursor = true;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(12, 299);
        textBox2.Name = "textBox2";
        textBox2.PlaceholderText = "Type password here";
        textBox2.Size = new System.Drawing.Size(314, 27);
        textBox2.TabIndex = 5;
        textBox2.UseWaitCursor = true;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.Color.MidnightBlue;
        panel1.ForeColor = System.Drawing.Color.MidnightBlue;
        panel1.Location = new System.Drawing.Point(12, 332);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(313, 1);
        panel1.TabIndex = 9;
        panel1.UseWaitCursor = true;
        // 
        // panel2
        // 
        panel2.BackColor = System.Drawing.Color.MidnightBlue;
        panel2.ForeColor = System.Drawing.Color.MidnightBlue;
        panel2.Location = new System.Drawing.Point(13, 244);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(313, 1);
        panel2.TabIndex = 10;
        panel2.UseWaitCursor = true;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.MidnightBlue;
        button1.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(73, 442);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(172, 63);
        button1.TabIndex = 11;
        button1.Text = "Create account";
        button1.UseVisualStyleBackColor = false;
        button1.UseWaitCursor = true;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
        pictureBox1.Location = new System.Drawing.Point(177, 189);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(29, 16);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 12;
        pictureBox1.TabStop = false;
        pictureBox1.UseWaitCursor = true;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = ((System.Drawing.Image)resources.GetObject("pictureBox2.Image"));
        pictureBox2.Location = new System.Drawing.Point(177, 277);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new System.Drawing.Size(29, 16);
        pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox2.TabIndex = 13;
        pictureBox2.TabStop = false;
        pictureBox2.UseWaitCursor = true;
        // 
        // radioButton1
        // 
        radioButton1.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        radioButton1.ForeColor = System.Drawing.Color.MidnightBlue;
        radioButton1.Location = new System.Drawing.Point(13, 385);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new System.Drawing.Size(163, 28);
        radioButton1.TabIndex = 15;
        radioButton1.TabStop = true;
        radioButton1.Text = "Organizer";
        radioButton1.UseVisualStyleBackColor = true;
        // 
        // radioButton2
        // 
        radioButton2.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        radioButton2.ForeColor = System.Drawing.Color.MidnightBlue;
        radioButton2.Location = new System.Drawing.Point(177, 385);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new System.Drawing.Size(163, 28);
        radioButton2.TabIndex = 16;
        radioButton2.TabStop = true;
        radioButton2.Text = "Client";
        radioButton2.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.ForeColor = System.Drawing.Color.MidnightBlue;
        label4.Location = new System.Drawing.Point(13, 348);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(300, 25);
        label4.TabIndex = 17;
        label4.Text = "Are you an organizer or a client";
        label4.UseWaitCursor = true;
        // 
        // RegisterForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.LightCyan;
        ClientSize = new System.Drawing.Size(338, 611);
        Controls.Add(label4);
        Controls.Add(radioButton2);
        Controls.Add(radioButton1);
        Controls.Add(pictureBox2);
        Controls.Add(pictureBox1);
        Controls.Add(button1);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(textBox2);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "RegisterForm";
        UseWaitCursor = true;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.PictureBox pictureBox2;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Panel panel2;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}