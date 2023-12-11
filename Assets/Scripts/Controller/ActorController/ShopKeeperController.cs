using Manager;
using Model;
using UnityEngine;
using View;
using SceneData = Model.SceneModel.ShopOverlaySceneModel.ShopOverlaySceneData;

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
			if (Model.ShopOpen)
				return;

			Model.ShopOpen = true;
			GameManager.Instance.SceneManager.OpenSceneAdditive("ShopOverlay", 
				new SceneData(() => 
				{ 
					Model.SetInteracting(false); 
					Model.ShopOpen = false; 
				}));
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