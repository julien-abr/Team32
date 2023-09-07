using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    //public CapsuleCollider2D targetCollider;
    BossManager bossManager;


    // Start is called before the first frame update
    void Start()
    {
        bossManager = GameObject.Find("BossManagerObject").GetComponent<BossManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D targetCollider)
    {
        Debug.Log("bang!");

        bossManager.shapeNotDestroyed = false;
    }
}
