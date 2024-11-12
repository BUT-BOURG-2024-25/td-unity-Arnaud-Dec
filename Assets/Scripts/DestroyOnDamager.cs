using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDamager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damager")
        {
            Destroy(gameObject);
        }
    }
}
