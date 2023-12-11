using Model.LayoutModel;
using UnityEngine;

namespace Model
{
	public class PlayerModel : BaseModel
	{
		public PlayerSkinModel SkinModel { get; set; }
		
		private const float DefaultMoveSpeed = 8;

		public float CurrentMoveSpeed { get; private set; }

		public bool IsDummy { get; set; }
		
		public PlayerModel(SkinStockModelSO playerDefaultSkinStock)
		{
			SkinModel = new PlayerSkinModel(playerDefaultSkinStock);
			CurrentMoveSpeed = DefaultMoveSpeed;
		}

		public PlayerModel(bool isDummy, SkinStockModelSO playerDummySkinStock)
		{
			SkinModel = new PlayerSkinModel(playerDummySkinStock);
			IsDummy = isDummy;
		}
	}
}