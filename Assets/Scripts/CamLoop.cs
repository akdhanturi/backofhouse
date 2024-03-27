using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLoop : MonoBehaviour
{
    public List<Transform> camPositions;
    int count = 0;
    Boolean isMoving = false;
    public float camSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = camPositions[count].position;
        transform.rotation = camPositions[count].rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a") && !isMoving)
        {
            count += 1;
            if (count >= camPositions.Count)
            {
                count = 0;
            }
            isMoving = true;
        }

        if (isMoving)
        {
            //move camera to next position
            Vector3 nextPos = camPositions[count].position;
            Quaternion nextRot = camPositions[count].rotation;

            transform.position = Vector3.Lerp(transform.position, nextPos, camSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, camSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, nextPos) < 0.01f)
            {
                transform.position = nextPos;
                transform.rotation = nextRot;
                isMoving = false;
            }
        }
    }

    public void goToCamPos(int pos)
    {
        count = pos;
        isMoving = true;
    }

}