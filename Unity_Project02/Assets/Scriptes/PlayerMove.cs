using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(h, 0, v);
        //vt.Normalize(); //대각선이동 속도를 상하좌우속도와 동일하게 만들기
        //게임에 따라 일부로 대각선은 빠르게 이동하도록 하는 경우도 있다.
        //이럴때는 벡터의 경규화(노멀라이즈)를 하면 안된다.

        //gameObject.transform.position += dir * speed * Time.deltaTime;

        //카메라가 보는 방향으로 이동해야 한다.
        dir = Camera.main.transform.TransformDirection(dir);
        //gameObject.transform.position += dir * speed * Time.deltaTime;

        //심각한 문제 : 하늘 날라다님, 땅 뚫음, 총돌처리 안됨
        cc.Move(dir * speed * Time.deltaTime);
    }
}
