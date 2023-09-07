using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [Header("Components")]
    public Transform targetTransform;
    public GameObject shapePrefab;

    [Header("Variables")]
    public Vector3 spawnLocation;
    [Tooltip("Number of seconds befor shape reaches player")]
    public float time;

    [Header("For memory")]
    private Transform shapeCloneTransform;
    private float speed;
    public bool shapeNotDestroyed;
    public GameObject shapeClone;
    


    


    // Start is called before the first frame update
    void Start()
    {
        shapeClone = Instantiate(shapePrefab, spawnLocation, Quaternion.identity);
        shapeCloneTransform = shapeClone.GetComponent<Transform>();
        shapeNotDestroyed = true;

        speed = Vector2.Distance(shapeCloneTransform.position, targetTransform.position)/(time*100);

    }

    // Update is called once per frame
    void Update()
    {
        if (shapeNotDestroyed)
        {
            shapeCloneTransform.position = Vector3.MoveTowards(shapeCloneTransform.position, targetTransform.position, speed);
            Debug.Log(speed);
        }

    }

    
}
