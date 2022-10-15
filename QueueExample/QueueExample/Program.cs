using ChessLibrary;
using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
	private static int[] invoices = new int[1000];

	private static async Task Main(string[] args)
	{		
		var cts = new CancellationTokenSource();
		RunQueueProcessor(cts.Token);

		var invoice = new int[1000];
		var rnd = new Random();
		for(var i = 0; i < invoice.Length; i++)
		{
			invoice[i] = rnd.Next();
		}


		var sw = new Stopwatch();
		sw.Start();
		var invoiceChaneRequest = rnd.Next();

		for (var i = 0; i < invoice.Length; i++)
		{
			_queue.Enqueue(new MyTask
			{
				InvoiceIndex = i,
				InvoiceChaneRequest = invoiceChaneRequest
			});
		}
		sw.Stop();

		Console.WriteLine(sw.Elapsed);

		while(true)
		{
			var str = Console.ReadKey();
			if(str.Key == ConsoleKey.Escape)
			{
				cts.Cancel();
				break;
			}

			await Task.Delay(100);
		}
		WriteLine("Прекращено выполнение");
		Console.ReadKey();
	}

	private static void WriteLine(string str)
	{
		lock("CONSOLE")
		{
			Console.WriteLine(str);
		}
	}

	private static async Task RunQueueProcessor(CancellationToken cancellationToken)
	{
		while(!cancellationToken.IsCancellationRequested)
		{
			if(_queue.TryDequeue(out var queue))
			{
				ProcessItem(queue);
			}
			else
			{
				await Task.Delay(100);
			}
			WriteLine($"Queue is empty");			
		}
	}

	private static async Task ProcessItem(MyTask item)
	{
		await Task.Yield();
		WriteLine($"Process {item.InvoiceIndex} {item.InvoiceChaneRequest}");
		invoices[item.InvoiceIndex] *= item.InvoiceChaneRequest;
	}

	private static ConcurrentQueue<MyTask> _queue = new ConcurrentQueue<MyTask>();
}

internal class MyTask
{
	public int InvoiceIndex { get; set; }
	public int InvoiceChaneRequest { get; set; }
}