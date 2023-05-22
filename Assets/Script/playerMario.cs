using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMario : MonoBehaviour
{
    public Rigidbody2D Bullet;
    float vantoc = 7;
    float nhayCao = 10;
    private float tocdo = 0;
    private bool duoidat = true;
    private bool chuyenhuong = false;
    private bool QuayPhai = true;
    private Rigidbody2D r2d;
    private Animator anim;

    float DoPhongTo = 1;

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
        ban();
    }

    private void FixedUpdate()
    {
        nhay();
        RunPlayer();
    }

    void RunPlayer()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            r2d.velocity = new Vector2(vantoc, r2d.velocity.y);
            tocdo = Mathf.Abs(vantoc);
            QuayPhai = true;
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            r2d.velocity = new Vector2(-vantoc, r2d.velocity.y);
            tocdo = Mathf.Abs(vantoc);
            QuayPhai = false;
            transform.localEulerAngles = new Vector3(0f, 180f, 0f); // Quay nhan vat 1 goc 180 do theo chieu y
        }
        else
        {
            r2d.velocity = new Vector2(0f, r2d.velocity.y);
            tocdo = 0;
        }
    }
    void nhay()
    {
        if (Input.GetKey(KeyCode.Space) && duoidat == true)
        {
            r2d.AddForce((Vector2.up) * nhayCao, ForceMode2D.Impulse);
            duoidat = false;
        }
    }
    void ban()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            int huong;
            if (QuayPhai)
            {
                huong = 1;
            }
            else
            {
                huong = -1;
            }
            Rigidbody2D bullet = Instantiate(Bullet, transform.position, Quaternion.identity); // Sinh ra dan
            bullet.AddForce(Vector2.right * huong * 10f, ForceMode2D.Impulse); // Ban dan voi luc = 10 theo huong player
            Destroy(bullet, 5); //destroy vien dan ban ra sau 5s
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "nengach")
        {
            duoidat = true;
        }
        else if (col.tag == "Lose")
        {
            Lose();
        }
        else if (col.tag == "enemy")
        {
            Lose();
        }
        else if (col.tag == "Nam")
        {
            DoPhongTo = 1.5f;
            Scale();
            Destroy(col.gameObject);
        }
        else if (col.tag == "Hoa")
        {
            DoPhongTo = .5f;
            Scale();
            Destroy(col.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "nengach")
        {
            duoidat = true;
        }
    }

    void Scale()
    {
        transform.localScale = transform.localScale * DoPhongTo;
    }
    void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load lai level
    }
}
