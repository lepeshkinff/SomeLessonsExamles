using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbIntegrator.Console
{
	internal class AuthorizationService
	{
		protected Dictionary<string, string> _loginPassword = new()
		{
			["test"] = "test",
		};

		public virtual bool SaveToDb(string login, string password)
		{
			if (!_loginPassword.TryGetValue(login, out var pwd))
			{
				return false;
			}

			return pwd.Equals(password);
		}


		public void Authorize(string login, string password)
		{
			if(!Validate(login, password))
			{
				throw null;
			}
			SaveToDb();
		}

		protected bool Validate(string login, string password)
		{
			if (login == null && password == null)
			{
				return false;
			}
			if (password == null)
			{
				return false;
			}

			return true;
		}

		private void SaveToDb()
		{

		}
	}
}
