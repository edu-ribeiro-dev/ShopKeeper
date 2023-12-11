using Controller.ActorController;
using Model;
using Model.LayoutModel;
using UnityEngine;

// ReSharper disable ConvertIfStatementToNullCoalescingAssignment

namespace Manager
{
	public class GameManager : BaseManager
	{
		[field: SerializeField]
		public SceneManager SceneManager { get; private set; }

		[field: SerializeField]
		private PlayerController PlayerPrefab { get; set; }

		[field: SerializeField]
		private ClothesStockModelSO PlayerDefaultClothesStock { get; set; }
		
		private PlayerModel PlayerModelReference { get; set; }

		public static GameManager Instance { get; private set; }

		private void Awake()
		{
			if (Instance is not null && Instance != this)
			{
				Destroy(this);
			}
			else
			{
				Instance = this;
			}

			DontDestroyOnLoad(this);
		}

		public PlayerController InstantiatePlayer()
		{
			if (PlayerModelReference == null)
				PlayerModelReference = new PlayerModel(PlayerDefaultClothesStock);

			return Instantiate(PlayerPrefab).Init(PlayerModelReference);
		}
	}
}