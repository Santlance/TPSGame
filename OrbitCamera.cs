using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;

    private float rotY;//Y上的欧拉角
    private Vector3 offset;//相机和玩家的距离
    private Vector3 vecX = new Vector3(0, -1, 0);
    // Start is called before the first frame update
    void Start()
    {
        rotY = transform.eulerAngles.y;
        offset = target.position - transform.position + vecX;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        bool leftAlt = Input.GetKey(KeyCode.LeftShift);
        if (leftAlt && horInput != 0)

        {
            rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
            Quaternion rotation = Quaternion.Euler(6, rotY, 0);
            transform.position = target.position - (rotation * offset);
            transform.LookAt(target);
        }
    }
}
