// See https://aka.ms/new-console-template for more information

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client;
namespace C1;

public static class Programm
{
	public static void Main(string[] arg)
	{
		Console.WriteLine("Hello, World!");
		Stack stack = CreateTestData();

		SaveStack(stack, 0);

		Console.ReadKey();
		
	}

	private static Stack CreateTestData()
	{
		return new Stack
		{
			Name = "First",
			Children = new[]
					{
				new Stack
				{
					Name = "FirstChild",
				},
				new Stack
				{
					Name = "SecondChild",
					Children = new[]
					{
						new Stack
						{
							Name = "FirstChild",
							Children = new[]
							{
								new Stack
								{
									Name = "FirstChild1",
								},
								new Stack
								{
									Name = "SecondChild1",
									Children = null
								}
							}
						},
						new Stack
						{
							Name = "SecondChild",
							Children = new[]
							{
								new Stack
								{
									Name = "FirstChild",
								},
								new Stack
								{
									Name = "SecondChild",
									Children = Enumerable.Repeat(new Stack{ Name = "3" }, 7).ToArray()
	}
							}
						}
					}
				}
			}
		};
	}

	public static void SaveStack(Stack item, int num)
	{
		var tabs = string.Join(",", Enumerable.Repeat("-", num));
		Console.WriteLine($"{tabs}{item.Name}");

		if (item.Children is null)
		{
			return;
		}
		foreach (var ch in item.Children)
		{
			SaveStack(ch, num + 1);
		}
	}
}


public class Stack
{
	public string Name { get; set; }
	public Stack[] Children { get; set; }
}
