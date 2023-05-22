using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMario : MonoBehaviour
{
    float vantoc = 7;
    float nhayCao = 10;
    float roixuong = 5;
    private float tocdo=0;
    private bool duoidat=true;
    private bool chuyenhuong=false;
    private bool QuayPhai = true;
    private Rigidbody2D r2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("tocdo", tocdo);
        anim.SetBool("duoidat", duoidat);
        anim.SetBool("chuyenhuong", chuyenhuong);
        nhay();
    }
    private void FixedUpdate()
    {
        RunPlayer();
    }
    void RunPlayer()
    {
        float leftAndRight = Input.GetAxis("Horizontal");
        r2d.velocity = new Vector2(vantoc * leftAndRight, r2d.velocity.y);
        tocdo = Mathf.Abs(vantoc * leftAndRight);
        if (leftAndRight > 0 && !QuayPhai) huongMatMario();
        if (leftAndRight < 0 && QuayPhai) huongMatMario();
        
    }
    void huongMatMario()
    {
        QuayPhai = !QuayPhai;
        Vector2 huongQuay = transform.localScale;
        huongQuay.x *= -1;
        transform.localScale = huongQuay;
    }
    void nhay()
    {
        if(Input.GetKey(KeyCode.Space) && duoidat == true)
        {
            r2d.AddForce((Vector2.up) * nhayCao);
        }
    } 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "nengach")
        {
            duoidat = true;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "nengach")
        {
            duoidat = true;
        }
    }
    
}
