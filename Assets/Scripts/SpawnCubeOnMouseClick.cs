using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class SpawnCubeOnMouseClick : MonoBehaviour
{

    [SerializeField]
    private LayerMask GroundLayer;

    [SerializeField]
    private GameObject objectToSpawn;


  

    private void Start()
    {
        input_manager.Instance.RegisterOnClick(onCLick, true);
        input_manager.Instance.FingerDownAction += OnFingerDown;
    }

    private void OnDestroy()
    {
        input_manager.Instance.RegisterOnClick(onCLick, false);
        input_manager.Instance.FingerDownAction -= OnFingerDown;
    }

    private void OnFingerDown(Vector2 screenPosition)
    {
        SpawnCube(screenPosition);
    }

    private void SpawnCube(Vector2 screenPosition)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        bool raycastHasHit = Physics.Raycast(cameraRay, out hitInfo, 10000, GroundLayer);

        if (raycastHasHit && objectToSpawn != null)
        {
            GameObject.Instantiate(objectToSpawn, hitInfo.point + Vector3.up * 0.5f, Quaternion.identity);
        }
    }

    private void onCLick(InputAction.CallbackContext callbackContext)
    {
        SpawnCube(Input.mousePosition);
    }

}