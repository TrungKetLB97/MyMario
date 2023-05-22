using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public Rigidbody2D bullet;
    float huong;
    float timer = 0;
    float tocDo = 2f;
    public bool canFire; // co the ban hay khong

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.localEulerAngles.y > 90)
        {
            huong = -1;
        }
        else
        {
            huong = 1;
        }
        if (rb != null) rb.MovePosition((Vector2)transform.position + Vector2.right * huong * tocDo * Time.deltaTime);  //di chuyen bang rigidbody
        if (canFire)
        {
            timer += Time.deltaTime;
            if (timer >= 2f) //Ban ra 1 vien dan moi 2 giay
            {
                Ban();
            }
        }
    }

    void Ban()
    {
        Rigidbody2D bull = Instantiate(bullet, transform.position, Quaternion.identity);
        bull.AddForce(Vector2.right * huong * 2f, ForceMode2D.Impulse);
        Destroy(bull, 10);
        timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "nengach" || collision.tag == "enemy")  //va cham nen gach hoac enemy thi quay dau
        {
            transform.localEulerAngles += new Vector3(0f, 180f, 0f);
        }
    }
}
