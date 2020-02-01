using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;
    float halfScreenWidth;
    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize + transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x < -halfScreenWidth)
        {
            transform.position = new Vector2(halfScreenWidth, transform.position.y);
        }
        if (transform.position.x > halfScreenWidth)
        {
            transform.position = new Vector2(-halfScreenWidth, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "FallingBlock")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
