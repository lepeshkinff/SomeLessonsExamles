namespace CbIntegrator.Console
{
	public class DbHelper
	{
		protected Dictionary<string, string> _loginPassword = new()
		{
			["test"] = "test",
		};

		public virtual bool Authorize(string login, string password)
		{
			if(!_loginPassword.TryGetValue(login, out var pwd))
			{
				return false;
			}

			return pwd.Equals(password);
		}
	}

}
