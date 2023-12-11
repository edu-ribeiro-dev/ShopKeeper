using System;
using System.Collections.Generic;
using Model.LayoutModel;
using Model.ScriptableObjects;
using UnityEngine;

namespace Model
{
	public class PlayerSkinModel : BaseModel
	{
		public SkinStockModelSO SkinStock { get; set; }

		public delegate void OnSkinStockUpdated();

		public event OnSkinStockUpdated OnSkinStockUpdatedEvent;

		private PlayerSkinModel()
		{
			SkinStock = ScriptableObject.CreateInstance<SkinStockModelSO>();
		}
		
		public PlayerSkinModel(SkinStockModelSO playerDefaultSkinStock) : this()
		{
			SkinStock = playerDefaultSkinStock;
		}

		public void AddSkin(SkinSO newSkin, SkinStockModel.SkinCategory category)
		{
			var skinList = GetSkinListByCategory(category);

			if (PlayerContainsSkin(newSkin, category))
				throw new InvalidOperationException("Trying to add an repeated skin");

			skinList.Add(newSkin);

			OnSkinStockUpdatedEvent?.Invoke();
		}

		public void RemoveSkin(SkinSO skinToRemove, SkinStockModel.SkinCategory category)
		{
			if (!PlayerContainsSkin(skinToRemove, category))
				throw new InvalidOperationException("Trying to remove a not obtained skin");

			var skinList = GetSkinListByCategory(category);
			skinList.Remove(skinToRemove);

			OnSkinStockUpdatedEvent?.Invoke();
		}

		public bool PlayerContainsSkin(SkinSO skin, SkinStockModel.SkinCategory category)
		{
			var skinList = GetSkinListByCategory(category);
			return skinList.Contains(skin);
		}

		private List<SkinSO> GetSkinListByCategory(SkinStockModel.SkinCategory category)
		{
			return category switch
			{
				SkinStockModel.SkinCategory.Hood => SkinStock.HoodList,
				SkinStockModel.SkinCategory.Torso => SkinStock.TorsoList,
				SkinStockModel.SkinCategory.Gloves => new List<SkinSO>(),
				_ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
			};
		}
	}
}