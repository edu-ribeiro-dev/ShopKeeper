using Controller.ActorController;
using Manager;
using UnityEngine;

namespace Controller.SceneController
{
	public class ShopKeeperLairSceneController : BaseController
	{
		[field: SerializeField]
		private PlayerSpawnController PlayerSpawnController { get; set; }

		private PlayerController PlayerReference { get; set; }

		private void Start()
		{
			PlayerReference = GameManager.Instance.InstantiatePlayer();
			PlayerReference.transform.SetParent(PlayerSpawnController.transform);
		}
	}
}