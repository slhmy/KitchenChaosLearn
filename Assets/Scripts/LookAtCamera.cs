using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {


    private enum Mode {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }


    [SerializeField] private Mode mode;
    private Camera _mainCamera;
    
    private void Start() {
        _mainCamera = Camera.main;
    }

    private void LateUpdate() {
        switch (mode) {
            case Mode.LookAt:
                transform.LookAt(_mainCamera.transform);
                break;
            case Mode.LookAtInverted:
                Vector3 curPosition = transform.position;
                Vector3 dirFromCamera = curPosition - _mainCamera.transform.position;
                transform.LookAt(curPosition + dirFromCamera);
                break;
            case Mode.CameraForward:
                transform.forward = _mainCamera.transform.forward;
                break;
            case Mode.CameraForwardInverted:
                transform.forward = -_mainCamera.transform.forward;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

}