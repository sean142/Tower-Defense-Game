using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  Transform[] wayPoint;
    public Transform startPoint;
    public GameObject[] enemyObject;
    public float spawnRaoe = 1.0f;
    private float nextSpawnTime = 0.0f;
    public int[] waveFormation;
    private static int no;
    public LayerMask mask;
    
    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        waveFormation = new int[] { 0, 1,0,99,1,0 ,99,0,0,0,1};
    }

    // Update is called once per frame
    void Update()
    {
        if (no != waveFormation.Length) 
        {
            if (Time.time > nextSpawnTime)
            {
                if (waveFormation[no] < enemyObject.Length)    
                    Instantiate(enemyObject[waveFormation[no]], startPoint.transform.position, startPoint.transform.rotation);                
                nextSpawnTime = Time.time + spawnRaoe;
                no++;
            }
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)&Physics.Raycast(ray,out hit, Mathf.Infinity, mask))
        {
            Debug.Log("¥´¨ì"+hit.collider.gameObject);
            Instantiate(tower, hit.transform.position, hit.transform.rotation);
            hit.collider.gameObject.SetActive(false);
        }
    }
}
