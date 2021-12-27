using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float xDiff, yDiff;
    [Range(1,100)]
    public float smoothFactor;
    [Range(1, 100)]
    public float camSpeed;

    private float targetXPos, targetYPos, camXPos, camYPos;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        camXPos = transform.position.x;
        camYPos = transform.position.y;
        targetXPos = target.position.x;
        targetYPos = target.position.y;
        

        if((Mathf.Abs(camXPos - targetXPos) > xDiff) || (Mathf.Abs(camYPos - targetYPos) > yDiff))
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, ((100 - smoothFactor) / 10) * Time.fixedDeltaTime * (camSpeed/10));
            transform.position = smoothPosition;
        }
    }
}
