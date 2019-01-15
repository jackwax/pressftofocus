using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiralWave : MonoBehaviour
{
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject enemyPrefab;

    private Vector3 startPoint;
    //private const float radius = 100F;

    private bool isSeen;
    private bool alreadyFiring;
    private bool isMoving;

    // Use this for initialization
    void Start()
    {
        isSeen = false;
        isMoving = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) { transform.position += Vector3.left.normalized * 0.1f * Time.deltaTime; }

        //flag to invoke firing mechanics once when seen
        if (RendererExtensions.IsVisibleFrom(this.GetComponent<RectTransform>(), Camera.main))
        {
            print("Pee");
            isSeen = true;
        }

        if (RendererExtensions.IsVisibleFrom(this.GetComponent<RectTransform>(), Camera.main) == false && isSeen == true)
        {
            Destroy(this.gameObject);
        }



        if (isSeen == true && alreadyFiring == false)
        {
            print("YEET");
            //InvokeRepeating("SpawnProjectile", 2, 3);
            StartCoroutine(OnRepeat());
            alreadyFiring = true;
        }

    }

    public IEnumerator OnRepeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            isMoving = false;
            StartCoroutine(SpawnProjectile());
            yield return new WaitForSeconds(3f);
            break;
        }
        isMoving = true; 
        yield return null;
    }



    public IEnumerator SpawnProjectile()
    {
        int _numberOfProjectiles = 40;
        startPoint = transform.localPosition;

        float angleStep = 720f/ _numberOfProjectiles;
        float angle = 0f;

        float radius = 0f;  

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180f) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180f) * radius;

            Vector3 projVector = new Vector3(projectileDirXPosition, projectileDirYPosition, -0.1f);

            GameObject go = GameObject.Instantiate(enemyPrefab, projVector, Quaternion.identity);
            go.GetComponent<Image>().color = this.GetComponent<Image>().color;

            Vector3 moveDirection = (projVector -startPoint).normalized;
            go.GetComponent<Enemy>().SetTheTarget(moveDirection);

            //go.GetComponent<Enemy>().SetTarget(normalizeVector);
            go.transform.SetParent(this.transform.parent, false);

            angle += angleStep;
            radius = radius + 0.1f;

            //startPoint = projVector;

            yield return new WaitForSeconds(0.05f);

        }
    }
}
