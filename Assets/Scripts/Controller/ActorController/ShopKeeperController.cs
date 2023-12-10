using Manager;
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
			InteractableController.Init(OpenShop);

			SetInitialized();
			return this;
		}

		private void OpenShop()
		{
			GameManager.Instance.SceneManager.OpenSceneAdditive("ShopOverlay");
		}

		public ShopKeeperController InitPreviewMode()
		{
			View.SetupPreviewMode("What're ya buyin??");
			return this; 
		}

		private void Awake()
		{
			Init();
		}
	}
}