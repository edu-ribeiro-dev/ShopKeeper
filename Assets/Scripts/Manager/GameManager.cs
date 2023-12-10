using Controller.ActorController;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
// ReSharper disable ConvertIfStatementToNullCoalescingAssignment

namespace Manager
{
	public class GameManager : BaseManager
	{
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

		public static void ChangeScene(string sceneName)
		{
			SceneManager.LoadSceneAsync(sceneName);
		}

		public PlayerController InstantiatePlayer()
		{
			if (PlayerModelReference == null)
				PlayerModelReference = new PlayerModel();

			return Instantiate(PlayerPrefab).Init(PlayerModelReference);
		}
	}
}