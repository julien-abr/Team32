using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuInput : MonoBehaviour
{
    public UnityEvent action;
    public KeyCode key;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && action != null)
        {
            action.Invoke();
        }
    }
}
