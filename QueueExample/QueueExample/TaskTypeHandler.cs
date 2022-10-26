namespace QueueExample
{
	public abstract class TaskTypeHandler
	{
		public abstract bool CanHandle(TaskType type);

		public abstract Task Handle(MyTask task);
	}

	public class PopitHandler : TaskTypeHandler
	{
		public override bool CanHandle(TaskType type) => type == TaskType.Popit || type == TaskType.SuppaDuppaNewTaskType;

		public override Task Handle(MyTask task)
		{
			return Task.Delay(10);
		}
	}

	public class SimpleHandler : TaskTypeHandler
	{
		public override bool CanHandle(TaskType type) => type == TaskType.Simple;

		public override Task Handle(MyTask task)
		{
			if(!CanHandle(task.TaskType))
			{
				throw new Exception();
			}
			return Task.Delay(20);
		}
	}

	public class SomNewClass : SimpleHandler
	{
		private bool _init = false;
		public bool Init() => _init = true;
		public override bool CanHandle(TaskType type) => type == TaskType.Simple;

		public override Task Handle(MyTask task)
		{
			if(_init)
			{
				throw new Exception();
			}
			
			return Task.Delay(20*10);
		}
	}


	class Rectange
	{
		public virtual int Heigth { get; set; }
		public virtual int Width { get; set; }
	}


	class Squere
	{
		private Rectange rectange;

		public int Heigth 
		{			
			get => rectange.Heigth; 
			set 
				{
				rectange.Heigth = value;
				rectange.Width = value;
			}
			
		}

		public int Width
		{
			get => rectange.Width;
			set
			{
				rectange.Heigth = value;
				rectange.Width = value;
			} 
		}
	}
}
