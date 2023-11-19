using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform character;  // The character's transform
    [SerializeField] float followSpeed = 5.0f;
    [SerializeField] float zMargin = -10.0f;

    void Update()
    {
        if (character == null)
            return;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, character.position.z + zMargin);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}