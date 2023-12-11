namespace Model
{
	public class ShopKeeperModel : BaseInteractableModel
	{
		public bool ShopOpen { get; set; }

		public ShopKeeperModel() : base()
		{
			ShopOpen = false;
		}
	}
}