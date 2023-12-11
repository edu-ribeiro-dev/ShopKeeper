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

		protected Dictionary<SkinCategory, int> IndexDict { get; set; }

		protected SkinStockModelSO SkinStockModelSO { get; set; }

		public delegate void OnCurrentCategoryChanged();

		public event OnCurrentCategoryChanged OnCurrentCategoryChangedEvent;

		public delegate void OnCurrentSkinChanged();

		public event OnCurrentSkinChanged OnCurrentSkinChangedEvent;

		public SkinStockModel(SkinStockModelSO storeStock)
		{
			SkinStockModelSO = storeStock;
			CategoryList = new List<SkinCategory>();
			IndexDict = new Dictionary<SkinCategory, int>();
			if (SkinStockModelSO.HoodList.Count > 0)
			{
				CategoryList.Add(SkinCategory.Hood);
				IndexDict.Add(SkinCategory.Hood, 0);
			}

			if (SkinStockModelSO.TorsoList.Count > 0)
			{
				CategoryList.Add(SkinCategory.Torso);
				IndexDict.Add(SkinCategory.Torso, 0);
			}

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
			if (++IndexDict[currentCategory] > GetStockByCategory(currentCategory).Count - 1)
			{
				IndexDict[currentCategory] = 0;
			}

			OnCurrentSkinChangedEvent?.Invoke();
		}

		public void PreviousSkin()
		{
			var currentCategory = CategoryList[CurrentSkinCategoryIndex];
			if (--IndexDict[currentCategory] < 0)
			{
				IndexDict[currentCategory] = GetStockByCategory(currentCategory).Count - 1;
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
			var currentSkinIndex = IndexDict[category];
			return GetStockByCategory(category)[currentSkinIndex];
		}

		public void EquipSkin(SkinSO skin, SkinCategory category)
		{
			var skinsFromCategory = GetStockByCategory(category);
			var currentSkinIndex = skinsFromCategory.IndexOf(skin);
			IndexDict[category] = currentSkinIndex;

			OnCurrentSkinChangedEvent?.Invoke();
		}
	}
}