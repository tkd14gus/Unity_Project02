using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    private CharacterController cc;

    //중력적용
    public float gravity = -20f;
    float velocityY;    //낙하속도(벨로시티는 방향과 힘을 들고 있다.)
    float jumpPower = 10f;

    public int maxJumpCount = 2;
    public int jumpCount = 0;

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
        //cc.Move(dir * speed * Time.deltaTime);

        //중력적용하기
        velocityY += gravity * Time.deltaTime;
        dir.y = velocityY;
        cc.Move(dir * speed * Time.deltaTime);

        //캐릭터 점프
        //점프버튼을 누르면 수직속도에 점프파워를 넣는다.
        //CollisionFlags.Above;
        //CollisionFlags.Below;
        //CollisionFlags.Sides;
        //땅에 닿으면 0으로 초기화
        //if(cc.isGrounded) // 땅에 닿았냐?  //이상하게 반응속도가 느리네?
        //{
        //   velocityY = 0;
        //   jumpCount = 0;
        //}
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            velocityY = 0;
            jumpCount = 0;
        }
        else
        {
            //땅에 닿지 않은 상태이기 때문에 중력 적용하기
            velocityY += gravity * Time.deltaTime;
            dir.y = velocityY;
        }
        if(Input.GetButtonDown("Jump"))
        {
            if (maxJumpCount > jumpCount)
            {
                velocityY = jumpPower;
                jumpCount++;
            }
        }
    }
}
