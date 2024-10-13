using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves
    private Transform moveTarget; // Target where the object will move

    void Update()
    {
        if (moveTarget != null)
        {
            // Move towards the assigned target
            transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);
        }
    }

    // This method will be called by the RandomSpawner to set the target
    public void SetTarget(Transform target)
    {
        moveTarget = target;
    }
}
