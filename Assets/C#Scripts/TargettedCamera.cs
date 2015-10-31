using UnityEngine;
using System.Collections;
using System;

public class TargettedCamera : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public static Unit target;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {

            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.transform.position);
            Vector3 delta = target.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            velocity = delta * 5f;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

        }

    }

    public static void setTarget(Unit tar)
    {
        target = tar;
    }
}
