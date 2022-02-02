using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scene Management/Scene Controller")]
public class SceneController : ScriptableObject
{
    public List<GameScene> gameScenes;

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        for (int i = 0; i < gameScenes.Count; i++)
        {
            if (sceneName == gameScenes[i].sceneName)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.Log("Scene to load not found");
            }
        }
    }

    public void LoadScene(GameScene scene)
    {
        bool sceneFound = false;
        for (int i = 0; i < gameScenes.Count; i++)
        {
            if (scene.sceneName == gameScenes[i].sceneName)
            {
                SceneManager.LoadScene(scene.sceneName);
                sceneFound = true;
            }
        }
        if (!sceneFound)
        {
            Debug.Log("Scene to load not found");
        }
    }
}
