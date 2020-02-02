using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newparallax : MonoBehaviour
{
    public float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public GameObject player;
    private Vector3 offset;


    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        offset = cam.transform.position - player.transform.position;
    }

    
    void FixedUpdate()
    {
        cam.transform.position = new Vector3(player.transform.position.x, -0.3f, player.transform.position.z) + offset;
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;

    }
}
