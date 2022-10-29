using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : Entity
{
    [SerializeField] private int lives;
    [SerializeField] private float speed = 1.5f;
    private Vector3 direction;
    private SpriteRenderer sprite;
    private RoomController room;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        room = GetComponentInParent<RoomController>();
    }

    private void Start()
    {
        direction = transform.right; 
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * direction.x * 0.7f, 0.1f);

        if (colliders.Length > 0) direction *= -10f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);
        sprite.flipX = direction.x > 0.0f;

    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage(1);
        }
    }

    public override void Die()
    {
        room.enemies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}