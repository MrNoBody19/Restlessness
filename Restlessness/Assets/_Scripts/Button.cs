using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadingScene()
    {
        SceneManager.LoadScene(sceneToLoad); 
    }
    
}
