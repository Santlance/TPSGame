﻿using UnityEngine;
using System.Collections;

public class EthanTrace : MonoBehaviour
{

    public GameObject target;       //敌人的追踪目标
    public float moveSpeed = 3.0f;  //敌人的移动速度
    public float minDist = 1.6f;		//追踪距离，当敌人与目标的距离小于等于该值时，敌人不再追踪目标
    public float maxDist = 50.0f;
    public float midDist = 10.0f;
    public float hangingTime = 1.0f;
    public float changeDirTime = 2.0f;

    private float dist;
    private Animator anim;              //敌人的Animator组件
    private EnemyHealth enemyHealth;        //敌人的生命值脚本
    private float timer = 0.0f;
    private float changeDirTimer = 0.0f;
    private float rotateAngle = 0.0f;

    private float changeDir = 0.0f;
    private float spead = 0.0f;

    //初始化，获取敌人的组件
    void Start()
    {
        anim = GetComponent<Animator>();        //获取敌人的Animator组件	
        enemyHealth = GetComponent<EnemyHealth>(); //获取敌人的生命值脚本
    }

    //每帧执行一次，用于敌人追踪目标
    void Update()
    {
        //当游戏状态为游戏进行中（Playing）时
        if (GameManager.gm == null || GameManager.gm.gameState == GameManager.GameState.Playing)
        {
            if (enemyHealth.health <= 0) return;    //当敌人死亡时，敌人无法追踪目标
                                                    //当追踪目标未设置时，敌人无法追踪目标
            if (target == null) return;
            dist = Vector3.Distance(transform.position, target.transform.position);	//计算敌人与追踪目标之间的距离
            if (dist > maxDist)
            {
                transform.eulerAngles = new Vector3(0.0f, rotateAngle, 0.0f);
                transform.position +=
                    transform.forward * moveSpeed / 2 * Time.deltaTime; //敌人以moveSpeed的速度向追踪目标靠近
                timer += Time.deltaTime;
                if (timer > hangingTime)
                {
                    timer = 0.0f;
                    hangingTime = 8.0f;
                    rotateAngle = Random.Range(0.0f, 360.0f);
                }
            }
            else if (dist > midDist)
            {
                transform.LookAt(target.transform);             //敌人面向追踪目标
                transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y, 0.0f);   //设置敌人的Rotation属性，确保其只在y轴旋转
                if (changeDirTimer > changeDirTime)
                {

                    changeDir = Random.Range(-1.0f, 1.0f);
                    spead = Random.Range(1.0f, 2.0f);
                    changeDirTimer = 0.0f;
                }
                int dir = 0;
                if (changeDir > 0.0f) dir = 1; else if (changeDir < 0.0f) dir = -1;
                changeDirTimer += Time.deltaTime;
                transform.position += transform.right * dir * spead * Time.deltaTime;
                transform.position +=
                                    transform.forward * moveSpeed * Time.deltaTime; //敌人以moveSpeed的速度向追踪目标靠近
            }
            else
            if (dist > minDist)
            {   //当敌人与目标的距离大于追踪距离时
                transform.LookAt(target.transform);             //敌人面向追踪目标
                transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y, 0.0f);   //设置敌人的Rotation属性，确保其只在y轴旋转
                transform.position +=
                    transform.forward * moveSpeed * Time.deltaTime; //敌人以moveSpeed的速度向追踪目标靠近
            }
            anim.SetBool("isStop", false);  //设置动画参数，将布尔型参数isStop设为false：敌人追踪目标，播放奔跑动画
        }
        //当游戏状态为游戏失败（GameOver）时
        else if (GameManager.gm == null || GameManager.gm.gameState == GameManager.GameState.GameOver)
        {
            anim.SetTrigger("isPlayerDead");    //设置动画参数，设置isPlayerDead的Trigger参数，播放游戏失败时敌人动画
        }
    }
}
