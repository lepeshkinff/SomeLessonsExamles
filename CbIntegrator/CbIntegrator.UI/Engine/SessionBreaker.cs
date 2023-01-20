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
	internal class SessionBreaker
	{
		static TimeSpan SessionTimeout = TimeSpan.FromSeconds(30);
		static TimeSpan SessionMessageTimeout = TimeSpan.FromSeconds(15);

		private System.Threading.Timer timerMessage;
		private System.Threading.Timer timerSession;

		private readonly ApplicationContextCb applicationContext;
		private readonly IMainFormFactory factory;

		public SessionBreaker(
			ApplicationContextCb applicationContext,
			IMainFormFactory factory)
		{
			this.applicationContext = applicationContext;
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
			if(applicationContext.MainForm is { } mainForm)
			{
				mainForm.Invoke(() => 
				{
					var login = new LoginForm(factory, new UsersService(applicationContext, new DummyIUsersRepository()));
					applicationContext.MainForm = login;
					mainForm.Close();
					login.Show();
				});
			}

			
		}
	}
}
