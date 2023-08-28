using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines the borders of ‘Player’s’ movement. Depending on the chosen handling type, it moves the ‘Player’ together with the pointer.
/// </summary>

[System.Serializable]
public class Borders
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class PlayerMoving : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform mainCamera;

    private Vector2 joystickInput;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();                //setting 'Player's' moving borders deending on Viewport's size
    }
	
	private void Update()
    {
        if (controlIsActive)
        {
	
	
			if (isButtonPressed)
    {
		
        // Get joystick input
        joystickInput.x = Input.GetAxis("Horizontal");
        joystickInput.y = Input.GetAxis("Vertical");

        // Calculate joystick movement direction
        Vector3 moveDirection = new Vector3(joystickInput.x, joystickInput.y, 0);

        // Calculate joystick movement vector
        Vector3 moveVector = moveDirection.normalized * moveSpeed * Time.deltaTime;

        // Move the object based on joystick input
        transform.Translate(moveVector);

        // Keep the object's z position the same as the camera's z position
        Vector3 newPosition = transform.position;
        newPosition.z = mainCamera.position.z;
        transform.position = newPosition;
		}
	}
}		