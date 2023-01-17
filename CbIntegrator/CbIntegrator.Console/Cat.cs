internal class Cat : Pet
{
	public int Lifes { get; set; } = 9;

	public void Die()
	{
		Lifes = Lifes - 1;
		if (Lifes <= 0)
		{
			throw new Exception();
		}
	}


	public override void Play()
	{
		Lifes++;
		base.Play();
	}
}