using Model.LayoutModel;
using UnityEngine;

namespace Model
{
	public class PlayerModel : BaseModel
	{
		public ClothesStockModelSO ClothesStock { get; set; }

		private const float DefaultMoveSpeed = 8;
		
		public float CurrentMoveSpeed { get; private set; }

		public bool IsDummy { get; set; }

		private PlayerModel()
		{
			ClothesStock = ScriptableObject.CreateInstance<ClothesStockModelSO>();
			CurrentMoveSpeed = 0;
			IsDummy = false;
		}
		
		public PlayerModel(ClothesStockModelSO playerDefaultClothesStock) : this()
		{
			ClothesStock = playerDefaultClothesStock;
			CurrentMoveSpeed = DefaultMoveSpeed;
		}

		public PlayerModel(bool isDummy, ClothesStockModelSO playerDummyClothesStock) : this()
		{
			IsDummy = isDummy;
			ClothesStock = playerDummyClothesStock;
		}
	}
}