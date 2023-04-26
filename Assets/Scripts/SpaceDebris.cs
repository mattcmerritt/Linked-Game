using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDebris : MonoBehaviour
{
    [SerializeField] private Vector2 InitialVelocity = Vector2.zero;
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Animator Ani;
    [SerializeField, Range(0f, 10f)] private float MaxSpeed;

    [SerializeField] private float ScreenBoundX, ScreenBoundY;

    protected void Start()
    {
        while (InitialVelocity.magnitude <= 0)
        {
            InitialVelocity = new Vector2(Random.Range(0f, MaxSpeed), Random.Range(0f, MaxSpeed));
        }
        Rb.velocity = InitialVelocity;
    }

    protected void Update()
    {
        if (transform.position.x < -ScreenBoundX || transform.position.x > ScreenBoundX || transform.position.y < -ScreenBoundY || transform.position.y > ScreenBoundY)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ani.SetTrigger("Destroy");
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
