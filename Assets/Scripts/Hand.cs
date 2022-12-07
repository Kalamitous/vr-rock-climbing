using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour {
    [SerializeField] public InputActionReference controllerActionPosition;
    [SerializeField] public InputActionReference controllerActionSelect;
    [SerializeField] public GameObject camera;

    private bool onGrip = false;
    private Vector3 gripPos;
    private Vector3 cameraPos;
    
    void Update() {
        if (controllerActionSelect.action.ReadValue<float>() != 0 && Physics.CheckSphere(transform.position, 0.05f)) {
            if (!onGrip) {
                onGrip = true;
                gripPos = controllerActionPosition.action.ReadValue<Vector3>();
                cameraPos = camera.transform.position;
            }
            Vector3 offset = controllerActionPosition.action.ReadValue<Vector3>() - gripPos;
            offset.y = -offset.y;

            camera.transform.position = cameraPos + offset;
        } else {
            onGrip = false;
        }
    }
}
