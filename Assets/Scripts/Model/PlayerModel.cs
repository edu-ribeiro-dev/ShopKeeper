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

		private PlayerModel()
		{
			SkinModel = new PlayerSkinModel(ScriptableObject.CreateInstance<SkinStockModelSO>());
			CurrentMoveSpeed = 0;
			IsDummy = false;
		}
		
		public PlayerModel(SkinStockModelSO playerDefaultSkinStock) : this()
		{
			SkinModel = new PlayerSkinModel(playerDefaultSkinStock);
			CurrentMoveSpeed = DefaultMoveSpeed;
		}

		public PlayerModel(bool isDummy, SkinStockModelSO playerDummySkinStock) : this()
		{
			IsDummy = isDummy;
			SkinModel = new PlayerSkinModel(playerDummySkinStock);
		}
	}
}