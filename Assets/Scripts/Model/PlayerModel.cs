namespace Model
{
	public class PlayerModel : BaseModel
	{
		private const float DefaultMoveSpeed = 8;
		
		public float CurrentMoveSpeed { get; private set; }

		public bool IsDummy { get; set; }

		public PlayerModel()
		{
			CurrentMoveSpeed = DefaultMoveSpeed;
			IsDummy = false;
		}

		public PlayerModel(bool isDummy) : this()
		{
			IsDummy = true;
		} 
	}
}