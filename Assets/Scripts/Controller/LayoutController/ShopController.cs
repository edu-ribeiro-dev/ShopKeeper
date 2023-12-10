using System;
using Controller.ActorController;
using Model;
using Model.LayoutModel;
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
		private ClothesStockModelSO ClothesStock { get; set; }

		[field: SerializeField] 
		private PlayerController PlayerDummy { get; set; }

		public ShopController Init(Action onBackClicked)
		{
			Model = new ShopModel(ClothesStock);
			
			View.Setup(Model,
				OnChangeClothLeftButtonClicked,
				OnChangeClothRightButtonClicked,
				OnChangeCategoryLeftButtonClicked,
				OnChangeCategoryRightButtonClicked,
				onBackClicked);

			PlayerDummy.Init(new PlayerModel(true));

			SetInitialized();
			return this; 
		}

		private void OnChangeClothLeftButtonClicked()
		{
			Model.PreviousClothes();
		}

		private void OnChangeClothRightButtonClicked()
		{
			Model.NextClothes();
		}
		
		private void OnChangeCategoryLeftButtonClicked()
		{
			Model.PreviousCategory();
		}
		
		private void OnChangeCategoryRightButtonClicked()
		{
			Model.NextCategory();
		}

	}
}
