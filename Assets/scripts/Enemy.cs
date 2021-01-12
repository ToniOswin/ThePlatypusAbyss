using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int damage = 1;
    [SerializeField]
    float velocity = 5;

    void Update()
    {
        transform.Translate(Vector2.up * velocity * Time.deltaTime);
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().gameOver == false)
            {
                collision.GetComponent<Player>().LostLife();
                Destroy(gameObject);
            }
        }
    }
}
