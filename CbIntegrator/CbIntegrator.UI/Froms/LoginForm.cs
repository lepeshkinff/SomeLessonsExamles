using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Engine;

namespace CbIntegrator.UI.Froms
{
	public partial class LoginForm : Form
	{
		private readonly IMainFormFactory mainFormFactory;
		private readonly IUsersService usersService;

		public LoginForm(IMainFormFactory mainFormFactory, IUsersService usersService)
		{
			InitializeComponent();
			this.mainFormFactory = mainFormFactory;
			this.usersService = usersService;
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			var user = usersService.Authorize(loginTb.Text, passwordTb.Text);

			if(!OpenMainWindow(user))
			{
				MessageBox.Show("Не нашли пользователя");
			}
		}

		private void registrationBtn_Click(object sender, EventArgs e)
		{
			var (user, error) = usersService.Register(loginRegTb.Text, passwordRegTb.Text);

			OpenMainWindow(user);
			if (!OpenMainWindow(user))
			{
				MessageBox.Show($"Не зарегистрировали пользователя: {error}");
			}
		}

		private bool OpenMainWindow(User? user)
		{
			if (user != null)
			{
				var form = mainFormFactory.Create();
				form.Show();
				this.Close();
				return true;
			}

			return false;
		}
	}
}
