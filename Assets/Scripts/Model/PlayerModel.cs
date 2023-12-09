namespace Model
{
	public class PlayerModel
	{
		private const float DefaultMoveSpeed = 5;

		public float CurrentMoveSpeed { get; private set; }

		public PlayerModel()
		{
			CurrentMoveSpeed = DefaultMoveSpeed;
		}
	}
}