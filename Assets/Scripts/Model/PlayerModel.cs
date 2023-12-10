namespace Model
{
	public class PlayerModel : BaseModel
	{
		private const float DefaultMoveSpeed = 8;

		public float CurrentMoveSpeed { get; private set; }

		public PlayerModel()
		{
			CurrentMoveSpeed = DefaultMoveSpeed;
		}
	}
}