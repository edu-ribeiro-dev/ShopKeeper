using Model;
using UnityEngine;

namespace View
{
	public class PlayerSkinView : BaseView
	{
		private SkinStockModel Model { get; set; }

		[field: SerializeField]
		private SpriteRenderer HeadSprite { get; set; }

		[field: SerializeField]
		private SpriteRenderer TorsoSprite { get; set; }

		public void Setup(PlayerModel playerModel)
		{
			Model = new SkinStockModel(playerModel.SkinModel.SkinStock);
			Model.OnCurrentSkinChangedEvent += OnSkinChanged;

			OnSkinChanged();
		}

		private void OnSkinChanged()
		{
			HeadSprite.sprite = Model.GetCurrentSkinForCategory(
				SkinStockModel.SkinCategory.Hood).Sprite;
			TorsoSprite.sprite = Model.GetCurrentSkinForCategory(
				SkinStockModel.SkinCategory.Torso).Sprite;
		}
	}
}
