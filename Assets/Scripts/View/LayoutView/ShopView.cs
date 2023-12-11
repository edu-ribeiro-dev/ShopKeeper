using System;
using Model;
using Model.LayoutModel;
using Model.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.LayoutView
{
	public class ShopView : BaseView
	{
		private ShopModel Model { get; set; }

		[field: SerializeField]
		private TextMeshProUGUI HeaderCategoryDisplayText { get; set; }
		
		[field: SerializeField]
		private Transform PlayerDummy { get; set; }

		[field: SerializeField]
		private SpriteRenderer PlayerDummyHeadSprite { get; set; }

		[field: SerializeField]
		private SpriteRenderer PlayerDummyTorsoSprite { get; set; }
		
		[field: SerializeField]
		private Button ChangeSkinLeftButton { get; set; }

		[field: SerializeField]
		private Button ChangeSkinRightButton { get; set; }

		[field: SerializeField]
		private Button ChangeCategoryLeftButton { get; set; }

		[field: SerializeField]
		private Button ChangeCategoryRightButton { get; set; }
		
		[field: SerializeField]
		private Button BackButton { get; set; }

		[field: SerializeField]
		private Button BuyButton { get; set; }

		private SpriteRenderer CurrentBodyPartSprite { get; set; }

		public void Setup(
			ShopModel model,
			Action onChangeSkinLeftButtonClicked,
			Action onChangeSkinRightButtonClicked,
			Action onChangeCategoryLeftButtonClicked,
			Action onChangeCategoryRightButtonClicked,
			Action<SkinSO, SkinStockModel.SkinCategory> onBuyClicked,
			Action onBackClicked)
		{
			Model = model;
			ChangeSkinLeftButton.onClick.AddListener(() => onChangeSkinLeftButtonClicked());
			ChangeSkinRightButton.onClick.AddListener(() => onChangeSkinRightButtonClicked());
			ChangeCategoryLeftButton.onClick.AddListener(() => onChangeCategoryLeftButtonClicked());
			ChangeCategoryRightButton.onClick.AddListener(() => onChangeCategoryRightButtonClicked());
			BuyButton.onClick.AddListener(() => 
				onBuyClicked(Model.GetCurrentSkinForCategory(Model.GetCurrentCategory()), Model.GetCurrentCategory()));
			BackButton.onClick.AddListener(() => onBackClicked());
			Hide();

			Model.OnCurrentCategoryChangedEvent += OnCategoryChanged;
			Model.OnCurrentSkinChangedEvent += OnSkinChanged;
			Model.OnCurrentBuySkinStatusChanged += OnCurrentSkinBuyStatusChanged;
			OnCategoryChanged();
		}

		private void OnCategoryChanged()
		{
			HeaderCategoryDisplayText.SetText(Model.GetCurrentCategory().ToString());
			switch (Model.GetCurrentCategory())
			{
				case SkinStockModel.SkinCategory.Hood:
					CurrentBodyPartSprite = PlayerDummyHeadSprite;
					break;
				case SkinStockModel.SkinCategory.Torso:
					CurrentBodyPartSprite = PlayerDummyTorsoSprite;
					break;
				case SkinStockModel.SkinCategory.Gloves:
					break;
				case SkinStockModel.SkinCategory.Unknown:
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void OnSkinChanged()
		{
			var currentCategorySkin = Model.GetCurrentSkinForCategory(Model.GetCurrentCategory());
			if (currentCategorySkin == null)
				return;

			CurrentBodyPartSprite.sprite = currentCategorySkin.Sprite;
			
		}

		private void OnCurrentSkinBuyStatusChanged()
		{
			BuyButton.interactable = Model.CurrentCanBeBought;
		}

		public void Show()
		{
			PlayerDummy.gameObject.SetActive(true);
		}

		public void Hide()
		{
			PlayerDummy.gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			Model.OnCurrentCategoryChangedEvent -= OnCategoryChanged;
			Model.OnCurrentSkinChangedEvent -= OnSkinChanged;
			Model.OnCurrentBuySkinStatusChanged -= OnCurrentSkinBuyStatusChanged;
		}
	}
}