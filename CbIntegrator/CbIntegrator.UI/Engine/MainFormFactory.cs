namespace CbIntegrator.UI.Engine
{
	public class MainFormFactory : IMainFormFactory
	{
		
		private Lazy<MainForm> _form;

		public ApplicationContext Context { get; set; }

		public MainFormFactory()
		{
			_form = new Lazy<MainForm>(() =>
			{
				var form = new MainForm(new Bussynes.Repositories.DummyCurenciesRepository());
				Context.MainForm = form;
				return form;
			});	
		}

		public MainForm Create()
		{
			return _form.Value;
		}
	}
}
