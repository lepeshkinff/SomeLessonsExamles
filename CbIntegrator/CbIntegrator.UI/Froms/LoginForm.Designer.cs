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
			this.authTypeTabs = new System.Windows.Forms.TabControl();
			this.loginTabPage = new System.Windows.Forms.TabPage();
			this.LoginBtn = new System.Windows.Forms.Button();
			this.passwordTb = new System.Windows.Forms.TextBox();
			this.loginTb = new System.Windows.Forms.TextBox();
			this.registerTab = new System.Windows.Forms.TabPage();
			this.registrationBtn = new System.Windows.Forms.Button();
			this.passwordRegTb = new System.Windows.Forms.TextBox();
			this.loginRegTb = new System.Windows.Forms.TextBox();
			this.authTypeTabs.SuspendLayout();
			this.loginTabPage.SuspendLayout();
			this.registerTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// authTypeTabs
			// 
			this.authTypeTabs.Controls.Add(this.loginTabPage);
			this.authTypeTabs.Controls.Add(this.registerTab);
			this.authTypeTabs.Location = new System.Drawing.Point(12, 12);
			this.authTypeTabs.Name = "authTypeTabs";
			this.authTypeTabs.SelectedIndex = 0;
			this.authTypeTabs.Size = new System.Drawing.Size(323, 351);
			this.authTypeTabs.TabIndex = 4;
			// 
			// loginTabPage
			// 
			this.loginTabPage.Controls.Add(this.LoginBtn);
			this.loginTabPage.Controls.Add(this.passwordTb);
			this.loginTabPage.Controls.Add(this.loginTb);
			this.loginTabPage.Location = new System.Drawing.Point(4, 24);
			this.loginTabPage.Name = "loginTabPage";
			this.loginTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.loginTabPage.Size = new System.Drawing.Size(315, 323);
			this.loginTabPage.TabIndex = 0;
			this.loginTabPage.Text = "Вход";
			this.loginTabPage.UseVisualStyleBackColor = true;
			// 
			// LoginBtn
			// 
			this.LoginBtn.Location = new System.Drawing.Point(6, 93);
			this.LoginBtn.Name = "LoginBtn";
			this.LoginBtn.Size = new System.Drawing.Size(75, 23);
			this.LoginBtn.TabIndex = 4;
			this.LoginBtn.Text = "Login";
			this.LoginBtn.UseVisualStyleBackColor = true;
			this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
			// 
			// passwordTb
			// 
			this.passwordTb.Location = new System.Drawing.Point(6, 38);
			this.passwordTb.Name = "passwordTb";
			this.passwordTb.PasswordChar = '*';
			this.passwordTb.Size = new System.Drawing.Size(205, 23);
			this.passwordTb.TabIndex = 2;
			// 
			// loginTb
			// 
			this.loginTb.Location = new System.Drawing.Point(6, 9);
			this.loginTb.Name = "loginTb";
			this.loginTb.Size = new System.Drawing.Size(205, 23);
			this.loginTb.TabIndex = 1;
			// 
			// registerTab
			// 
			this.registerTab.Controls.Add(this.registrationBtn);
			this.registerTab.Controls.Add(this.passwordRegTb);
			this.registerTab.Controls.Add(this.loginRegTb);
			this.registerTab.Location = new System.Drawing.Point(4, 24);
			this.registerTab.Name = "registerTab";
			this.registerTab.Padding = new System.Windows.Forms.Padding(3);
			this.registerTab.Size = new System.Drawing.Size(315, 323);
			this.registerTab.TabIndex = 1;
			this.registerTab.Text = "Регистрация";
			this.registerTab.UseVisualStyleBackColor = true;
			// 
			// registrationBtn
			// 
			this.registrationBtn.Location = new System.Drawing.Point(48, 114);
			this.registrationBtn.Name = "registrationBtn";
			this.registrationBtn.Size = new System.Drawing.Size(95, 23);
			this.registrationBtn.TabIndex = 2;
			this.registrationBtn.Text = "Регистрация";
			this.registrationBtn.UseVisualStyleBackColor = true;
			this.registrationBtn.Click += new System.EventHandler(this.registrationBtn_Click);
			// 
			// passwordRegTb
			// 
			this.passwordRegTb.Location = new System.Drawing.Point(45, 69);
			this.passwordRegTb.Name = "passwordRegTb";
			this.passwordRegTb.Size = new System.Drawing.Size(100, 23);
			this.passwordRegTb.TabIndex = 1;
			// 
			// loginRegTb
			// 
			this.loginRegTb.Location = new System.Drawing.Point(43, 33);
			this.loginRegTb.Name = "loginRegTb";
			this.loginRegTb.Size = new System.Drawing.Size(100, 23);
			this.loginRegTb.TabIndex = 0;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 376);
			this.Controls.Add(this.authTypeTabs);
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			this.Click += new System.EventHandler(this.LoginBtn_Click);
			this.authTypeTabs.ResumeLayout(false);
			this.loginTabPage.ResumeLayout(false);
			this.loginTabPage.PerformLayout();
			this.registerTab.ResumeLayout(false);
			this.registerTab.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private TabControl authTypeTabs;
		private TabPage loginTabPage;
		private TabPage registerTab;
		private TextBox loginTb;
		private TextBox passwordTb;
		private Button LoginBtn;
		private Button registrationBtn;
		private TextBox passwordRegTb;
		private TextBox loginRegTb;
	}
}