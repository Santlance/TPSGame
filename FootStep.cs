using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isGround;
    private bool isMove;
    private float groundedRaycastDistance = 0.2f;   //表示向地面发射射线的射线长度
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");	//获取玩家水平轴上的输入
        float v = Input.GetAxisRaw("Vertical");		//获取玩家垂直轴上的输入
        isMove = (h != 0f) || (v != 0f);
        //从玩家的位置垂直向下发出长度为groundedRaycastDistance的射线，返回值表示玩家是否该射线是否碰撞到物体，该句代码用于检测玩家是否在地面上
        isGround = Physics.Raycast(transform.position, -Vector3.up, groundedRaycastDistance);
        if(isGround && isMove)
            AudioSource.PlayClipAtPoint(audioClip, transform.position);	//在枪口位置播放射击音效
    }
}
