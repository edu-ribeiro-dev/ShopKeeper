using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
	public class GameManager : BaseManager
	{
		public static GameManager Instance { get; private set; }

		private void Awake()
		{
			if (Instance is not null && Instance != this)
			{
				Destroy(this);
			}
			else
			{
				Instance = this;
			}

			DontDestroyOnLoad(this);
		}

		public static void ChangeScene(string sceneName)
		{
			SceneManager.LoadSceneAsync(sceneName);
		}
	}
}