using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLocations : MonoBehaviour
{
    public List<Transform> locations; // Assign the target locations in the inspector
    public float easeIn = 0.3f; // Adjust for easing - not directly used in this version but you can enhance the interpolation based on this
    public float easeOut = 0.3f; // Adjust for easing - not directly used in this version but you can enhance the interpolation based on this
    public float movementDuration = 2.0f; // Time it takes to move from current position to the target location
    public AudioClip movementSound; // Assign this in the inspector with your movement sound clip

    private AudioSource audioSource; // The AudioSource component

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (!audioSource)
        {
            // Log a warning if no AudioSource is found
            Debug.LogWarning("Missing AudioSource component on GameObject.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            StartCoroutine(MoveObject(0));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartCoroutine(MoveObject(1));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            StartCoroutine(MoveObject(2));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            StartCoroutine(MoveObject(3));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartCoroutine(MoveObject(4));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            StartCoroutine(MoveObject(5));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            StartCoroutine(MoveObject(6));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            StartCoroutine(MoveObject(7));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            StartCoroutine(MoveObject(8));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            StartCoroutine(MoveObject(9));
        }
        // Repeat for other keys as needed
    }

    IEnumerator MoveObject(int targetLocationIndex)
    {
        if (targetLocationIndex >= 0 && targetLocationIndex < locations.Count)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = locations[targetLocationIndex].position;
            float elapsedTime = 0;

            // Play the movement sound effect
            if (audioSource && movementSound)
            {
                audioSource.clip = movementSound;
                audioSource.Play();
            }

            while (elapsedTime < movementDuration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0.0f, 1.0f, elapsedTime / movementDuration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the object has reached the end position
            transform.position = endPosition;

            // Optionally, stop the movement sound when the movement is complete
            if (audioSource && movementSound)
            {
                audioSource.Stop();
            }
        }
    }
}
