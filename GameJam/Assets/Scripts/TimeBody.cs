using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    public bool isRewinding = false;

    List<PointInTime> pointsInTime;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Rewind"))
        {
            StarRewind();
        }
        if (Input.GetButtonUp("Rewind"))
        {
            StopRewind();
        }

    }

    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            transform.localScale = pointInTime.scale;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
        
    }

    void Record()
    {
        pointsInTime.Insert(0,new PointInTime(transform.position, transform.rotation,transform.localScale));
    }

    public void StarRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
