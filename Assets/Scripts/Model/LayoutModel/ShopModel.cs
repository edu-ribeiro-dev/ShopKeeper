namespace Model.LayoutModel
{
	public class ShopModel : SkinStockModel
	{
		public bool CurrentCanBeBought { get; set; }

		public delegate void OnCurrentSkinBuyStatusChanged();

		public event OnCurrentSkinBuyStatusChanged OnCurrentBuySkinStatusChanged;
		
		public ShopModel(SkinStockModelSO storeStock) : base(storeStock)
		{
			CurrentCanBeBought = false;
		}

		public void EnableCurrentSkinBuy()
		{
			CurrentCanBeBought = true;
			OnCurrentBuySkinStatusChanged?.Invoke();
		}

		public void DisableCurrentSkinBuy()
		{
			CurrentCanBeBought = false;
			OnCurrentBuySkinStatusChanged?.Invoke();
		}
	}
}