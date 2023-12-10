using System;
using Model;
using UnityEngine;

namespace Controller.ActorController
{
	[RequireComponent(typeof(Collider2D))]
	public class InteractableController : BaseController
	{
		private InteractableModel InteractableModel { get; set; }
		private Action OnInteractAction { get; set; }
		private Action OnInteractionEndAction { get; set; }

		public InteractableController Init(Action onInteract, Action onInteractionEnd = null)
		{
			InteractableModel = new InteractableModel();
			OnInteractAction = onInteract;
			OnInteractionEndAction = onInteractionEnd;

			SetInitialized();
			return this;
		}

		public bool TryInteractWith()
		{
			CheckInitialized();

			if (InteractableModel.IsInteracting)
				return false;

			InteractableModel.IsInteracting = true;
			OnInteract();

			return true;
		}

		private void OnInteract()
		{
			OnInteractAction?.Invoke();
			Debug.Log($"Interacted with {transform.parent.name}");
			OnInteractionEnd();
		}

		private void OnInteractionEnd()
		{
			OnInteractionEndAction?.Invoke();
			InteractableModel.IsInteracting = false;
		}
	}
}