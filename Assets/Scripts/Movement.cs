using System;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] FlyData flyData;
    [SerializeField] GameObject DeathUI;
    public bool crflag = false;

    int mouseFrame = 0; //鼠标长按帧数
    public bool isHold, isHolding = false;
    public Vector2 aposi, fdir;
    public bool timeok = true;

    private Collision coll;
    [HideInInspector]
    public Rigidbody2D rb;
    public GameObject[] orb;
    private AnimationScript anim;

    [Space]
    [Header("Stats")]
    public float speed = 10;
    public float jumpForce = 50;
    public float slideSpeed = 5;
    public float mlimit = 50;
    public float wallJumpLerp = 10;
    public float dashSpeed = 20;

    [Space]
    [Header("Booleans")]
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;

    [Space]

    private bool groundTouch;
    private bool hasDashed;

    public int side = 1;

    [Space]
    [Header("Polish")]
    public ParticleSystem dashParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem wallJumpParticle;
    public ParticleSystem slideParticle;

    public CinemachineVirtualCamera cv;
    public static bool isDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<AnimationScript>();
        orb = GameObject.FindGameObjectsWithTag("Flyable");
        isDeath = false;
        

        foreach (GameObject go in orb)
            go.GetComponent<Rigidbody2D>().gravityScale = flyData.rawGrav;
    }

  

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

         if(isDeath)
         {
            if(crflag==false)
            {
                anim.anim.SetBool("onDeath", true);
                cv.Follow = null;
                Destroy(GetComponent<Collider2D>());
                StartCoroutine(End());

            }
                
         }
         else 
         {
            if (Input.GetMouseButton(0))
            {
                if (isHolding == true)
                {
                    mouseFrame++;//计数
                }
                else if (isHold == true) //第一次确认hold
                {
                    aposi = Input.mousePosition;
                    mouseFrame = 1;
                    isHolding = true;
                }
                else //第一次按
                {
                    isHold = true;
                }
            }
            else//没有按下
            {
                if (isHolding == true)//结束
                {
                    fdir = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - aposi;
                    if (fdir.magnitude <= flyData.minDis && timeok)
                    {
                        //
                    }
                    else if (coll.onGround && fdir.normalized.y <= flyData.startRadius)
                    {

                    }
                    else
                    {
                        Vector2 temp = fdir.normalized * flyData.flySpeed / 10 * (fdir.magnitude > mlimit ? 100 : mouseFrame);
                        rb.velocity += temp;//1 50 1 
                        foreach (GameObject go in orb)
                        {
                            go.GetComponent<Rigidbody2D>().velocity += temp;
                        }
                        StartCoroutine(GravityWait());
                        StartCoroutine(TimeWait());

                    }
                    //Debug.Log(mouseFrame);
                    isHolding = false;
                    isHold = false;
                }
                else if (isHold == true)
                {
                    isHold = false;
                }

            }
        }
        

        IEnumerator End()
        {
            crflag = true;
            
            rb.velocity = new Vector2(0, 5);
            yield return new WaitForSeconds(0.5f);
            rb.velocity = new Vector2(0, 0);
            
            yield return new WaitForSeconds(2f);

            DeathUI.SetActive(true);
        }
        
        IEnumerator GravityWait()
        {
            foreach (GameObject go in orb)
                go.GetComponent<Rigidbody2D>().gravityScale = 0;
            rb.gravityScale = 0;
            yield return new WaitForSeconds(flyData.flyTime);

            foreach (GameObject go in orb)
                go.GetComponent<Rigidbody2D>().gravityScale = flyData.rawGrav;
            rb.gravityScale = flyData.rawGrav;
        }

        IEnumerator TimeWait()
        {
            timeok = false;

            yield return new WaitForSeconds(flyData.minTime);

            timeok = true;
        }

        /*
         * 
                Walk(dir);
                anim.SetHorizontalMovement(x, y, rb.velocity.y);

                if (coll.onWall && Input.GetButton("Fire3") && canMove)
                {
                    if(side != coll.wallSide)
                        anim.Flip(side*-1);
                    wallGrab = true;
                    wallSlide = false;
                }

                if (Input.GetButtonUp("Fire3") || !coll.onWall || !canMove)
                {
                    wallGrab = false;
                    wallSlide = false;
                }

                if (coll.onGround && !isDashing)
                {
                    wallJumped = false;
                    GetComponent<BetterJumping>().enabled = true;
                }

                if (wallGrab && !isDashing)
                {
                    rb.gravityScale = 0;
                    if(x > .2f || x < -.2f)
                    rb.velocity = new Vector2(rb.velocity.x, 0);

                    float speedModifier = y > 0 ? .5f : 1;

                    rb.velocity = new Vector2(rb.velocity.x, y * (speed * speedModifier));
                }
                else
                {
                    rb.gravityScale = 3;
                }

                if(coll.onWall && !coll.onGround)
                {
                    if (x != 0 && !wallGrab)
                    {
                        wallSlide = true;
                        WallSlide();
                    }
                }

                if (!coll.onWall || coll.onGround)
                    wallSlide = false;

                if (Input.GetButtonDown("Jump"))
                {
                    anim.SetTrigger("jump");

                    if (coll.onGround)
                        Jump(Vector2.up, false);
                    if (coll.onWall && !coll.onGround)
                        WallJump();
                }

                if (Input.GetButtonDown("Fire1") && !hasDashed)
                {
                    if(xRaw != 0 || yRaw != 0)
                        Dash(xRaw, yRaw);
                }

                if (coll.onGround && !groundTouch)
                {
                    GroundTouch();
                    groundTouch = true;
                }

                if(!coll.onGround && groundTouch)
                {
                    groundTouch = false;
                }

                WallParticle(y);

                if (wallGrab || wallSlide || !canMove)
                    return;

                if(x > 0)
                {
                    side = 1;
                    anim.Flip(side);
                }
                if (x < 0)
                {
                    side = -1;
                    anim.Flip(side);
                }*/


    }

  /*  void GroundTouch()
    {
        hasDashed = false;
        isDashing = false;

        side = anim.sr.flipX ? -1 : 1;

        jumpParticle.Play();
    }

    private void Dash(float x, float y)
    {
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));

        hasDashed = true;

        anim.SetTrigger("dash");

        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

        rb.velocity += dir.normalized * dashSpeed;
        StartCoroutine(DashWait());
    }*/

 /*   IEnumerator DashWait()
    {
        FindObjectOfType<GhostTrail>().ShowGhost();
        StartCoroutine(GroundDash());
        DOVirtual.Float(14, 0, .8f, RigidbodyDrag);

        dashParticle.Play();
        rb.gravityScale = 0;
        GetComponent<BetterJumping>().enabled = false;
        wallJumped = true;
        isDashing = true;

        yield return new WaitForSeconds(.3f);

        dashParticle.Stop();
        rb.gravityScale = 3;
        GetComponent<BetterJumping>().enabled = true;
        wallJumped = false;
        isDashing = false;
    }

    IEnumerator GroundDash()
    {
        yield return new WaitForSeconds(.15f);
        if (coll.onGround)
            hasDashed = false;
    }

    private void WallJump()
    {
        if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
        {
            side *= -1;
            anim.Flip(side);
        }

        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.1f));

        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        Jump((Vector2.up / 1.5f + wallDir / 1.5f), true);

        wallJumped = true;
    }

    private void WallSlide()
    {
        if(coll.wallSide != side)
         anim.Flip(side * -1);

        if (!canMove)
            return;

        bool pushingWall = false;
        if((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
        {
            pushingWall = true;
        }
        float push = pushingWall ? 0 : rb.velocity.x;

        rb.velocity = new Vector2(push, -slideSpeed);
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (wallGrab)
            return;

        if (!wallJumped)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    private void Jump(Vector2 dir, bool wall)
    {
        slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
        ParticleSystem particle = wall ? wallJumpParticle : jumpParticle;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

        particle.Play();
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }

    void WallParticle(float vertical)
    {
        var main = slideParticle.main;

        if (wallSlide || (wallGrab && vertical < 0))
        {
            slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
            main.startColor = Color.white;
        }
        else
        {
            main.startColor = Color.clear;
        }
    }

    int ParticleSide()
    {
        int particleSide = coll.onRightWall ? 1 : -1;
        return particleSide;
    }*/
}
