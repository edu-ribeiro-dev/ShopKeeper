using Manager;
using UnityEngine;

namespace Controller.SceneController
{
	public class LaunchSceneController : BaseController
	{
		[field: SerializeField]
		private GameManager GameManagerPrefab { get; set; }

		private void Awake()
		{
			Instantiate(GameManagerPrefab);
		}

		private void Start()
		{
			GameManager.SceneManager.ChangeScene("ShopKeeperLair");
		}
	}
}