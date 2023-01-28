using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Froms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbIntegrator.UI.Engine
{
	public class SessionBreaker
	{
		static TimeSpan SessionTimeout = TimeSpan.FromSeconds(30);
		static TimeSpan SessionMessageTimeout = TimeSpan.FromSeconds(15);

		private System.Threading.Timer timerMessage;
		private System.Threading.Timer timerSession;

		private readonly Func<LoginForm> factory;

		public SessionBreaker(
			Func<LoginForm> factory)
		{
			this.factory = factory;
		}

		public void Start()
		{
			timerMessage = new System.Threading.Timer(
				_ => MessageBox.Show("Сессия будет завершена"),
				null,
				SessionMessageTimeout,
				TimeSpan.Zero);

			timerSession = new System.Threading.Timer(
				_ => ResetSession(),
				null,
				SessionTimeout,
				TimeSpan.Zero);
		}

		private void ResetSession()
		{
			if(Program.context.MainForm is { } mainForm)
			{
				mainForm.Invoke(() => 
				{
					var login = factory();
					Program.context.MainForm = login;
					mainForm.Close();
					login.Show();
				});
			}

			
		}
	}
}
