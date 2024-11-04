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

    }

    private void OnDestroy()
    {
        input_manager.Instance.RegisterOnClick(onCLick, false);
    }

    private void onCLick(InputAction.CallbackContext callbackContext)
    {
       Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        bool raycastHasHit = Physics.Raycast(cameraRay, out hitInfo, 10000, GroundLayer);

        if (raycastHasHit && objectToSpawn != null)
        {
            GameObject.Instantiate(objectToSpawn, hitInfo.point + Vector3.up *0.5f, Quaternion.identity);
        }
    }

}
