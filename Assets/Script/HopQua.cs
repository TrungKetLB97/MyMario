using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopQua : MonoBehaviour
{
    public GameObject vatPham;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            if (vatPham != null) vatPham.SetActive(true);  //Sau khi player an vat pham thi vatPham bi null
    }
}
