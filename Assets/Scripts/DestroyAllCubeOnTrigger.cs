using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllCubeOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

            
            DestroyOnCollision[] objectsToDestroy = FindObjectsByType<DestroyOnCollision>(FindObjectsSortMode.None);

            foreach (DestroyOnCollision obj in objectsToDestroy)
            {
                Destroy(obj.gameObject);
            }
        }
    }
}
