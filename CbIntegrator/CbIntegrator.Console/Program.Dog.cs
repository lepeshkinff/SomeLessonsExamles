internal class Dog : Pet
{
	public override void Play()
	{
		Console.WriteLine("Stop");
		base.Play();
	}
}