using Model.LayoutModel;
using UnityEngine;

namespace Model
{
	public class PlayerModel : BaseModel
	{
		[field: SerializeField]
		public ClothesStockModelSO ClothesStock { get; set; }

		private const float DefaultMoveSpeed = 8;
		
		public float CurrentMoveSpeed { get; private set; }

		public bool IsDummy { get; set; }

		public PlayerModel()
		{
			CurrentMoveSpeed = DefaultMoveSpeed;
			IsDummy = false;
		}

		public PlayerModel(bool isDummy) : this()
		{
			IsDummy = true;
		} 
	}
}