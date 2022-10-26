using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExample
{
	internal class QueueWrapper
	{
		public delegate void ProcessHandler(MyTask message);
		
		public event ProcessHandler Process;

		private ConcurrentQueue<MyTask> _queue = new ConcurrentQueue<MyTask>();

		public void AddTask(MyTask task)
		{
			_queue.Enqueue(task);
		}

		public async Task RunQueueProcessor(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				if (_queue.TryDequeue(out var queue))
				{
					var handler = Process;
					if(handler != null)
					{
						handler(queue);
					}	
				}
				else
				{
					await Task.Delay(100);
				}				
			}
		}
	}
}
