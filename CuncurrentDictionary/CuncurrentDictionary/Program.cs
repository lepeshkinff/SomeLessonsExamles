using CuncurrentDictionary;
using System.Collections.Concurrent;

internal class Program
{
	private static ConcurrentBag<object> bag = new();
		
	private static async Task Main(string[] args)
	{

		var semaphore = new SemaphoreSlim(0, 100);

		var dict = new ConcurrentDictionary<int, Task<object>>();
		var threads = Enumerable.Range(0, 100)
			.Select(x =>
			{
				var th = new Thread(async () =>
				{
					Console.WriteLine(x);
					semaphore.Wait();

					await dict.GetOrAddAsync(1, async _ =>
					{
						await Task.Yield();

						return await Do();
					});
					Console.WriteLine(x);
				});
				th.Start();
				return th;
			}).ToList();

		Console.WriteLine("готово!");
		Console.ReadLine();
		semaphore.Release(100);

		await Task.Delay(5000);

		Console.WriteLine(bag.Count);
		Console.ReadLine();

	}

	private static async Task<object> Do()
	{
		var obj = new object();
		bag.Add(obj);
		return obj;
	}
}