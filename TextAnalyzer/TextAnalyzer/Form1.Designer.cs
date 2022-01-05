
namespace TextAnalyzer
{
    partial class Form1
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
            this.inputBox = new System.Windows.Forms.TextBox();
            this.errorsBox = new System.Windows.Forms.TextBox();
            this.countsBox = new System.Windows.Forms.TextBox();
            this.inputLabel = new System.Windows.Forms.Label();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.countsLabel = new System.Windows.Forms.Label();
            this.verifyButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.inputBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputBox.ForeColor = System.Drawing.SystemColors.Info;
            this.inputBox.Location = new System.Drawing.Point(12, 37);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputBox.Size = new System.Drawing.Size(475, 527);
            this.inputBox.TabIndex = 1;
            this.inputBox.WordWrap = false;
            // 
            // errorsBox
            // 
            this.errorsBox.AcceptsReturn = true;
            this.errorsBox.AcceptsTab = true;
            this.errorsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.errorsBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.errorsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorsBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.errorsBox.ForeColor = System.Drawing.SystemColors.Info;
            this.errorsBox.Location = new System.Drawing.Point(493, 37);
            this.errorsBox.Multiline = true;
            this.errorsBox.Name = "errorsBox";
            this.errorsBox.ReadOnly = true;
            this.errorsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorsBox.Size = new System.Drawing.Size(260, 527);
            this.errorsBox.TabIndex = 2;
            // 
            // countsBox
            // 
            this.countsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.countsBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.countsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.countsBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.countsBox.ForeColor = System.Drawing.SystemColors.Info;
            this.countsBox.Location = new System.Drawing.Point(758, 37);
            this.countsBox.Multiline = true;
            this.countsBox.Name = "countsBox";
            this.countsBox.ReadOnly = true;
            this.countsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.countsBox.Size = new System.Drawing.Size(229, 527);
            this.countsBox.TabIndex = 3;
            // 
            // inputLabel
            // 
            this.inputLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputLabel.AutoSize = true;
            this.inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inputLabel.Location = new System.Drawing.Point(7, 9);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(100, 25);
            this.inputLabel.TabIndex = 4;
            this.inputLabel.Text = "Input text";
            // 
            // errorsLabel
            // 
            this.errorsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.errorsLabel.AutoSize = true;
            this.errorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorsLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.errorsLabel.Location = new System.Drawing.Point(488, 9);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Size = new System.Drawing.Size(70, 25);
            this.errorsLabel.TabIndex = 5;
            this.errorsLabel.Text = "Errors";
            // 
            // countsLabel
            // 
            this.countsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.countsLabel.AutoSize = true;
            this.countsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.countsLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.countsLabel.Location = new System.Drawing.Point(753, 9);
            this.countsLabel.Name = "countsLabel";
            this.countsLabel.Size = new System.Drawing.Size(80, 25);
            this.countsLabel.TabIndex = 6;
            this.countsLabel.Text = "Counts";
            // 
            // verifyButton
            // 
            this.verifyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.verifyButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.verifyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verifyButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.verifyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.verifyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.verifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.verifyButton.Location = new System.Drawing.Point(389, 570);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(79, 22);
            this.verifyButton.TabIndex = 0;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click_1);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar.Location = new System.Drawing.Point(492, 570);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(495, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(999, 616);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.countsLabel);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.countsBox);
            this.Controls.Add(this.errorsBox);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.inputLabel);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.MinimumSize = new System.Drawing.Size(1015, 655);
            this.Name = "Form1";
            this.Text = "TextAnalyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox errorsBox;
        private System.Windows.Forms.TextBox countsBox;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Label errorsLabel;
        private System.Windows.Forms.Label countsLabel;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

