using System;
using Manager;
using UnityEngine;

namespace Controller
{
	public class ShopKeeperLairScene : BaseController
	{
		[field: SerializeField]
		private PlayerSpawnController PlayerSpawnController { get; set; }

		private void Start()
		{
			var player = GameManager.Instance.InstantiatePlayer();
			player.transform.SetParent(PlayerSpawnController.transform);
		}
	}
}