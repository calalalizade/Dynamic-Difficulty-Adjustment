using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricAiming : MonoBehaviour
{
    #region Datamembers

    #region Editor Settings

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float rotationSpeed = 5f;

    #endregion
    #region Private Fields

    private Camera mainCamera;

    #endregion

    #endregion


    #region Methods

    #region Unity Callbacks

    private void Start()
    {
        // Cache the camera, Camera.main is an expensive operation.
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Aim();
    }

    #endregion

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            Vector3 direction = position - transform.position;

            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction. (Smoothly)
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    #endregion
}
