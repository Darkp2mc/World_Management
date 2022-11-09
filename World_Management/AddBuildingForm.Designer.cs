﻿namespace World_Management
{
    partial class AddBuildingForm
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

        private void unlockAddBuilding()
        {
            this.btn_addBuilding.Enabled = !string.IsNullOrEmpty(this.tb_name.Text);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_addBuilding = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_addBuilding
            // 
            this.btn_addBuilding.Enabled = false;
            this.btn_addBuilding.Location = new System.Drawing.Point(12, 81);
            this.btn_addBuilding.Name = "btn_addBuilding";
            this.btn_addBuilding.Size = new System.Drawing.Size(106, 29);
            this.btn_addBuilding.TabIndex = 0;
            this.btn_addBuilding.Text = "Add Building";
            this.btn_addBuilding.UseVisualStyleBackColor = true;
            this.btn_addBuilding.Click += new System.EventHandler(this.btn_addBuilding_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(124, 81);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(106, 29);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 22);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(52, 20);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Name:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(70, 19);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(160, 27);
            this.tb_name.TabIndex = 3;
            // 
            // AddBuildingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 122);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_addBuilding);
            this.Name = "AddBuildingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_addBuilding;
        private Button btn_cancel;
        private Label lbl_name;
        private TextBox tb_name;
    }
}