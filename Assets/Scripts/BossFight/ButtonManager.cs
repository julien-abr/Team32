using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void OnStartButtonPress()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Shane", LoadSceneMode.Single);
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
