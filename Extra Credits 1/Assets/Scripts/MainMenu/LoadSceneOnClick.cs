using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : UnityEngine.MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
