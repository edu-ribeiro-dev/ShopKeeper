using UnityEngine;

namespace Manager
{
	public class LaunchScene : BaseSceneManager
	{
		[field: SerializeField]
		private GameManager GameManagerPrefab { get; set; }

		private void Awake()
		{
			Instantiate(GameManagerPrefab);
		}

		private void Start()
		{
			GameManager.ChangeScene("ShopKeeperLair");
		}
	}
}