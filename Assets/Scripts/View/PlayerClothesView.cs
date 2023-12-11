using Model;
using UnityEngine;

namespace View
{
	public class PlayerClothesView : BaseView
	{
		private ClothesStockModel Model { get; set; }
		
		[field: SerializeField]
		private SpriteRenderer HeadSprite { get; set; }

		[field: SerializeField]
		private SpriteRenderer TorsoSprite { get; set; }

		public void Setup(PlayerModel playerModel)
		{
			Model = new ClothesStockModel(playerModel.ClothesStock);
			Model.OnCurrentClothesChangedEvent += OnClothChanged;

			OnClothChanged();
		}

		private void OnClothChanged()
		{
			HeadSprite.sprite = Model.GetCurrentClothesPieceForCategory(
				ClothesStockModel.ClothesCategory.Hood).Sprite;
			TorsoSprite.sprite = Model.GetCurrentClothesPieceForCategory(
				ClothesStockModel.ClothesCategory.Torso).Sprite;
		}
	}
}
