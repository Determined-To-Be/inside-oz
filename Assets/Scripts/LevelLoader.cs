using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void loadLevel(string name)
    {
        SceneManager.GetSceneByName(name);
    }
}
