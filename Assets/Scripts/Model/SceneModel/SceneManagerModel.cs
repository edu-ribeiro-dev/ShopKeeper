using System;
using System.Collections.Generic;

namespace Model.SceneModel
{
	public class SceneManagerModel : BaseModel
	{
		private Dictionary<string, SceneData> DataFromOpenScenes { get; set; }

		public bool ChangingScene { get; set; }
		
		public SceneManagerModel()
		{
			ChangingScene = false;
			DataFromOpenScenes = new Dictionary<string, SceneData>();
		}

		public void AddSceneData(string sceneName, SceneData sceneData)
		{
			DataFromOpenScenes.Add(sceneName, sceneData);
		}

		public SceneData GetSceneData(string sceneName)
		{
			if (!DataFromOpenScenes.TryGetValue(sceneName, out var sceneData))
				throw new InvalidOperationException($"Scene data from {sceneName} doesn't exists");

			return sceneData;
		}

		public void RemoveSceneData(string sceneName)
		{
			DataFromOpenScenes.Remove(sceneName);
		}
	}
}