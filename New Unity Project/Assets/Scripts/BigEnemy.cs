using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour {

    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject enemyPrefab;

    private Vector3 startPoint;
    private const float radius = 100F;

    private bool isSeen;
    private bool alreadyFiring;

	// Use this for initialization
	void Start () {
        isSeen = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left.normalized * 0.1f * Time.deltaTime;

        //flag to invoke firing mechanics once when seen
        if (RendererExtensions.IsVisibleFrom(this.GetComponent<RectTransform>(), Camera.main))
        {
            isSeen = true;
        }

        if (RendererExtensions.IsVisibleFrom(this.GetComponent<RectTransform>(), Camera.main) == false && isSeen == true)
        {
            Destroy(this.gameObject);
        }



        if (isSeen == true && alreadyFiring == false )
        {
            InvokeRepeating("SpawnProjectile", 2, 3);
            alreadyFiring = true;
        }

        


        



		
	}

    //set to a bullet prefab
    private void SpawnProjectile ()
    {
        startPoint = transform.localPosition;
        print(startPoint);

        int _numberOfProjectiles = 10;
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, -0.1f);
            //Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized;
                //* projectileSpeed
            GameObject tmpObj = Instantiate(enemyPrefab, startPoint, Quaternion.identity);
            tmpObj.transform.SetParent(this.transform.parent, false);

            tmpObj.GetComponent<Enemy>().SetTarget(projectileVector);

            angle += angleStep;
            //enemyPrefab.GetComponent<Enemy>().SetTarget(projectileVector);

        }
    }
}
