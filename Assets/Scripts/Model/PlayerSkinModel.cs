using System;
using System.Collections.Generic;
using Model.LayoutModel;
using Model.ScriptableObjects;

namespace Model
{
	public class PlayerSkinModel : SkinStockModel
	{
		public delegate void OnSkinStockUpdated();

		public event OnSkinStockUpdated OnSkinStockUpdatedEvent;

		public PlayerSkinModel(SkinStockModelSO playerDefaultSkinStock) : base(playerDefaultSkinStock) { }

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

		public bool PlayerContainsSkin(SkinSO skin, SkinCategory category)
		{
			var skinList = GetSkinListByCategory(category);
			return skinList.Contains(skin);
		}

		private List<SkinSO> GetSkinListByCategory(SkinCategory category)
		{
			return category switch
			{
				SkinCategory.Hood => SkinStockModelSO.HoodList,
				SkinCategory.Torso => SkinStockModelSO.TorsoList,
				SkinCategory.Gloves => new List<SkinSO>(),
				_ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
			};
		}
	}
}