namespace GraphicsApp.Client.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            SelectBaseColorButton = new Button();
            label1 = new Label();
            DrawPanel = new Panel();
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            SelectFileButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(SelectFileButton);
            groupBox1.Controls.Add(SelectBaseColorButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(150, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Colors";
            // 
            // SelectBaseColorButton
            // 
            SelectBaseColorButton.Location = new Point(78, 15);
            SelectBaseColorButton.Name = "SelectBaseColorButton";
            SelectBaseColorButton.Size = new Size(66, 23);
            SelectBaseColorButton.TabIndex = 1;
            SelectBaseColorButton.UseVisualStyleBackColor = true;
            SelectBaseColorButton.Click += SelectBaseColorButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Base Color:";
            // 
            // DrawPanel
            // 
            DrawPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DrawPanel.Location = new Point(168, 12);
            DrawPanel.Name = "DrawPanel";
            DrawPanel.Size = new Size(620, 426);
            DrawPanel.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectFileButton
            // 
            SelectFileButton.Location = new Point(6, 44);
            SelectFileButton.Name = "SelectFileButton";
            SelectFileButton.Size = new Size(138, 23);
            SelectFileButton.TabIndex = 2;
            SelectFileButton.Text = "Select File";
            SelectFileButton.UseVisualStyleBackColor = true;
            SelectFileButton.Click += SelectFileButtonClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DrawPanel);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Main";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel DrawPanel;
        private Button SelectBaseColorButton;
        private Label label1;
        private ColorDialog colorDialog1;
        private OpenFileDialog openFileDialog1;
        private Button SelectFileButton;
    }
}