using System;
using System.Collections.Generic;
using Model.LayoutModel;
using Model.ScriptableObjects;

namespace Model
{
	public class SkinStockModel : BaseModel
	{
		public enum SkinCategory
		{
			Unknown,
			Hood,
			Torso,
			Gloves
		}

		protected List<SkinCategory> CategoryList { get; set; }

		protected int CurrentSkinCategoryIndex { get; set; }

		protected int CurrentSkinIndex { get; set; }

		protected SkinStockModelSO SkinStockModelSO { get; set; }

		public delegate void OnCurrentCategoryChanged();

		public event OnCurrentCategoryChanged OnCurrentCategoryChangedEvent;

		public delegate void OnCurrentSkinChanged();

		public event OnCurrentSkinChanged OnCurrentSkinChangedEvent;

		public SkinStockModel(SkinStockModelSO storeStock)
		{
			SkinStockModelSO = storeStock;
			CategoryList = new List<SkinCategory>();
			if (storeStock.HoodList.Count > 0)
				CategoryList.Add(SkinCategory.Hood);
			if (storeStock.TorsoList.Count > 0)
				CategoryList.Add(SkinCategory.Torso);

			CurrentSkinCategoryIndex = 0;
		}

		public void NextCategory()
		{
			if (++CurrentSkinCategoryIndex > CategoryList.Count - 1)
			{
				CurrentSkinCategoryIndex = 0;
			}

			OnCurrentCategoryChangedEvent?.Invoke();
		}

		public void PreviousCategory()
		{
			if (--CurrentSkinCategoryIndex < 0)
			{
				CurrentSkinCategoryIndex = CategoryList.Count - 1;
			}

			OnCurrentCategoryChangedEvent?.Invoke();
		}

		public void NextSkin()
		{
			var currentCategory = CategoryList[CurrentSkinCategoryIndex];
			if (++CurrentSkinIndex > GetStockByCategory(currentCategory).Count - 1)
			{
				CurrentSkinIndex = 0;
			}

			OnCurrentSkinChangedEvent?.Invoke();
		}

		public void PreviousSkin()
		{
			var currentCategory = CategoryList[CurrentSkinCategoryIndex];
			if (--CurrentSkinIndex < 0)
			{
				CurrentSkinIndex = GetStockByCategory(currentCategory).Count - 1;
			}

			OnCurrentSkinChangedEvent?.Invoke();
		}

		public SkinCategory GetCurrentCategory()
		{
			return CategoryList[CurrentSkinCategoryIndex];
		}

		protected List<SkinSO> GetStockByCategory(SkinCategory category)
		{
			return category switch
			{
				SkinCategory.Hood => SkinStockModelSO.HoodList,
				SkinCategory.Torso => SkinStockModelSO.TorsoList,
				SkinCategory.Gloves => new List<SkinSO>(),
				_ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
			};
		}

		public SkinSO GetCurrentSkinForCategory(SkinCategory category)
		{
			return GetStockByCategory(category)[CurrentSkinIndex];
		}
	}
}