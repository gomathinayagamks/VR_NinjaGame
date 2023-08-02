using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton pattern
    public static GameManager gm_Instance;
    public GameController gcInstance;
    //public ScoreController scoreController;

    public JsonController jsonController;
    public UIManager uiManager;
    private void Awake()
    {
        if (gm_Instance == null)
        {
            gm_Instance = this;
            //  DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }    
}
