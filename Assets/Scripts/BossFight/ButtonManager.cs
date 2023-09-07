using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public string sceneName;

    public void OnStartButtonPress()
    {
        Debug.Log("Play Again");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void OnQuitButtonPress()
    {
        Debug.Log("Quit Game");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
