#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class Bootstrapper
{
	static Bootstrapper()
	{
		var defaultScenePath = EditorBuildSettings.scenes[0].path;
		var defaultScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(defaultScenePath);
		EditorSceneManager.playModeStartScene = defaultScene;
	}
}

#endif