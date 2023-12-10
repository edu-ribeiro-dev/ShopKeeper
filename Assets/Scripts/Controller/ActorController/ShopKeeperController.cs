using Model;
using UnityEngine;
using View;

namespace Controller.ActorController
{
	public class ShopKeeperController : BaseController
	{
		[field: SerializeField]
		private ShopKeeperView View { get; set; }

		private ShopKeeperModel Model { get; set; }
		
		[field: SerializeField]
		private InteractableController InteractableController { get; set; }

		private ShopKeeperController Init()
		{
			Model = new ShopKeeperModel();
			InteractableController.Init(() => Debug.Log("Action 1"), () => Debug.Log("Action 2"));

			SetInitialized();
			return this;
		}

		private void Awake()
		{
			Init();
		}
	}
}