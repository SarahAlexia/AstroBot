using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
 
    void Start () 
    {
        Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () 
    {
        LockAndUnlockCursor();
	}

    void LockAndUnlockCursor() {

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(Cursor.lockState == CursorLockMode.Locked) 
            {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
    //Cursor can lock and unlock on screen, press esc to unlock.
        }

    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //camera rotation to look up and down.
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //apply to camera transform.
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotate player left and right.
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
 
}
