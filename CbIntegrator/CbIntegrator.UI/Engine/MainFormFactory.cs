namespace CbIntegrator.UI.Engine
{
	public class MainFormFactory : IMainFormFactory
	{
		
		private Lazy<MainForm> _form;

		public MainFormFactory(ApplicationContext context)
		{
			_form = new Lazy<MainForm>(() =>
			{
				var form = new MainForm(new Bussynes.Repositories.DummyCurenciesRepository());
				context.MainForm = form;
				return form;
			});	
		}

		public MainForm Create()
		{
			return _form.Value;
		}
	}
}
