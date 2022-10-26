using ChessLibrary;
using QueueExample;
using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
	public delegate void ProcessHandler(MyTask message);

	private static int[] invoices = new int[1000];

	public static event ProcessHandler Notify;

	private static async Task Main(string[] args)
	{		
		var cts = new CancellationTokenSource();
		
		var invoice = new int[1000];
		var rnd = new Random();
		for(var i = 0; i < invoice.Length; i++)
		{
			invoice[i] = rnd.Next();
		}


		var wrapper = new QueueWrapper();
		_ = wrapper.RunQueueProcessor(cts.Token);
		wrapper.Process += Wrapper_Process;
		wrapper.Process += Wrapper_Process0;
		wrapper.Process += Wrapper_Process1;

		var sw = new Stopwatch();
		sw.Start();
		var invoiceChaneRequest = rnd.Next();

		for (var i = 0; i < invoice.Length; i++)
		{
			wrapper.AddTask(new MyTask
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

	public static TaskType? TT { get; set; }

	public void P(TaskType? tt)
	{
		R(tt ?? TaskType.Dimple);
		
	}

	public void R(TaskType ee)
	{

	}

	private static void Wrapper_Process(MyTask item)
	{
		WriteLine($"{ 1000} Process {item.InvoiceIndex} {item.InvoiceChaneRequest}");
	}
	private static void Wrapper_Process0(MyTask item)
	{
		WriteLine("Два "+ $"Process {item.InvoiceIndex} {item.InvoiceChaneRequest}");
	}
	private static void Wrapper_Process1(MyTask item)
	{
		WriteLine("Три " + $"Process {item.InvoiceIndex} {item.InvoiceChaneRequest}");
	}


	private static void WriteLine(string str)
	{
		lock("CONSOLE")
		{
			Console.WriteLine(str);
		}
	}


	private static ConcurrentQueue<MyTask> _queue = new ConcurrentQueue<MyTask>();
}
