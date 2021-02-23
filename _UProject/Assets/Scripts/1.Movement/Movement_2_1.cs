using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//通过键盘输入控制物体运动
public class Movement_2_1 : MonoBehaviour
{
    public Transform _transform; //要被控制的物体
    public float PLAYER_VEL = 3f; //玩家移动速度


    public float CHAR_WIDTH; //物体的大小
    public float VIEW_WIDTH ; //屏幕的宽度
    public float VIEW_HEIGHT;


    void Start()
    {
        //初始化物体的位置
        Vector3 position = _transform.position;
        position.x = 0;
        position.z = 0;
        _transform.position = position;

        PLAYER_VEL = 3f; //初始化玩家速度

        CHAR_WIDTH = 1f;
        VIEW_HEIGHT = Camera.main.orthographicSize;
        VIEW_WIDTH = ((float)Screen.width / (float)Screen.height) * VIEW_HEIGHT;//计算画面右端的x坐标
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = _transform.position;
        //左方向键按下时 向左移动
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            position.x -= PLAYER_VEL * Time.deltaTime;
            if(position.x < -VIEW_WIDTH + CHAR_WIDTH / 2f)
            {
                position.x = -VIEW_WIDTH + CHAR_WIDTH / 2f;
            }
        }

        //右方向被按下时向右移动
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += PLAYER_VEL * Time.deltaTime;
            if(position.x > VIEW_WIDTH - CHAR_WIDTH / 2f)
            {
                position.x = VIEW_WIDTH - CHAR_WIDTH / 2f;
            }
        }

        //上方向键被按下时向上移动
        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y += PLAYER_VEL * Time.deltaTime;
            if (position.y > VIEW_HEIGHT - CHAR_WIDTH / 2f)
            {
                position.y = VIEW_HEIGHT - CHAR_WIDTH / 2f;
            }
        }

        //下方向键被按下时向下移动
        if (Input.GetKey(KeyCode.DownArrow))
        {
            position.y -= PLAYER_VEL * Time.deltaTime;
            if (position.y < -VIEW_HEIGHT + CHAR_WIDTH / 2f)
            {
                position.y = -VIEW_HEIGHT + CHAR_WIDTH / 2f;
            }
        }

        /*
         *代码行数相较1_1增加了不少
         * 不过基本上只是修改x坐标的处理照搬到了y坐标上
         * 
         * 但如果我们同时按下不同轴向的方向，那么显然速度要比单方向的PLAYER_VEL更快
         * 因为物体既在x轴以PLAYER_VEL移动
         * 又在y轴以PLAYER_VEL移动
         * 我们可以将它看作是一个直角三角形  横向的速度 是这个三角形的底 而纵轴的速度 是这个三角形的高
         * 斜方向的速度就通过勾股定理进行计算得出了
         * c^2 = a^2 + b^2
         */

        _transform.position = position;
    }
}
