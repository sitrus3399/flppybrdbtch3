using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bird;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //Bird bird = gameObject.GetComponent<Bird>();
        bird = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, bird.transform.position.y, transform.position.z);
        transform.position = bird.position + offset;
    }
}
