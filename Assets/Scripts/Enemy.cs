using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;


    private GameObject player;

    void Start()
    {
        // Trouver le joueur dans la scène
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            // Déplacer l'ennemi vers le joueur
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Recharger la scène en cas de collision avec le joueur
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
