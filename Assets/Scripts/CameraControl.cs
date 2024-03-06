using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform targetObject;
    Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        vector = transform.position - targetObject.position;

    }

    // Update is called once per frame
    void Update()
    {
        ToFollow();
    }

    void ToFollow()
    {
        transform.position = targetObject.position + vector;
    }
}
