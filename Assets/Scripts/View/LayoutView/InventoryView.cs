using System;
using Model.LayoutModel;
using UnityEngine;
using UnityEngine.UI;

namespace View.LayoutView
{
	public class InventoryView : BaseView
	{
		[field: SerializeField]
		private Button BackButton { get; set; }

		private InventoryModel Model { get; set; }
		
		public void Setup(InventoryModel model, Action onBackClicked)
		{
			Model = model;
			BackButton.onClick.AddListener(() => onBackClicked());
		}
	}
}