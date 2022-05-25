using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRandomCreateObject : MonoBehaviour
{
    public GameObject createObject;
    public int total = 20;
    public float height;
    private float timer = 0.0f;
    private int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2.0f && cnt < total)
        {
            GameObject GameObj = Instantiate(createObject);
            if (GameObj.GetComponent<EthanTrace>() != null)   //设置敌人的追踪目标
                GameObj.GetComponent<EthanTrace>().target = GameObject.FindGameObjectWithTag("Player");
            if (GameObj.GetComponent<EnemyTrace>() != null)   //设置敌人的追踪目标
                GameObj.GetComponent<EnemyTrace>().target = GameObject.FindGameObjectWithTag("Player");
            int nx = Random.Range(200,800);
            int ny = Random.Range(200,800);
            GameObj.transform.position = new Vector3(nx, height, ny);
            RaycastHit hitInfo;
            //通过向地面发射光线检测的方式，控制物体在地面的高度
            if(Physics.Raycast(GameObj.transform.position, -Vector3.up,out hitInfo, 10.0f))
            {
                //Debug.Log(hitInfo.distance);
                GameObj.transform.position = new Vector3(nx,height - hitInfo.distance + 0.6f, ny);
            }
            timer = 0.0f;
            cnt++;
        }
    }
}
