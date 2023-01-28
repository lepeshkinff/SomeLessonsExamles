using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Engine;
using static System.Windows.Forms.AxHost;

namespace CbIntegrator.UI.Froms
{
	public partial class LoginForm : Form
	{
		private readonly Func<MainForm> mainFormFactory;
		private readonly IUsersService usersService;
		private string capchaValue = "";

		public LoginForm(Func<MainForm> mainFormFactory, IUsersService usersService)
		{
			InitializeComponent();
			LoadCapcha();
			this.mainFormFactory = mainFormFactory;
			this.usersService = usersService;
		}

		private void LoadCapcha()
		{
			var guid = Guid
				.NewGuid()
				.ToString()
				.Replace("-", "")
				.Substring(0, 6);
			capchaValue = guid;
			var image = new Bitmap(capchaPb.Width, capchaPb.Height);
			using var font = new Font("TimesNewRoman", 35, FontStyle.Bold, GraphicsUnit.Pixel);
			using var graphics = Graphics.FromImage(image);
			graphics.DrawString(guid, font, Brushes.Azure, new Point(10, capchaPb.Height/2));

			var rnd = new Random();
			var colors = new Color[]
			{
				Color.Wheat,
				Color.Black,
				Color.Chocolate
			};
			for (int i = 0; i < capchaPb.Width; ++i)
			{
				for (int j = 0; j < capchaPb.Height; ++j)
				{
					if (rnd.Next() % 20 == 0)
						image.SetPixel(i, j, colors[j % 3]);
				}
			}
			var rotate = new[] { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };
			graphics.RotateTransform(rnd.Next(rotate.Length));

			capchaPb.Image = image;
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			if(!capchaValueTb.Text.Equals(capchaValue))
			{
				MessageBox.Show("Капча не совпадает!");
				LoadCapcha();
				return;
			}
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
				var form = mainFormFactory();
				Program.context.MainForm = form;
				form.Show();
				this.Close();
				return true;
			}

			return false;
		}
	}
}
