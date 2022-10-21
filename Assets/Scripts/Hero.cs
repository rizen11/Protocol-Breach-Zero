using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
   [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;
   private bool isGrounded = false;

   public bool isAttacking = false;
   public bool isRecharged = true;

   public Transform attackPos;
   public float attackRange;
   public LayerMask enemy;

   private Rigidbody2D rb;
   private Animator anim;
   private SpriteRenderer sprite;
   
   public static Hero Instance {get;set;}

   private States State
   {
      get {return (States)anim.GetInteger("state");}
      set {anim.SetInteger("state",(int)value);}
   }

   private void Awake()
   {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sprite = GetComponentInChildren<SpriteRenderer>();    
    Instance = this;
    isRecharged = true;
    lives = 5;
    }
   private void FixedUpdate()
   {
      CheckGround();
   }

   private void Update()
   {
      if (isGrounded && !isAttacking) State = States.idle;
    if (!isAttacking && Input.GetButton("Horizontal"))
        Run();

    if (!isAttacking && isGrounded && Input.GetButtonDown("Jump"))
      Jump();
        if (Input.GetButtonDown("Fire1"))
            Attack();
   }

   private void Run()
   {
      if (isGrounded) State = States.run;
    Vector3 dir = transform.right * Input.GetAxis("Horizontal");
    
    transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    sprite.flipX = dir.x < 0.0f;
   }
   
   private void Jump()
   {
      rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
   }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }
    private void CheckGround()
   {
      Collider2D[] collider =Physics2D.OverlapCircleAll(transform.position, 0.3f);
      isGrounded = collider.Length >1;
      
      if (!isGrounded) State = States.jump;
   }
  
    private void Attack()
    { if (isGrounded && isRecharged)
        {
            State = States.attack;
            isAttacking = true;
            isRecharged = false;

            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
        }
    
                }
    private void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Entity>().GetDamage();
        }
    }
    
    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.9f);
        isAttacking = false;
    }    
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.9f);
        isRecharged = true;
    }
}

  

   

public enum States
{
   idle,
   run,
   jump,
   attack
}