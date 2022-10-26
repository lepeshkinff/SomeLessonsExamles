using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExample
{
	internal class TaskProcessor
	{
		private readonly IEnumerable<TaskTypeHandler> taskTypeHandlers;

		public TaskProcessor(IEnumerable<TaskTypeHandler> taskTypeHandlers)
		{
			this.taskTypeHandlers = taskTypeHandlers;
		}

		public Task Process(MyTask task)
		{
			var processor = taskTypeHandlers.SingleOrDefault(t => t.CanHandle(task.TaskType));

			if (processor == null)
			{
				throw new ArgumentException();
			}

			if (processor == null)
			{
				throw new ArgumentException();
			}

			return processor.Handle(task);
		}
	}
}
