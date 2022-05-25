using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BigMap : MonoBehaviour
{
    public GameObject mapImage;
    public Terrain terrain;

    private GameObject player;
    private GameObject playerImage;
    private GameObject[] enemy;
    private GameObject[] blood;
    private GameObject[] coin;
    private GameObject enemyImage;
    private GameObject bloodImage;
    private GameObject coinImage;
    private ArrayList Images = new ArrayList();

    private Vector3 localPos;
    private Vector3 pos;
    float rateX, rateY, posX, posY;
    public float mapX, mapY;
    private float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isMap)
        {
            playerImage = GameObject.FindGameObjectWithTag("PlayerImage");
            enemyImage = GameObject.FindGameObjectWithTag("EnemyImage");
            coinImage = GameObject.FindGameObjectWithTag("CoinImage");
            bloodImage = GameObject.FindGameObjectWithTag("BloodImage");
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            blood = GameObject.FindGameObjectsWithTag("Blood");
            coin = GameObject.FindGameObjectsWithTag("Coin");
            localPos = player.transform.position;
            rateX = localPos.x / 1000;
            rateY = localPos.z / 1000;
            posX = mapX * rateX;
            posY = mapY * rateY;
            pos.x = -1 * posX;
            pos.y = -1 * posY;
            pos.z = 0;
            float ry = player.transform.eulerAngles.y;
            Debug.Log(ry);
            playerImage.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -ry);
            playerImage.transform.localPosition = pos;
            if (Timer > 1.0f)
            {
                Timer = 0.0f;
                foreach (GameObject obj in Images)
                {
                    Destroy(obj);
                }
                foreach (GameObject obj in enemy)
                {
                    localPos = obj.transform.position;
                    rateX = localPos.x / 1000;
                    rateY = localPos.z / 1000;
                    posX = mapX * rateX;
                    posY = mapY * rateY;
                    pos.x = -1 * posX;
                    pos.y = -1 * posY;
                    pos.z = 0;
                    GameObject newImage = Instantiate(enemyImage);
                    newImage.transform.parent = mapImage.transform;
                    newImage.transform.localPosition = pos;
                    Images.Add(newImage);
                }
                foreach (GameObject obj in coin)
                {
                    localPos = obj.transform.position;
                    rateX = localPos.x / 1000;
                    rateY = localPos.z / 1000;
                    posX = mapX * rateX;
                    posY = mapY * rateY;
                    pos.x = -1 * posX;
                    pos.y = -1 * posY;
                    pos.z = 0;
                    GameObject newImage = Instantiate(coinImage);
                    newImage.transform.parent = mapImage.transform;
                    newImage.transform.localPosition = pos;
                    Images.Add(newImage);
                }
                foreach (GameObject obj in blood)
                {
                    localPos = obj.transform.position;
                    rateX = localPos.x / 1000;
                    rateY = localPos.z / 1000;
                    posX = mapX * rateX;
                    posY = mapY * rateY;
                    pos.x = -1 * posX;
                    pos.y = -1 * posY;
                    pos.z = 0;
                    GameObject newImage = Instantiate(bloodImage);
                    newImage.transform.parent = mapImage.transform;
                    newImage.transform.localPosition = pos;
                    Images.Add(newImage);
                }
            }
            Timer += Time.deltaTime;
        }
    }
}
