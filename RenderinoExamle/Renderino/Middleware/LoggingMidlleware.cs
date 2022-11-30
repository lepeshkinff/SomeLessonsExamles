namespace Renderino.Middleware
{
	public class LoggingMidlleware : IMiddleware
	{
		private readonly ILogger _logger;

		public LoggingMidlleware(ILogger<LoggingMidlleware> logger)
		{
			_logger = logger;
		}

		public Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				_logger.LogDebug("Start LFF method {@url}", context.Request.Path);
				if(next != null)
				{
					return next.Invoke(context);
				}

				return Task.CompletedTask;
			}
			finally
			{
				_logger.LogDebug("End LFF method {@url}", context.Request.Path);
			}
		}
	}
}
