using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{

    public Quaternion startOrientation;

    void Start()
    {
        transform.rotation = new Quaternion(startOrientation.x, startOrientation.y, startOrientation.z, startOrientation.w);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
