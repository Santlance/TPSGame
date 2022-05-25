using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 initPosition;
    private Vector3[] corrections = new Vector3[4];
    private bool[] isCorrect = new bool[4];
    // Start is called before the first frame update
    void Start()
    {
        initPosition = Camera.main.transform.position;
        for (int i = 0; i < 4; i++)
        {
            corrections[i] = new Vector3(0.0f, 0.0f, 0.0f);
            isCorrect[i] = false;
        }
    }
    void detect(Vector3 dir, Vector3 inverse_dir, int index)
    {
        RaycastHit hitInfo;
        Vector3 newdir = Camera.main.transform.TransformDirection(dir);

        if (Physics.SphereCast(Camera.main.transform.position, 0.5f, newdir, out hitInfo, 0.5f))
        {
            float dis = hitInfo.distance;
            Vector3 correction = Vector3.Normalize(Camera.main.transform.TransformDirection(inverse_dir) * dis);
            Camera.main.transform.position += correction;
            corrections[index] = correction;
            isCorrect[index] = true;
        }
        else if(isCorrect[index] == true)
        {
            Camera.main.transform.position -= corrections[index];
            isCorrect[index] = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        detect(Vector3.forward, Vector3.back, 0);
        detect(Vector3.back, Vector3.forward, 1);
        detect(Vector3.left, Vector3.right, 2);
        detect(Vector3.right, Vector3.left, 3);
    }
}
