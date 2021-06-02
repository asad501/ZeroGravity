using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalVelocity : MonoBehaviour
{
   
 public float power;
    private Vector2 initialPosition;
    public float range;
    private bool aiming;

    // Gravity variables
    private float waitTime = 4.0f;
    private float wtimer = 0.0f;

    private bool gravityOff = false;
    private float gravityOffTime = 2.0f;
    private float gtimer = 0.0f;
    private bool started = false;
    Rigidbody2D ball;
    public Camera cam;
    public CircleCollider2D collide;
    public float maxVelocity = 30f;
    public ParticleSystem PS;

    void Start()
    {
        //this.GetComponent<Rigidbody2D>().AddRelativeForce(direction * power);
        this.initialPosition = this.transform.position;
        ball = this.GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("score", 0);
        //  PS = this.GetComponent<ParticleSystem>();
        //  this.initialPosition = this.transform.position;
    }

    public void GetPosition()
    {
        this.initialPosition = this.transform.position;
    }

    void Update()
    {
        if (ball.velocity.magnitude > maxVelocity && started)
        {
            ball.velocity = ball.velocity.normalized * maxVelocity;
        }

    }

    private void OnMouseUp()
    {
        Rigidbody2D rigid = this.GetComponent<Rigidbody2D>();
        aiming = false;


        if (!started)
        {
            rigid.gravityScale = 0.1f;
            collide.isTrigger = false;
            this.started = true;
        }
        Vector2 mousePosition = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diff = (mousePosition - (Vector2)this.transform.position);
        if (diff.magnitude > range)
        {
            diff = (diff.normalized) * range;

        }
        rigid.gravityScale = 0.1f;
        rigid.freezeRotation = true;
        rigid.AddForce(-((Vector2)diff) * power);
    }

    private void OnMouseDown()
    {
        GetPosition();
        aiming = true;
    }

    private void OnDrawGizmos()
    {
        if (!aiming)
        {
         return;
        }
        Vector2 mousePosition = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diff = (mousePosition - (Vector2)this.transform.position);
        if (diff.magnitude > range)
        {
            diff = (diff.normalized) * range;

        }
        DrawLine(this.transform.position, this.transform.position +- (Vector3)diff);
        //Gizmos.DrawLine(this.transform.position, this.transform.position +- (Vector3)diff);
    }


    void DrawLine(Vector3 start, Vector3 end, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }


    private void ImplementGravity()
    {
        //Rigidbody2D ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
         
        if (!gravityOff)
        {
            wtimer += Time.deltaTime;
        }

        // Check if we have reached beyond 4 seconds.
       // if (wtimer > waitTime)
        //{
            // Remove the recorded 4 seconds.
            wtimer -= waitTime;
            print("Gravity Off");

            //ball.velocity *= 0.5f;
            ball.gravityScale = 0.01f;
            gravityOff = true;
           // follow = true;
        //}
        /*
        if (gravityOff)
        {
            gtimer += Time.deltaTime;
            if (gtimer > gravityOffTime && ball.velocity.magnitude > 0)
            {
                // Remove the recorded 2 seconds.
                gtimer -= gravityOffTime;
                print("Gravity On");
                ball.gravityScale = 1f;
                gravityOff = false;
            }
        }
        */
    }

}
