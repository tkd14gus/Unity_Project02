using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMove : MonoBehaviour
{
    public GameObject boomEffect;

    private Vector3 ro;
    private float speed = 5f;
    //private float gravity = -10f;
    private PlayerFire pf;

    // Start is called before the first frame update
    void Start()
    {
        pf = GameObject.Find("Player").GetComponent<PlayerFire>();

        ro = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.eulerAngles = ro;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += (transform.up + transform.forward) * pf.POWER * Time.deltaTime;
    }

        private void OnCollisionEnter(Collision collision)
    {
        GameObject be = Instantiate(boomEffect);
        be.transform.position = transform.position;
        Destroy(gameObject);
        Destroy(be.gameObject, 1.0f);
    }
}
