using System;
using Model.LayoutModel;
using UnityEngine;
using UnityEngine.UI;

namespace View.LayoutView
{
	public class ShopView : BaseView
	{
		[field: SerializeField]
		private Button BackButton { get; set; }

		private ShopModel Model { get; set; }
		
		public void Setup(ShopModel model, Action onBackClicked)
		{
			Model = model;
			BackButton.onClick.AddListener(() => onBackClicked());
		}
	}
}