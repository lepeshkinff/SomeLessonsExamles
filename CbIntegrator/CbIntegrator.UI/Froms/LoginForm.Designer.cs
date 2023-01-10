namespace CbIntegrator.UI.Froms
{
	partial class LoginForm
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
			this.LoginBtn = new System.Windows.Forms.Button();
			this.loginTb = new System.Windows.Forms.TextBox();
			this.passwordTb = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LoginBtn
			// 
			this.LoginBtn.Location = new System.Drawing.Point(207, 251);
			this.LoginBtn.Name = "LoginBtn";
			this.LoginBtn.Size = new System.Drawing.Size(75, 23);
			this.LoginBtn.TabIndex = 0;
			this.LoginBtn.Text = "Login";
			this.LoginBtn.UseVisualStyleBackColor = true;
			this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
			// 
			// loginTb
			// 
			this.loginTb.Location = new System.Drawing.Point(207, 169);
			this.loginTb.Name = "loginTb";
			this.loginTb.Size = new System.Drawing.Size(205, 23);
			this.loginTb.TabIndex = 1;
			// 
			// passwordTb
			// 
			this.passwordTb.Location = new System.Drawing.Point(207, 198);
			this.passwordTb.Name = "passwordTb";
			this.passwordTb.PasswordChar = '*';
			this.passwordTb.Size = new System.Drawing.Size(205, 23);
			this.passwordTb.TabIndex = 2;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.passwordTb);
			this.Controls.Add(this.loginTb);
			this.Controls.Add(this.LoginBtn);
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button LoginBtn;
		private TextBox loginTb;
		private TextBox passwordTb;
	}
}