using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //카메라가 플레이어를 따라다니기
    //플레이어한테 바로 카메라를 붙여서 이동해도 상관 없다.
    //하지만 게임에 따라서 드라마틱한 연출이 필요한 경우에
    //타겟을 따라다니도록 하는게 1인칭에서 3인칭으로 또는 그 반대로 변경이 쉽다.
    //또한 순간이동이 아닌 슈팅게임에서 꼬랑지가 따라다니는 것 같은 효과도 연출이 가능하다.
    //지금은 우리 눈 역할을 할거라서 그냥 순간이동 시킨다.

    public Transform[] target; //카메라가 따라다닐 타겟
    public float followSpeed = 10.0f;
    private int camIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //카메라 위치를 강제로 타겟위치에 고정해둔다.
        //transform.position = target.position;

        FollowTarger();

        if(Input.GetKeyDown("1"))
        {
            camIndex = 0;
        }
        if (Input.GetKeyDown("2"))
        {
            camIndex = 1;
        }
    }

    //타겟을 따라다니기
    private void FollowTarger()
    {
        //타겟방향 구하기(벡터의 빨셈)
        //방형 = 타겟 - 자기자신
        Vector3 dir = target[camIndex].position - transform.position;
        dir.Normalize();
        transform.position += dir * followSpeed * Time.deltaTime;
        //transform.rotation = target[camIndex].rotation;
        //transform.rotation =  Quaternion.Lerp(transform.rotation, target[camIndex].rotation, 1.5f * Time.deltaTime);
        

        //문제점 : 타겟에 도착하면 덜덜덜 거림
        if(Vector3.Distance(transform.position, target[camIndex].position) < 1.0f)
        {
            transform.position = target[camIndex].position;
        }
    }
}
