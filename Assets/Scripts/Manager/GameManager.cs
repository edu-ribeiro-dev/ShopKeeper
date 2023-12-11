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
		private SkinStockModelSO PlayerDefaultSkinStock { get; set; }

		public PlayerController PlayerReference { get; set; }

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
			PlayerReference = Instantiate(PlayerPrefab).Init(new PlayerModel(PlayerDefaultSkinStock));
			return PlayerReference;
		}
	}
}