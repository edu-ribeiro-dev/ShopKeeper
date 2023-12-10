using System;
using Model.SceneModel;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Manager
{
	public class SceneManager : BaseManager
	{
		public SceneManagerModel Model { get; private set; }

		public void Awake()
		{
			Model = new SceneManagerModel();
		}

		public void ChangeScene(string sceneName, SceneData sceneData = null)
		{
			if (Model.ChangingScene)
				return; 

			Model.ChangingScene = true;
			var operation = UnitySceneManager.LoadSceneAsync(sceneName);
			operation.completed += _ => Model.ChangingScene = false;

			if (sceneData != null)
				Model.AddSceneData(sceneName, sceneData);
		}

		public void OpenSceneAdditive(string sceneName, SceneData sceneData = null)
		{
			if (Model.ChangingScene)
				return; 

			Model.ChangingScene = true;
			var operation = UnitySceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			operation.completed += _ => Model.ChangingScene = false;

			if (sceneData != null)
				Model.AddSceneData(sceneName, sceneData);
		}
	
		public void CloseSceneAdditive(string sceneName)
		{
			if (UnitySceneManager.sceneCount <= 1)
				throw new InvalidOperationException("No additive scenes opened");

			if (Model.ChangingScene)
				return;

			Model.ChangingScene = true;
			var operation = UnitySceneManager.UnloadSceneAsync(sceneName);
			operation.completed += _ => Model.ChangingScene = false;

			Model.RemoveSceneData(sceneName);
		}
	}
}