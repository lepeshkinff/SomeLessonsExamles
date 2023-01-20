using CbIntegrator.Bussynes.Services;

namespace CbIntegrator.UI.Engine
{
	public class ApplicationContextCb : ApplicationContext, IApplicationContext
	{
		SessionBreaker sessionBreaker;
		public ApplicationContextCb(IMainFormFactory mainFormFactory) : base()
		{
			sessionBreaker = new SessionBreaker(this, mainFormFactory);

		}

		public void StartSession()
		{
			sessionBreaker.Start();
		}
	}
}