using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleTest : MonoBehaviour
{
    //[Header("This is an inspector")]
    public Transform PublicPlayerTransform;
    private Transform _circleTransform;

    [Range(0f, 1f)]
    public float speed = 0.10f;


    /* 
     * private Transform PrivatePlayerPos;

    [SerializeField] 
    private Transform SerializeFieldPLayerPos;

    [Range(0f, 1f), Tooltip("Range0to1")]
    public float life = 0;
     */

    // Start is called before the first frame update
    void Start()
    {
        _circleTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        _circleTransform.position = Vector3.MoveTowards(_circleTransform.position, PublicPlayerTransform.position, speed);


    }
}
