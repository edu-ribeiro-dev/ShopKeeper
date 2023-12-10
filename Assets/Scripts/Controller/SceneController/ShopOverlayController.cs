using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.SceneController
{
	public class ShopOverlayController : BaseController
	{
		[field: SerializeField]
		private Button BuyButton { get; set; }

		[field: SerializeField]
		private Button SellButton { get; set; }

		[field: SerializeField]
		private Button CloseButton { get; set; }

		private void Awake()
		{
			BuyButton.onClick.AddListener(OnBuyClicked);
			SellButton.onClick.AddListener(OnSellClicked);
			CloseButton.onClick.AddListener(OnCloseClicked);
		}

		private void OnBuyClicked()
		{
			ShowShopToBuy();
		}

		private void OnSellClicked()
		{
			ShowInventoryToSell();
		}

		private void OnCloseClicked()
		{
			GameManager.SceneManager.CloseSceneAdditive();
		}

		private void ShowShopToBuy()
		{
			SetSceneButtonsVisible(false);
			SetShopVisible(true);
		}

		private void ShowInventoryToSell()
		{
			SetSceneButtonsVisible(false);
			SetInventoryVisible(true);
		}

		private void OnShopInternalBackClicked()
		{
			SetShopVisible(false);
			SetSceneButtonsVisible(true);
		}

		private void SetSceneButtonsVisible(bool visible)
		{
			BuyButton.enabled = SellButton.enabled = CloseButton.enabled = visible;
		}

		private void SetShopVisible(bool visible)
		{
			
		}

		private void SetInventoryVisible(bool visible)
		{
			
		}
	}
}
