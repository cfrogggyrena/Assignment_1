using System;
using System.Numerics;
using UnityEngine;

public class NpcWalk : MonoBehaviour
{
    public Transform pointOne;
    public Transform pointTwo;
    public float speed = 5f;

    private Animator anim; 

    private bool movingToPointTwo = true;

    private UnityEngine.Quaternion npcRotation1;
    private UnityEngine.Quaternion npcRotation2;


    void Start()
    {
        npcRotation1 = transform.rotation;
        npcRotation2 = new UnityEngine.Quaternion(0, npcRotation1.x + 360, 0, 0); 
    }

    void Update()
    {
        // Get current position
        UnityEngine.Vector3 currentPos = transform.position;

        // Determine target X position
        float targetX = movingToPointTwo ? pointTwo.position.x : pointOne.position.x;

        // Move only on X axis
        float newX = Mathf.MoveTowards(
            currentPos.x,
            targetX,
            speed * Time.deltaTime
        );

        transform.position = new UnityEngine.Vector3(newX, currentPos.y, currentPos.z);

        // Switch direction when target is reached
        if (Mathf.Abs(newX - targetX) < 0.01f)
        {
            movingToPointTwo = !movingToPointTwo;
        }

        transform.rotation = movingToPointTwo ? npcRotation1 : npcRotation2; 

        
    }
}
