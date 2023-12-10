using System;
using UnityEngine;

namespace Model.SceneModel
{
	public class ShopOverlaySceneModel : BaseModel
	{
		public enum ShopState
		{
			Unknown,
			SceneOptions,
			ShopOpen,
			InventoryOpen
		}

		private ShopState CurrentState { get; set; }

		public delegate void OnStateChanged(ShopState newState);
		public event OnStateChanged OnStateChangedEvent;

		public bool ClosingScene { get; set; }

		public void ChangeShopState(ShopState newState)
		{
			if (CurrentState == newState)
			{
				Debug.Log($"Trying to change to same state: {CurrentState.ToString()}");
				return;
			}

			CurrentState = newState switch
			{
				ShopState.SceneOptions => newState,
				ShopState.ShopOpen => newState,
				ShopState.InventoryOpen => newState,
				_ => throw new ArgumentOutOfRangeException(nameof(newState), newState, null)
			};

			OnStateChangedEvent?.Invoke(newState);
		}

		public class ShopOverlaySceneData : SceneData
		{
			public Action OnCloseCallback { get; }

			public ShopOverlaySceneData(Action onCloseCallback)
			{
				OnCloseCallback = onCloseCallback;
			}
		}
	}
}