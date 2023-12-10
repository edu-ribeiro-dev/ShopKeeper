using Controller.LayoutController;
using Manager;
using Model.SceneModel;
using UnityEngine;
using View.SceneView;
using ShopOverlaySceneData = Model.SceneModel.ShopOverlaySceneModel.ShopOverlaySceneData;

namespace Controller.SceneController
{
	public class ShopOverlaySceneController : BaseController
	{
		[field: SerializeField]
		private ShopOverlaySceneView View { get; set; }

		private ShopOverlaySceneModel Model { get; set; }

		[field: SerializeField]
		private ShopController ShopController { get; set; }

		[field: SerializeField]
		private InventoryController InventoryController { get; set; }

		private ShopOverlaySceneController Init()
		{
			Model = new ShopOverlaySceneModel();
			View.Setup(Model, OnBuyClicked, OnSellClicked, OnCloseClicked);

			ShopController.Init(OnInternalBackClicked);
			InventoryController.Init(OnInternalBackClicked);
			SetDefaultState();

			SetInitialized();
			return this;
		}

		private void Awake()
		{
			Init();
		}

		private void OnBuyClicked()
		{
			Model.ChangeShopState(ShopOverlaySceneModel.ShopState.ShopOpen);
		}

		private void OnSellClicked()
		{
			Model.ChangeShopState(ShopOverlaySceneModel.ShopState.InventoryOpen);
		}

		private void OnCloseClicked()
		{
			CloseScene();
		}

		private void CloseScene()
		{
			if (Model.ClosingScene)
				return;

			var sceneManager = GameManager.Instance.SceneManager;
			var sceneData = sceneManager.Model.GetSceneData("ShopOverlay") as ShopOverlaySceneData;
			sceneData?.OnCloseCallback.Invoke();

			sceneManager.CloseSceneAdditive("ShopOverlay");
		}

		private void OnInternalBackClicked()
		{
			SetDefaultState();
		}

		private void SetDefaultState()
		{
			Model.ChangeShopState(ShopOverlaySceneModel.ShopState.SceneOptions);
		}
	}
}
