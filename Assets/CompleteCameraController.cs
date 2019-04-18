using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    float yVal = 0f;
    public Camera camera = Camera.main;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

        // check if player is leaving camera view (Y-axis)        
        //if (player.transform.position.y > transform.position.y + camera.aspect)
        //{
        //}

        // only use X axis for camera when player is within camera view
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        
        transform.position = playerPosition + offset;
    }
}