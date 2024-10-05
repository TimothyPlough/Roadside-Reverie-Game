using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestScript : MonoBehaviour
{
    [SerializeField] GameObject end;
    private GameObject player;

    [SerializeField] GameObject cloud1;
    [SerializeField] GameObject cloud2;
    [SerializeField] GameObject cloud3;
    [SerializeField] GameObject cloud4;

    [SerializeField] int cloudAmount;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        generateClouds();
    }

    // Update is called once per frame
    void Update()
    {
        //if (player == null)
            //Debug.Log("Game Over");
    }

    private void generateClouds()
    {
        float Xboundry = end.transform.position.x;

        for (int i = 0; i < cloudAmount; i++)
        {
            int cloudType = Random.Range(1, 4);

            Vector3 newPos = new Vector3(
                Random.Range(Xboundry, 0),
                Random.Range(2, 10),
                0);

            GameObject e;
            switch (cloudType)
            {
                case 1:
                    e = Instantiate(cloud1) as GameObject;
                    break;
                case 2:
                    e = Instantiate(cloud2) as GameObject;
                    break;
                case 3:
                    e = Instantiate(cloud3) as GameObject;
                    break;
                default:
                    e = Instantiate(cloud4) as GameObject;
                    break;
            }
            
            e.transform.position = newPos;
            Debug.Log("Cloud Created");
        }
    }
}
