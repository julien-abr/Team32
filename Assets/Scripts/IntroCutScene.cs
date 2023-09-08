using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutScene : MonoBehaviour
{
    public Animator animator;
    public string SceneName;

    public void Start()
    {
        animator.SetTrigger("Test");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
