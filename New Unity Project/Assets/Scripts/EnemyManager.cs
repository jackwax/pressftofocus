using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {


    //a class for organizing prefabs, 

    public Vector3 minSpawnRange;
    public Vector3 maxSpawnRange;
    public GameObject enemy;
    public GameObject playerplayer;
    public GameObject BigEnemy;
    public GameObject SpiralEnemy;
    float timer = 0;



    // Use this for initialization
    void Start()
    {
        playerplayer = GameObject.Find("playersplayer");
        InvokeRepeating("spawnStandardEnemy", 0, 3);
        InvokeRepeating("spawnLargeEnemy", 0, 6);
        InvokeRepeating("spawnSpiralEnemy", 0, 10);
    }

    public int Signing()
    {
        List<int> nums = new List<int>();
        nums.Add(-1);
        nums.Add(1);

        return nums[Random.Range(0, nums.Count)];

    }


    public Vector3 spawnBigLocation()
    {
        float xVal = 65f;
        float yVal = Random.Range(-30f, 30f);

        Vector3 vec = new Vector3(xVal, yVal, -0.1f);
        return vec;


    }



    public Vector3 spawnLocation()
    {
        int xVal = Random.Range(0, 75) * Signing();
        int yVal;

        if (Mathf.Abs(xVal) < 52)
        {
            //y has to be in thresh
            yVal = Random.Range(40, 50) * Signing();

        }
        else
        {
            yVal = Random.Range(0, 50) * Signing();
        }
        Vector3 vec = new Vector3(xVal, yVal, -0.1f);
        return vec;


         //return new Vector3(xVal, yVal, -0.1f);


    }

    public void spawnStandardEnemy()
    {
        GameObject go = Instantiate(enemy, spawnLocation(), enemy.transform.rotation);
        go.transform.SetParent(this.transform.parent, false);
        go.GetComponent<Enemy>().SetTarget(playerplayer.transform.position);
        print("playerplayer location " + playerplayer.transform.position);

        go.GetComponent<Enemy>().SetType("Standard");

    }

    public void spawnLargeEnemy()
    {
        GameObject go = Instantiate(BigEnemy, spawnBigLocation(), BigEnemy.transform.rotation);
        go.transform.SetParent(this.transform.parent, false);
        


    }

    public void spawnSpiralEnemy()
    {
        GameObject go = Instantiate(SpiralEnemy, spawnBigLocation(), SpiralEnemy.transform.rotation);
        go.transform.SetParent(this.transform.parent, false);
    }

	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float seconds =  (int) (timer % 60);
        //print(seconds % 10);
        

        //spawn large enemy
        if (seconds % 5 == 0)
        {
            //GameObject go = Instantiate(BigEnemy, spawnBigLocation(), BigEnemy.transform.rotation);
           //seconds = 0;
           //timer = 0;
        }

  
	}
}
