using System;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
	public class DialogUIView : BaseView
	{
		private DialogUIModel Model { get; set; }
		
		[field: SerializeField]
		private TextMeshProUGUI DialogText { get; set; }

		[field: SerializeField]
		private Button MainButton { get; set; }

		[field: SerializeField]
		private TextMeshProUGUI MainButtonText { get; set; }

		[field: SerializeField]
		private Button SecondaryButton { get; set; }

		[field: SerializeField]
		private TextMeshProUGUI SecondaryButtonText { get; set; }
		
		[field: SerializeField]
		private CanvasGroup CanvasGroup { get; set; }

		public void Setup(DialogUIModel model, Action onMainButtonClicked, Action onSecondaryButtonClicked)
		{
			Model = model;
			MainButton.onClick.AddListener(() => onMainButtonClicked());
			SecondaryButton.onClick.AddListener(() => onSecondaryButtonClicked());

			Model.OnTextChangedEvent += UpdateTexts;
			Hide();
		}

		private void UpdateTexts()
		{
			DialogText.SetText(Model.DialogText);
			MainButtonText.SetText(Model.MainButtonText);
			SecondaryButtonText.SetText(Model.SecondaryButtonText);
		}

		public void Show()
		{
			CanvasGroup.alpha = 1;
		}

		public void Hide()
		{
			CanvasGroup.alpha = 0;
		}

		private void OnDestroy()
		{
			Model.OnTextChangedEvent -= UpdateTexts;
		}
	}
}