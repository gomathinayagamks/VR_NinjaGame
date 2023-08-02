using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    CanvasGroup canvasGroup;

    public void LoadThisScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)){
            LoadThisScene("FruitNinja");
        } 
         if (Input.GetKeyDown(KeyCode.C)){
            LoadThisScene("CakeNinja");
        }
    }
}
