namespace Model
{
	public abstract class BaseInteractableModel : BaseModel
	{
		public bool IsInteracting { get; private set; }

		protected BaseInteractableModel()
		{
			IsInteracting = false;
		}
		
		public void SetInteracting(bool boolean)
		{
			IsInteracting = boolean;
		}
	}
}