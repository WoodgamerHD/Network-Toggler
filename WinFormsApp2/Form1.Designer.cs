namespace WinFormsApp2
{
    public partial class Form1 : Form
{
    private System.ComponentModel.IContainer components = null;
    

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components!= null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        comboBox1 = new ComboBox();
        button1 = new Button();
        label1 = new Label();
        textBox1 = new TextBox();
        button2 = new Button();
        label2 = new Label();
        button3 = new Button();
        linkLabel1 = new LinkLabel();
        SuspendLayout();

        // Set the form's background color to a dark shade
        BackColor = Color.FromArgb(30, 30, 30);

        // Set the form's title to a more descriptive and informative one
        Text = "Network Toggler - LOATHE";

        // Set the font for all controls to a modern and clean font
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);

        // Set the size and location of the ComboBox
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(12, 43);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(191, 23);
        comboBox1.TabIndex = 0;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        // Set the size and location of the first Button
        button1.Location = new Point(212, 43);
        button1.Name = "button1";
        button1.Size = new Size(191, 23);
        button1.TabIndex = 1;
        button1.Text = "Select Adapter";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        button1.FlatStyle = FlatStyle.Flat;
        button1.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0);
        button1.FlatAppearance.BorderSize = 1;
        button1.ForeColor = Color.White;

        // Set the size and location of the first Label
        label1.AutoSize = true;
        label1.Location = new Point(9, 25);
        label1.Name = "label1";
        label1.Size = new Size(168, 15);
        label1.TabIndex = 2;
        label1.Text = "Network Adapter List";

        // Set the size and location of the TextBox
        textBox1.Location = new Point(12, 100);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(191, 23);
        textBox1.TabIndex = 3;
        textBox1.KeyPress += textBox1_KeyPress;

        // Set the size and location of the second Button
        button2.Location = new Point(212, 100);
        button2.Name = "button2";
        button2.Size = new Size(191, 23);
        button2.TabIndex = 4;
        button2.Text = "Set Time (seconds)";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        button2.FlatStyle = FlatStyle.Flat;
        button2.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0);
        button2.FlatAppearance.BorderSize = 1;
        button2.ForeColor = Color.White;

        // Set the size and location of the second Label
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label2.Location = new Point(8, 84);
        label2.Name = "label2";
        label2.Size = new Size(187, 15);
        label2.TabIndex = 5;
        label2.Text = "Time to disable (seconds)";

        // Set the size and location of the third Button
        button3.Location = new Point(12, 132);
        button3.Name = "button3";
        button3.Size = new Size(391, 44);
        button3.TabIndex = 6;
        button3.Text = "Disable Adapter";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        button3.FlatStyle = FlatStyle.Flat;
        button3.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0);
        button3.FlatAppearance.BorderSize = 1;
        button3.ForeColor = Color.White;

        //Set the size and location of the LinkLabel
        linkLabel1.AutoSize = true;
        linkLabel1.Location = new Point(134, 179);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new Size(143, 15);
        linkLabel1.TabIndex = 7;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "Source on GitHub";
        linkLabel1.LinkClicked += linkLabel1_LinkClicked;

        // Add the MouseDown event handler to the form
        MouseDown += Form1_MouseDown;

        // Add all controls to the form
        Controls.Add(linkLabel1);
        Controls.Add(button3);
        Controls.Add(label2);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(comboBox1);

        // Set the form's client size
        ClientSize = new Size(415, 202);

        // Set the form's text color to white
        ForeColor = Color.White;

        // Set the form's border style to none
        FormBorderStyle = FormBorderStyle.Sizable;

        // Set the form's back color to gray
        BackColor = Color.Gray;

        // Resume the form's layout
        ResumeLayout(false);
        PerformLayout();
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        // Move the form when the user clicks and drags the form
        this.Capture = true;
        this.MouseMove += Form1_MouseMove;
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
{
    if (e.Button == MouseButtons.Left)
    {
        // Move the form to the new location
        int x = this.Left + (e.X - lastPoint.X);
        int y = this.Top + (e.Y - lastPoint.Y);
        if (x < 0)
        {
            x = 0;
        }
        if (y < 0)
        {
            y = 0;
        }
        if (x + this.Width > Screen.PrimaryScreen.Bounds.Width)
        {
            x = Screen.PrimaryScreen.Bounds.Width - this.Width;
        }
        if (y + this.Height > Screen.PrimaryScreen.Bounds.Height)
        {
            y = Screen.PrimaryScreen.Bounds.Height - this.Height;
        }
        this.Location = new Point(x, y);
        lastPoint = new Point(e.X, e.Y);
        this.Invalidate();
    }
}

    private Point lastPoint;

    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        // Stop moving the form when the user releases the mouse button
        this.Capture = false;
        this.MouseMove -= Form1_MouseMove;
    }

    #endregion

    private ComboBox comboBox1;
    private Button button1;
    private Label label1;
    private TextBox textBox1;
    private Button button2;
    private Label label2;
    private Button button3;
    private LinkLabel linkLabel1;
}
}
