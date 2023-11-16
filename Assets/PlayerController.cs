using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;
    [SerializeField] private StudioEventEmitter effectEmitter;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 x = new Vector2(Input.GetAxisRaw("Horizontal"),0);   
        rb.position += x * speed  * Time.fixedDeltaTime;   

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics2D.gravity *= -1; 
            effectEmitter.Play();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle")) SceneManager.LoadScene(0);
    }
}
