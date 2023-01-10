using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbIntegrator.Bussynes.Exceptions
{
	/// <summary>
	/// Базовый класс для исключений бизнес логики
	/// </summary>
	public class ServiceException : Exception
	{
		public ServiceException(string message) : base(message)
		{

		}
	}
}
