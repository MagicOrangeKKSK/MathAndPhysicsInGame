using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//在1_1中，即使物体到达画面边缘，也不会停止，而是会直接移出画面
//我们修改为当物体碰到画面的边缘 会沿反方向弹回
public class Movement_1_1b : MonoBehaviour
{
    public Transform _transform; //移动的物体
    public float velocity = 0f; //速度

    public float CHAR_WIDTH;//物体的宽度
    public float VIEW_WIDTH;//屏幕的宽度

    //在程序开始时调用一次
    void Start()
    {
        Vector3 position = _transform.position;
        position.x = 0; //物体的初始位置
        _transform.position = position;
        velocity = 3f; //物体在x方向的速度
        CHAR_WIDTH = 1f;
        VIEW_WIDTH = ((float)Screen.width / (float)Screen.height) * Camera.main.orthographicSize;//计算画面右端的x坐标
    }

    //在程序每帧被调用一次
    void Update()
    {
        Vector3 position = _transform.position;
        position.x += velocity * Time.deltaTime;  //实际移动物体
        if(position.x > VIEW_WIDTH - CHAR_WIDTH/2f)       //抵达屏幕边缘 
        {
            velocity = -velocity;                                                  //弹回
            position.x = VIEW_WIDTH - CHAR_WIDTH/2f;   //重设坐标为画面边缘
        }
        if(position.x < 0)
        {
            velocity = -velocity;
            position.x = 0;
        }
        _transform.position = position;
        //VIEW_WIDTH 是画面的宽度
        //即画面右端的x坐标
        //由于物体的中心点为物体坐标的原点 
        //如果只是物体的x坐标不超过VIEW_WIDTH 会让物体的一半移出画面之外
        //因此当物体碰撞到画面右端时
        //为了让程序作出“已经碰到”的判断 应当从画面右端的x坐标VIEW_WIDTH中
        //减去物体本身的大小CHAR_WIDTH的一半 
        //然后再与物体的x坐标比较
    }
}
