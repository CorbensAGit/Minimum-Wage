using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;

    List<TimePoint> TimePoints;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        TimePoints = new List<TimePoint>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartRewind();
        }

    }

    void FixedUpdate()
    {
        if (isRewinding) {
            Rewind();
        } else {
            Record();
        }
    }

    void Rewind ()
    {
        if (TimePoints.Count > 0)
        {
            TimePoint timePoint = TimePoints[0];
            transform.position = timePoint.position;
            transform.rotation = timePoint.rotation;
            rb.velocity = timePoint.velocity;
            TimePoints.RemoveAt(0);
        } else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if (TimePoints.Count > Mathf.Round(2f / Time.fixedDeltaTime))
        {
            TimePoints.RemoveAt(TimePoints.Count-1);
        }
        TimePoints.Insert(0, new TimePoint(transform.position, transform.rotation, rb.velocity));
    }

    public void StartRewind()
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
