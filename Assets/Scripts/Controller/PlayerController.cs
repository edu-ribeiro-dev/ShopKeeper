using Model;
using UnityEngine;
using View;

namespace Controller
{
	public class PlayerController : BaseController
	{
		[field: SerializeField]
		private PlayerView PlayerView { get; set; }

		private PlayerModel PlayerModel { get; set; }

		public PlayerController Init(PlayerModel playerModel)
		{
			PlayerModel = playerModel;
			PlayerView.Setup(playerModel);

			return this; 
		}

		public void Update()
		{
			HandleMovement();
		}

		private void HandleMovement()
		{
			var horizontalInput = Input.GetAxisRaw("Horizontal");
			var verticalInput = Input.GetAxisRaw("Vertical");
			PlayerView.UpdatePosition(horizontalInput, verticalInput);
		}
	}
}