using System;
using Controller.ActorController;
using Manager;
using Model;
using Model.LayoutModel;
using Model.ScriptableObjects;
using UnityEngine;
using View.LayoutView;

namespace Controller.LayoutController
{
	public class ShopController : BaseController
	{
		[field: SerializeField]
		private ShopView View { get; set; }

		private ShopModel Model { get; set; }
		
		[field: SerializeField]
		private SkinStockModelSO SkinStock { get; set; }

		[field: SerializeField] 
		private PlayerController PlayerDummy { get; set; }

		public ShopController Init(Action onBackClicked)
		{
			Model = new ShopModel(SkinStock);
			
			View.Setup(Model,
				OnChangeSkinLeftButtonClicked,
				OnChangeSkinRightButtonClicked,
				OnChangeCategoryLeftButtonClicked,
				OnChangeCategoryRightButtonClicked,
				OnBuyClicked,
				onBackClicked);

			PlayerDummy.InitDummy(new PlayerModel(true, SkinStock));
			UpdateSkinBuyStatus();

			SetInitialized();
			return this; 
		}

		private void OnChangeSkinLeftButtonClicked()
		{
			Model.PreviousSkin();
			UpdateSkinBuyStatus();
		}

		private void OnChangeSkinRightButtonClicked()
		{
			Model.NextSkin();
			UpdateSkinBuyStatus();
		}
		
		private void OnChangeCategoryLeftButtonClicked()
		{
			Model.PreviousCategory();
			UpdateSkinBuyStatus();
		}
		
		private void OnChangeCategoryRightButtonClicked()
		{
			Model.NextCategory();
			UpdateSkinBuyStatus();
		}

		private void UpdateSkinBuyStatus()
		{
			var playerRef = GameManager.Instance.PlayerReference;
			var playerHaveSkin = playerRef.PlayerHaveSkin(Model.GetCurrentSkinForCategory(Model.GetCurrentCategory()),
				Model.GetCurrentCategory());
			
			if (playerHaveSkin)
				Model.DisableCurrentSkinBuy();
			else
				Model.EnableCurrentSkinBuy();
		}

		private void OnBuyClicked(SkinSO skinBought, SkinStockModel.SkinCategory category)
		{
			var player = GameManager.Instance.PlayerReference;
			player.AddSkin(skinBought, category);
			UpdateSkinBuyStatus();
		}
	}
}
