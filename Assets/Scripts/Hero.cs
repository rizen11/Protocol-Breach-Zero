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
   public bool isAttacking1 = false;

   public Transform attackPos;
   public float attackRange;
   public Transform attackPos1;
   public float attackRange1;
   public LayerMask enemy;
   private bool facingRight = true;

   private Rigidbody2D rb;
   private Animator anim;
   private SpriteRenderer sprite;
    private float moveInput;
   
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
    lives = 100;
    }
   private void FixedUpdate()
   {
      CheckGround();
   }

   private void Update()
   {
     moveInput = Input.GetAxis("Horizontal");
      if (isGrounded && !isAttacking && !isAttacking1) State = States.idle;
      if (!isAttacking && !isAttacking1 && Input.GetButton("Horizontal"))
        Run();

      if (!isAttacking && !isAttacking1 && isGrounded && Input.GetButtonDown("Jump"))
        Jump();
      if (Input.GetButtonDown("Fire1"))
            Attack();
      if (Input.GetButtonDown("Fire2"))
           AttackAlt();
      if(facingRight ==  false && moveInput >0)
        {
            Flip();
        }
      else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

   private void Run()
   {
      if (isGrounded) State = States.run;
    Vector3 dir = transform.right * Input.GetAxis("Horizontal");
    
    transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

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
    { if (isGrounded && isRecharged && !isAttacking1)
        {
            State = States.attack;
            isAttacking = true;
            isRecharged = false;

            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
        }

        }
    private void AttackAlt()
    {
        if (isGrounded && isRecharged && !isAttacking)
        {
            State = States.attack1;
            isAttacking1 = true;
            isRecharged = false;
            StartCoroutine(Attack1Animation());
            StartCoroutine(AttackCoolDown1());
        }
        }

        private void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Entity>().GetDamage(20);
        }
    }

    private void OnAttack1()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Entity>().GetDamage(50);
        }
    }


    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.9f);
        isAttacking = false;
    }

    private IEnumerator Attack1Animation()
    {
        yield return new WaitForSeconds(1.15f);
        isAttacking1 = false;
    }
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.9f);
        isRecharged = true;
    }

    private IEnumerator AttackCoolDown1()
    {
        yield return new WaitForSeconds(1.14f);
        isRecharged = true;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;  

    }
}

  

   

public enum States
{
   idle,
   run,
   jump,
   attack,
   attack1
}