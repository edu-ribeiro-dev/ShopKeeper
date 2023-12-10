using System;
using System.Collections.Generic;

namespace Model.LayoutModel
{
	public class ShopModel : BaseModel
	{
		public enum ClothesCategory
		{
			Unknown,
			Hood,
			Torso,
			Gloves
		}

		private List<ClothesCategory> CategoryList { get; set; }

		private int CurrentClothesCategoryIndex { get; set; }

		private int CurrentClothesIndex { get; set; }

		private ClothesStockModelSO ClothesStockModelSO { get; set; }

		public delegate void OnCurrentCategoryChanged();

		public event OnCurrentCategoryChanged OnCurrentCategoryChangedEvent;

		public delegate void OnCurrentClothesChanged();

		public event OnCurrentClothesChanged OnCurrentClothesChangedEvent;

		public ShopModel(ClothesStockModelSO storeStock)
		{
			ClothesStockModelSO = storeStock;
			CategoryList = new List<ClothesCategory>();
			if (storeStock.HoodList.Count > 0)
				CategoryList.Add(ClothesCategory.Hood);
			if (storeStock.TorsoList.Count > 0)
				CategoryList.Add(ClothesCategory.Torso);

			CurrentClothesCategoryIndex = 0;
		}

		public void NextCategory()
		{
			if (++CurrentClothesCategoryIndex > CategoryList.Count - 1)
			{
				CurrentClothesCategoryIndex = 0;
			}

			OnCurrentCategoryChangedEvent?.Invoke();
		}

		public void PreviousCategory()
		{
			if (--CurrentClothesCategoryIndex < 0)
			{
				CurrentClothesCategoryIndex = CategoryList.Count - 1;
			}

			OnCurrentCategoryChangedEvent?.Invoke();
		}

		public void NextClothes()
		{
			var currentCategory = CategoryList[CurrentClothesCategoryIndex];
			if (++CurrentClothesIndex > GetStockByCategory(currentCategory).Count - 1)
			{
				CurrentClothesIndex = 0;
			}

			OnCurrentClothesChangedEvent?.Invoke();
		}

		public void PreviousClothes()
		{
			var currentCategory = CategoryList[CurrentClothesCategoryIndex];
			if (--CurrentClothesIndex < 0)
			{
				CurrentClothesIndex = GetStockByCategory(currentCategory).Count - 1;
			}

			OnCurrentClothesChangedEvent?.Invoke();
		}

		public ClothesCategory GetCurrentCategory()
		{
			return CategoryList[CurrentClothesCategoryIndex];
		}

		private List<ClothesSO> GetStockByCategory(ClothesCategory category)
		{
			return category switch
			{
				ClothesCategory.Hood => ClothesStockModelSO.HoodList,
				ClothesCategory.Torso => ClothesStockModelSO.TorsoList,
				ClothesCategory.Gloves => new List<ClothesSO>(),
				_ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
			};
		}

		public ClothesSO GetCurrentClothesPiece()
		{
			var currentCategory = CategoryList[CurrentClothesCategoryIndex];
			return GetStockByCategory(currentCategory)[CurrentClothesIndex];
		}
	}
}