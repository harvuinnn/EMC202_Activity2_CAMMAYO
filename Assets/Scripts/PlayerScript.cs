using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float rotateSpeed = 200f;
    private bool isRotating = false;
    private bool rotateClockwise = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isRotating)
            {
                StartCoroutine(RotateContinuously());
            }
            else
            {
                rotateClockwise = !rotateClockwise;
            }
        }
    }

    IEnumerator RotateContinuously()
    {
        isRotating = true;
        while (isRotating)
        {
            float direction = rotateClockwise ? 1f : -1f;
            transform.Rotate(new Vector3(0, 0, direction) * rotateSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void StopRotation()
    {
        isRotating = false;
    }
}
