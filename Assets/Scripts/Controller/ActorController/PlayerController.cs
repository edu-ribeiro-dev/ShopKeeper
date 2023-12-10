using Model;
using UnityEngine;
using View;

namespace Controller.ActorController
{
	public class PlayerController : BaseController
	{
		[field: SerializeField]
		private PlayerView View { get; set; }

		private PlayerModel Model { get; set; }

		public PlayerController Init(PlayerModel playerModel)
		{
			Model = playerModel;
			View.Setup(playerModel);

			base.SetInitialized();
			return this; 
		}

		public void Update()
		{
			CheckInitialized();

			HandleMovementInput();
			HandleActionInput();
		}

		private void HandleMovementInput()
		{
			var horizontalInput = Input.GetAxisRaw("Horizontal");
			var verticalInput = Input.GetAxisRaw("Vertical");
			View.UpdatePosition(horizontalInput, verticalInput);
		}

		private void HandleActionInput()
		{
			var interactionButtonPressed = Input.GetButtonDown("Submit");

			if (!interactionButtonPressed)
				return;
			
			Debug.Log("Acted");

			var collidingList = View.GetCollidingObjects();
			if (collidingList.Count == 0)
				return;

			foreach (var collidingObject in collidingList)
			{
				if (collidingObject.TryGetComponent<InteractableController>(out var interactable))
				{
					if (interactable.TryInteractWith())
						break;
				}
			}
		}
	}
}