using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public int damage = 1;
    public float speed;
    public GameObject effect;


    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    /*
    void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player_movement>().health -= damage;
            Debug.Log(other.GetComponent<Player_movement>().health);
            Destroy(gameObject);
        }

    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            collision.collider.GetComponent<Player_movement>().health -= damage;
            Debug.Log(collision.collider.GetComponent<Player_movement>().health);

            Destroy(gameObject);
        }
    }
}
