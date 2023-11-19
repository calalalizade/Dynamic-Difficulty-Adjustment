using UnityEngine;

namespace Scripts.FPS
{
    public class DistanceTravelled : MonoBehaviour
    {
        private Vector3 lastPosition;
        private GameManager gameManager;

        void Start()
        {
            lastPosition = transform.position;
            gameManager = GameManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            // Get the current position of the player
            Vector3 currentPosition = transform.position;

            // Calculate the distance traveled since the last frame
            float distanceThisFrame = Vector3.Distance(currentPosition, lastPosition);

            // Update the total distance in the GameManager
            gameManager.UpdateDistance(distanceThisFrame);

            // Update the last position to the current position for the next frame
            lastPosition = currentPosition;
        }
    }
}