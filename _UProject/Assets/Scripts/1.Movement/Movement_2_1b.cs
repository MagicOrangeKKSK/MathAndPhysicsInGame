using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//通过键盘输入控制物体运动
//斜方向上移动速度保持不变
public class Movement_2_1b : MonoBehaviour
{
    public Transform _transform; //要被控制的物体
    public float PLAYER_VEL = 3f; //玩家移动速度


    public float CHAR_WIDTH; //物体的大小
    public float VIEW_WIDTH; //屏幕的宽度
    public float VIEW_HEIGHT;

    public const float ROOT2 = 1.41421f;

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
        bool bLeftKey, bRightKey;
        bool bUpKey, bDownKey;
        bLeftKey = Input.GetKey(KeyCode.LeftArrow);
        bRightKey = Input.GetKey(KeyCode.RightArrow);
        bUpKey = Input.GetKey(KeyCode.UpArrow);
        bDownKey = Input.GetKey(KeyCode.DownArrow);

        //左方向键被按下时向左移动
        if (bLeftKey)
        {
            if (bUpKey || bDownKey)
                position.x -= PLAYER_VEL / ROOT2 * Time.deltaTime;
            else
                position.x -= PLAYER_VEL * Time.deltaTime;
        }

        //右方向键被按下时向右移动
        if (bRightKey)
        {
            if (bUpKey || bDownKey)
                position.x += PLAYER_VEL / ROOT2 * Time.deltaTime;
            else
                position.x += PLAYER_VEL * Time.deltaTime;
        }

        //上方向键被按下时向上移动
        if (bUpKey)
        {
            if (bLeftKey || bRightKey)
                position.y += PLAYER_VEL / ROOT2 * Time.deltaTime;
            else
                position.y += PLAYER_VEL * Time.deltaTime;
        }

        //下方向键被按下时向下移动
        if (bDownKey)
        {
            if (bLeftKey || bRightKey)
                position.y -= PLAYER_VEL / ROOT2 * Time.deltaTime;
            else
                position.y -= PLAYER_VEL * Time.deltaTime;
        }

        position.x = Mathf.Clamp(position.x, -VIEW_WIDTH + CHAR_WIDTH / 2f, VIEW_WIDTH - CHAR_WIDTH / 2f); //大小限制
        position.y = Mathf.Clamp(position.y, -VIEW_HEIGHT + CHAR_WIDTH / 2f, VIEW_HEIGHT - CHAR_WIDTH / 2f); //大小限制

        _transform.position = position;

        /*
         * 这里首先定义4个bool变量 分别存放 左右 上下 当前是否被按下这一信息
         * 拿左方向为例子
         * 首先检查左方向键有没有被按下
         *  if(bLeftKey){
         *  当左方向键被按下时，再检查上下键有没有被按下
         *   if(bUpKey || bDownKey){
         * 如果在左方向键被按下的同时 又有上下方向键的一个被按下，那么就会认为物体在斜方向移动
         * 并执行以下语句 进行在x轴方向上的减速
         * x -= PLAYER_VEL/ROOT2*Time.deltaTime
         * 如果仅仅只是按下了左右键 那继续以PLAYER_VEL的速度前进
         * 
         * 但我同时按下了 左 上 下等按键时  
         * 由于上下都被按住了 则在y轴上的速度保持不变
         * x轴却会以1/√2 的速度前进
         *
         *
         */
    }
}
