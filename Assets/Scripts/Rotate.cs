using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + (Time.deltaTime * speed));
    }
}
