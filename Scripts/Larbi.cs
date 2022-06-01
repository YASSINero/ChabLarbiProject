using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Larbi : MonoBehaviour
{
    [SerializeField]private float speed = 1f, jumpForce = 5f;
    private Vector3 LarbiPos;
    private float posY;
    private SpriteRenderer LarbiSpr;


    private Rigidbody2D LarbiBody;
    private Collider2D LarbiCollider;

    private Animator LarbiAnim;
    //private float posX;

    public AnimatorParameters animParam = new AnimatorParameters();
    

    

    private void Awake()
    {
        LarbiBody = GetComponent<Rigidbody2D>();
        LarbiCollider = GetComponent<Collider2D>();
        LarbiAnim = GetComponent<Animator>();
        LarbiSpr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

        LarbiSpr.flipX = false;


    }

    // FixedUpdate is called each fixed timestep(0.02 s)
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        AnimateLarbi();
        if (transform.localPosition.y >= -1.72f)
        {
            LarbiAnim.SetBool(animParam.boolIsGrounded, false);
        }
        else
        {
            LarbiAnim.SetBool(animParam.boolIsGrounded, true);
        }

        

        





        
    }

    void HandleInput()
    {
        LarbiPos.x = Input.GetAxis("Horizontal");
        transform.position += LarbiPos * Time.deltaTime * speed;

        if(Input.GetButtonDown("Jump") && LarbiAnim.GetBool(animParam.boolIsGrounded))
        {
            LarbiAnim.SetTrigger(animParam.jumped);
            LarbiBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }


    void AnimateLarbi()
    {
        if ((LarbiPos.x > 0 || LarbiPos.x < 0) && LarbiAnim.GetBool(animParam.boolIsGrounded))
        {
            LarbiAnim.SetBool(animParam.boolWalking, true);
            

            

        }
        else
        {
            LarbiAnim.SetBool(animParam.boolWalking, false);
        }

        LarbiSpr.flipX = !(LarbiPos.x < 0);
    }


}
