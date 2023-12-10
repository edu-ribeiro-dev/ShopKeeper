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
		private PlayerController PlayerDummy { get; set; }

		public ShopController Init(Action onBackClicked)
		{
			View.Setup(Model, onBackClicked);
			PlayerDummy.Init(new PlayerModel(true));

			SetInitialized();
			return this; 
		}
	}
}
