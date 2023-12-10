using System;
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

		public ShopController Init(Action onBackClicked)
		{
			View.Setup(Model, onBackClicked);

			SetInitialized();
			return this; 
		}
	}
}
