using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public Rigidbody rb;
    public float Amplitude = 0.5f;
    public float Frequency = 1f;
    public float Degrees_per_second = 15.0f;

    Vector3 pos = new Vector3();
    Vector3 temppos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * Degrees_per_second, 0f), Space.World);
        temppos = pos;
        temppos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Frequency) * Amplitude;

        transform.position = temppos;
    }
}