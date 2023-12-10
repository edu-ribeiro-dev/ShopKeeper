using System;
using Manager;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : BaseManager
{
	private bool ChangingScene { get; set; } 

	public void ChangeScene(string sceneName)
	{
		if (ChangingScene)
			return; 

		ChangingScene = true;
		var operation = UnitySceneManager.LoadSceneAsync(sceneName);
		operation.completed += _ => ChangingScene = false;
	}

	public void OpenSceneAdditive(string sceneName)
	{
		if (ChangingScene)
			return; 

		ChangingScene = true;
		var operation = UnitySceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		operation.completed += _ => ChangingScene = false;
	}
	
	public void CloseSceneAdditive()
	{
		if (UnitySceneManager.sceneCount <= 1)
			throw new InvalidOperationException("No additive scenes opened");

		if (ChangingScene)
			return;

		ChangingScene = true;
		var operation = UnitySceneManager.UnloadSceneAsync(UnitySceneManager.GetActiveScene());
		operation.completed += _ => ChangingScene = false;
	}
}