using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
	public class PlayerView : BaseView
	{
		private PlayerModel Model { get; set; }

		[field: SerializeField]
		private PlayerSkinView SkinView { get; set; }

		[field: SerializeField]
		private Rigidbody2D Rigidbody { get; set; }

		[field: SerializeField]
		private Collider2D InteractionCollider { get; set; }

		public void Setup(PlayerModel playerModel)
		{
			Model = playerModel;
			SkinView.Setup(playerModel);
		}

		public void UpdatePosition(float horizontalInputValue, float verticalInputValue)
		{
			var moveSpeed = Model.CurrentMoveSpeed;
			Rigidbody.velocity = new Vector2(horizontalInputValue * moveSpeed, verticalInputValue * moveSpeed);
		}

		public List<Collider2D> GetCollidingObjects()
		{
			var outputColliders = new List<Collider2D>();
			InteractionCollider.OverlapCollider(new ContactFilter2D(), outputColliders);

			return outputColliders;
		}
	}
}
