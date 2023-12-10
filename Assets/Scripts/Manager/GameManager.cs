using Controller.ActorController;
using Model;
using UnityEngine;

// ReSharper disable ConvertIfStatementToNullCoalescingAssignment

namespace Manager
{
	public class GameManager : BaseManager
	{
		[field: SerializeField]
		public static SceneManager SceneManager { get; set; }

		[field: SerializeField]
		private PlayerController PlayerPrefab { get; set; }

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
				PlayerModelReference = new PlayerModel();

			return Instantiate(PlayerPrefab).Init(PlayerModelReference);
		}
	}
}