using System;
using Model;
using UnityEngine;
using View;

namespace Controller
{
	public class DialogUIController : BaseController
	{
		[field: SerializeField]
		private DialogUIView View { get; set; }
		
		private DialogUIModel Model { get; set; }

		public DialogUIController Init(Action onMainButtonClicked,
			Action onSecondaryButtonClicked,
			string dialogText,
			string mainButtonText,
			string secondaryButtonText)
		{
			Model = new DialogUIModel();

			View.Setup(Model, onMainButtonClicked, onSecondaryButtonClicked);

			Model.SetDialogTexts(dialogText, mainButtonText, secondaryButtonText);

			SetInitialized();
			return this; 
		}

		public void Show()
		{
			View.Show();
		}

		public void Hide()
		{
			View.Hide();
		}
	}
}