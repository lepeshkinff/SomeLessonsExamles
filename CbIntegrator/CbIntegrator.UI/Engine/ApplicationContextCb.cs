using CbIntegrator.Bussynes.Services;

namespace CbIntegrator.UI.Engine
{
	public class ApplicationContextCb : ApplicationContext, IApplicationContext
	{
		SessionBreaker sessionBreaker;
		public ApplicationContextCb(SessionBreaker sessionBreaker) : base()
		{
			this.sessionBreaker = sessionBreaker;

		}

		public void StartSession()
		{
			sessionBreaker.Start();
		}
	}
}