namespace WinFormsApp
{
    partial class AddStudentForm
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
            txtName = new TextBox();
            txtSpeciality = new TextBox();
            txtGroup = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Russo One", 11.2499981F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(144, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 18);
            label1.TabIndex = 0;
            label1.Text = "Добавление студента";
            // 
            // txtName
            // 
            txtName.Location = new Point(117, 33);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // txtSpeciality
            // 
            txtSpeciality.Location = new Point(117, 66);
            txtSpeciality.Name = "txtSpeciality";
            txtSpeciality.Size = new Size(100, 23);
            txtSpeciality.TabIndex = 2;
            // 
            // txtGroup
            // 
            txtGroup.Location = new Point(117, 95);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(100, 23);
            txtGroup.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(32, 14);
            label2.TabIndex = 4;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 69);
            label3.Name = "label3";
            label3.Size = new Size(103, 14);
            label3.TabIndex = 5;
            label3.Text = "Специальность";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 98);
            label4.Name = "label4";
            label4.Size = new Size(52, 14);
            label4.TabIndex = 6;
            label4.Text = "Группа";
            // 
            // button1
            // 
            button1.Font = new Font("Russo One", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(117, 124);
            button1.Name = "button1";
            button1.Size = new Size(185, 23);
            button1.TabIndex = 7;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAdd_Click;
            // 
            // AddStudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrange;
            ClientSize = new Size(450, 159);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtGroup);
            Controls.Add(txtSpeciality);
            Controls.Add(txtName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddStudentForm";
            Text = "Добавить студента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private TextBox txtSpeciality;
        private TextBox txtGroup;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}