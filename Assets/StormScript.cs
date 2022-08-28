using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormScript : MonoBehaviour
{
    [SerializeField] private float startPos = 17;
    [SerializeField] private float endPos = -17;
    [SerializeField] private float speed;

    private Vector3 pos;
    private Vector3 startVector;
    private Vector3 endVector;

    private void Start()
    {
        pos = new Vector3(speed, 0, 0);
        startVector = transform.position;
        startVector.x = startPos;

        endVector = transform.position;
        endVector.x = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(pos * Time.deltaTime);
        if (transform.position.x >= endPos)
            transform.position = startVector;
    }
}
