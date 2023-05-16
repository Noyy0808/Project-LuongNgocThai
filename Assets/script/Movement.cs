using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public enum Speeds { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4, Stop = 5 };
public enum Gamemodes { Cube = 0, Ship = 1, Wave = 2 };




public class Movement : MonoBehaviour
{
    public Speeds CurrentSpeed;
    public Gamemodes CurrentGamemode;

    //                        0    1       2      3        4
    float[] SpeedValues = { 12.6f, 14.4f, 16.96f, 20.6f, 25.27f, 0f };
    


    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Transform Sprite;
    Rigidbody2D rb;

    int Gravity = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Transform lay vi tri di chuyyen
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;

        //if (rb.velocity.y < -24.2f)
        //    rb.velocity = new Vector2(rb.velocity.x, 24.2f);

        Invoke(CurrentGamemode.ToString(), 0);
        
    }

    //?? ki?m tra xem ??i t??ng hi?n t?i có ?ang ??t trên m?t ??t hay không.
    // fix lai thanh check _ duoi
    bool OnGround()
    {
        // toi uu, xoa bien groundcheck     transform.position + Vector3.down * Gravity * 0.5f, Vector2.right * 1.1f + Vector2.up * GroundCheckRadius, 0, GroundMask
        return Physics2D.OverlapBox(GroundCheckTransform.position + Vector3.up - Vector3.up*(Gravity - 1 / - 2), Vector2.right * 1.1f + Vector2.up * GroundCheckRadius, 0, GroundMask);
    }

    //bool TouchingWall()
    //{
    //    return Physics2D.OverlapBox((Vector2)transform.position + (Vector2.right * 0.55f), Vector2.up * 0.8f + (Vector2.right * GroundCheckRadius), 0, GroundMask);
    //}

    void Cube()
    {
        if (OnGround())
        {
            //xoay
            Vector3 Rotation = Sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            Sprite.rotation = Quaternion.Euler(Rotation);

            //Nhay?
            if (Input.GetMouseButton(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 30.6581f * Gravity, ForceMode2D.Impulse);
            }
        }
        else
        {
            Sprite.Rotate(Vector3.back, 452f * Time.deltaTime * Gravity);
        }

        GetComponent<TrailRenderer>().enabled = false;

    }

    void Ship()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 2);
        if (Input.GetMouseButton(0))
        {
            rb.gravityScale = -4.3f;
        }
        else
        {
            rb.gravityScale = 4.3f;
        }

        rb.gravityScale = rb.gravityScale * Gravity;

        GetComponent<TrailRenderer>().enabled = true;

    }

    void Wave()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, SpeedValues[(int)CurrentSpeed] * (Input.GetMouseButton(0) ? 1 : -1) * Gravity);
        // B?t Trail Renderer c?a player
        GetComponent<TrailRenderer>().enabled = true;


        //change sprite

        //SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //Sprite newSpriteImage = Resources.Load<Sprite>("Sprites/wave");
        //spriteRenderer.sprite = newSpriteImage;
   
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Speed Up")
    //    {
    //        if (CurrentSpeed < Speeds.Fastest)
    //        {
    //            CurrentSpeed++;
    //            Debug.Log("Speed Up");
    //        }
    //    }
    //    else if (other.tag == "Speed Down")
    //    {   
    //        if(CurrentSpeed > Speeds.Slow)
    //        {
    //            CurrentSpeed--;
    //            Debug.Log("Speed Down");
    //        }

    //    }

    //}

    public void ChangeThroughPortal(Gamemodes Gamemode,  Speeds Speed, int gravity, int State)
    {
        switch(State)
        {
            case 0:
                CurrentSpeed = Speed;
                break;
            case 1:
                CurrentGamemode = Gamemode;
                break;
            case 2:
                Gravity = gravity;
                rb.gravityScale = Mathf.Abs(rb.gravityScale) * (int)gravity;
                break;


        }
    }

    



}
