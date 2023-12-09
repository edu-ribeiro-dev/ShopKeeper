using Manager;
using UnityEngine;

namespace Controller
{
	public class LaunchScene : BaseController
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