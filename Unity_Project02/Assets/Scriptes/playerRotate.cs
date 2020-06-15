using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotate : MonoBehaviour
{
    //카메라를 마우스 움직이는 방향으로 회전하기
    public float speed = 150;   //회전속도(Time.DelraTime.deltaTime을 통해 1초에 150도를 회전한다.)
    //회전각도를 직접 제어하자
    private float angleX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 회전
        Rotate();
    }

    private void Rotate()
    {
        float h = Input.GetAxis("Mouse X");
        angleX += h * speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, angleX, 0);
    }
}
