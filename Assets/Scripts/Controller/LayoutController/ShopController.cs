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
				onBackClicked);

			PlayerDummy.InitDummy(new PlayerModel(true, SkinStock));

			SetInitialized();
			return this; 
		}

		private void OnChangeSkinLeftButtonClicked()
		{
			Model.PreviousSkin();
		}

		private void OnChangeSkinRightButtonClicked()
		{
			Model.NextSkin();
		}
		
		private void OnChangeCategoryLeftButtonClicked()
		{
			Model.PreviousCategory();
		}
		
		private void OnChangeCategoryRightButtonClicked()
		{
			Model.NextCategory();
		}

		public void OnBuyClicked(SkinSO skinBought)
		{
			
		}
	}
}
