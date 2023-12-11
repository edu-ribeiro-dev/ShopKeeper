using System;
using Model.LayoutModel;
using UnityEngine;
using View.LayoutView;

namespace Controller.LayoutController
{
	public class InventoryController : BaseController
	{
		[field: SerializeField]
		private InventoryView View { get; set; }

		private InventoryModel Model { get; set; }

		public InventoryController Init(Action onBackClicked)
		{
			View.Setup(Model, onBackClicked);

			SetInitialized();
			return this; 
		}
	}
}
