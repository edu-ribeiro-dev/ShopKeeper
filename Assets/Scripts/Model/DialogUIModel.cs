namespace Model
{
	public class DialogUIModel : BaseModel
	{
		public string DialogText { get; set; }
		public string MainButtonText { get; set; }
		public string SecondaryButtonText { get; set; }

		public delegate void OnTextChanged();
		public event OnTextChanged OnTextChangedEvent;

		public DialogUIModel()
		{
			DialogText = "Sample text";
			MainButtonText = "Yes";
			MainButtonText = "No";
		}

		public void SetDialogTexts(string dialogText, string mainButtonText, string secondaryButtonText)
		{
			DialogText = dialogText;
			MainButtonText = mainButtonText;
			SecondaryButtonText = secondaryButtonText;

			OnTextChangedEvent?.Invoke();
		}
	}
}