using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//物体以一定速度沿着直线运动的情况
//物体以固定速度行进的直线运动
//称为 匀速直线运动
public class Movement_1_1 : MonoBehaviour
{
    public Transform _transform; //移动的物体
    public float velocity = 0f; //速度

    //在程序开始时调用一次
    void Start()
    {
        Vector3 position = _transform.position;
        position.x = 0; //物体的初始位置
        _transform.position = position;

        velocity = 3f; //物体在x方向的速度
    }

    //在程序每帧被调用一次
    void Update()
    {
        Vector3 position = _transform.position;
        position.x += velocity;  //实际移动物体
        _transform.position = position;

        //我们在Start中设置了速度为3
        //一般来说到下一个画面切换的时间
        //即帧速率为1/60秒
        //因此程序中的物体会以每秒180单位的速度向右侧移动
        //但不同计算机的性能不一致会导致不同的计算机  帧率不同
        //而产生效果不同
        //我们清楚   路程 = 速度 x 时间
        //秒速3时
        //1秒内 物体会移动3距离
        //0.1秒内 物体会移动0.3距离
        //n秒内  物体会移动 3n距离
        //所以为了在不同机子上也能产生相同的效果 应将
        //_position.x += velocity 改为 _position.y += velocity * Time.deltaTime;
        //Time.deltaTime 则是两帧之间过了多少秒
    }
}
