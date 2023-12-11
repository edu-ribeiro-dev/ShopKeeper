using System;
using Model;
using Model.LayoutModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.LayoutView
{
	public class ShopView : BaseView
	{
		[field: SerializeField]
		private Button BackButton { get; set; }

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
		private Button ChangeClothLeftButton { get; set; }

		[field: SerializeField]
		private Button ChangeClothRightButton { get; set; }

		[field: SerializeField]
		private Button ChangeCategoryLeftButton { get; set; }

		[field: SerializeField]
		private Button ChangeCategoryRightButton { get; set; }

		private SpriteRenderer CurrentBodyPartSprite { get; set; }

		public void Setup(
			ShopModel model,
			Action onChangeClothLeftButtonClicked,
			Action onChangeClothRightButtonClicked,
			Action onChangeCategoryLeftButtonClicked,
			Action onChangeCategoryRightButtonClicked,
			Action onBackClicked)
		{
			Model = model;
			BackButton.onClick.AddListener(() => onBackClicked());
			ChangeClothLeftButton.onClick.AddListener(() => onChangeClothLeftButtonClicked());
			ChangeClothRightButton.onClick.AddListener(() => onChangeClothRightButtonClicked());
			ChangeCategoryLeftButton.onClick.AddListener(() => onChangeCategoryLeftButtonClicked());
			ChangeCategoryRightButton.onClick.AddListener(() => onChangeCategoryRightButtonClicked());
			Hide();

			Model.OnCurrentCategoryChangedEvent += OnCategoryChanged;
			Model.OnCurrentClothesChangedEvent += OnClothChanged;
			OnCategoryChanged();
		}

		private void OnCategoryChanged()
		{
			HeaderCategoryDisplayText.SetText(Model.GetCurrentCategory().ToString());
			switch (Model.GetCurrentCategory())
			{
				case ClothesStockModel.ClothesCategory.Hood:
					CurrentBodyPartSprite = PlayerDummyHeadSprite;
					break;
				case ClothesStockModel.ClothesCategory.Torso:
					CurrentBodyPartSprite = PlayerDummyTorsoSprite;
					break;
				case ClothesStockModel.ClothesCategory.Gloves:
					break;
				case ClothesStockModel.ClothesCategory.Unknown:
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void OnClothChanged()
		{
			var currentCategoryClothesPiece = Model.GetCurrentClothesPieceForCategory(Model.GetCurrentCategory());
			if (currentCategoryClothesPiece == null)
				return;

			CurrentBodyPartSprite.sprite = currentCategoryClothesPiece.Sprite;
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
			Model.OnCurrentClothesChangedEvent -= OnClothChanged;
		}
	}
}