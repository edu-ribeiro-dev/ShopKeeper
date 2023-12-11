using System;
using Model.SceneModel;
using UnityEngine;
using UnityEngine.UI;
using View.LayoutView;

namespace View.SceneView
{
	public class ShopOverlaySceneView : BaseView
	{
		[field: SerializeField]
		private Button BuyButton { get; set; }

		[field: SerializeField]
		private Button SellButton { get; set; }

		[field: SerializeField]
		private Button CloseButton { get; set; }

		[field: SerializeField]
		private CanvasGroup SceneOptionsCanvasGroup { get; set; }

		[field: SerializeField]
		private Transform ShopKeeperDummy { get; set; }

		[field: SerializeField]
		private CanvasGroup ShopCanvasGroup { get; set; }

		[field: SerializeField]
		public ShopView ShopView { get; set; }

		[field: SerializeField]
		private CanvasGroup InventoryCanvasGroup { get; set; }

		[field: SerializeField]
		private InventoryView InventoryView { get; set; }

		private ShopOverlaySceneModel Model { get; set; }

		public void Setup(ShopOverlaySceneModel model, Action onBuyClicked, Action onSellClicked, Action onCloseClicked)
		{
			Model = model;
			BuyButton.onClick.AddListener(() => onBuyClicked());
			SellButton.onClick.AddListener(() => onSellClicked());
			CloseButton.onClick.AddListener(() => onCloseClicked());

			// Hiding sell button as features isn't finished
			SellButton.gameObject.SetActive(false);

			Model.OnStateChangedEvent += UpdateSceneLayout;
		}

		private void UpdateSceneLayout(ShopOverlaySceneModel.ShopState shopState)
		{
			switch (shopState)
			{
				case ShopOverlaySceneModel.ShopState.SceneOptions:
					HideShop();
					HideInventory();
					ShowSceneOptionsLayout();
					break;

				case ShopOverlaySceneModel.ShopState.ShopOpen:
					HideSceneOptionsLayout();
					HideInventory();
					ShowShop();
					break;

				case ShopOverlaySceneModel.ShopState.InventoryOpen:
					HideSceneOptionsLayout();
					HideShop();
					ShowInventory();
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(shopState), shopState, null);
			}
		}

		private void ShowSceneOptionsLayout()
		{
			Show(SceneOptionsCanvasGroup);
			ShowShopKeeperDummy();
		}

		public void ShowShopKeeperDummy()
		{
			ShopKeeperDummy.gameObject.SetActive(true);
		}

		public void HideShopKeeperDummy()
		{
			ShopKeeperDummy.gameObject.SetActive(false);
		}

		private void HideSceneOptionsLayout()
		{
			Hide(SceneOptionsCanvasGroup);
			HideShopKeeperDummy();
		}

		private void ShowShop()
		{
			Show(ShopCanvasGroup);
			ShopView.ShowPlayerDummy();
		}

		private void HideShop()
		{
			Hide(ShopCanvasGroup);
			ShopView.HidePlayerDummy();
		}

		private void ShowInventory()
		{
			Show(InventoryCanvasGroup);
		}

		private void HideInventory()
		{
			Hide(InventoryCanvasGroup);
		}

		private void Show(CanvasGroup canvasGroup)
		{
			canvasGroup.alpha = 1;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
		
		private void Hide(CanvasGroup canvasGroup)
		{
			canvasGroup.alpha = 0;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}

		private void OnDestroy()
		{
			Model.OnStateChangedEvent -= UpdateSceneLayout;
		}
	}
}