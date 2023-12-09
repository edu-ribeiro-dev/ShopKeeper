using Model;
using UnityEngine;

namespace View
{
	public class PlayerView : MonoBehaviour
	{
		[field: SerializeField]
		private Rigidbody2D Rigidbody { get; set; }

		private PlayerModel PlayerModel { get; set; }

		public void Setup(PlayerModel playerModel)
		{
			PlayerModel = playerModel;
		}

		public void UpdatePosition(float horizontalInputValue, float verticalInputValue)
		{
			var moveSpeed = PlayerModel.CurrentMoveSpeed;
			Rigidbody.velocity = new Vector2(horizontalInputValue * moveSpeed, verticalInputValue * moveSpeed);
		}
	}
}
