namespace WinFormsApp
{
    partial class UpdateStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            txtGroup = new TextBox();
            txtSpeciality = new TextBox();
            label2 = new Label();
            NameTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Russo One", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(68, 9);
            label1.Name = "label1";
            label1.Size = new Size(251, 19);
            label1.TabIndex = 0;
            label1.Text = "Изменение данных студента";
            // 
            // button1
            // 
            button1.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(108, 124);
            button1.Name = "button1";
            button1.Size = new Size(185, 23);
            button1.TabIndex = 14;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnUpdate_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(28, 92);
            label4.Name = "label4";
            label4.Size = new Size(52, 14);
            label4.TabIndex = 13;
            label4.Text = "Группа";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 63);
            label3.Name = "label3";
            label3.Size = new Size(103, 14);
            label3.TabIndex = 12;
            label3.Text = "Специальность";
            // 
            // txtGroup
            // 
            txtGroup.Location = new Point(254, 92);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(100, 23);
            txtGroup.TabIndex = 10;
            // 
            // txtSpeciality
            // 
            txtSpeciality.Location = new Point(254, 63);
            txtSpeciality.Name = "txtSpeciality";
            txtSpeciality.Size = new Size(100, 23);
            txtSpeciality.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(28, 32);
            label2.Name = "label2";
            label2.Size = new Size(32, 14);
            label2.TabIndex = 15;
            label2.Text = "Имя";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(254, 30);
            NameTextBox.Margin = new Padding(3, 2, 3, 2);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(98, 23);
            NameTextBox.TabIndex = 16;
            // 
            // UpdateStudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrange;
            ClientSize = new Size(410, 164);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtGroup);
            Controls.Add(txtSpeciality);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateStudentForm";
            Text = "Изменить студента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label4;
        private Label label3;
        private TextBox txtGroup;
        private TextBox txtSpeciality;
        private Label label2;
        private TextBox NameTextBox;
    }
}