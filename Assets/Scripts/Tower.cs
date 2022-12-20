using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameObject target;
    private Renderer[] renderers;
    public GameObject[] projectPrefab;
    private bool isPlayAni;
    private float aniTime;
    GameObject clone;
    private int pestno;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      
        if(isPlayAni == false)
           target = FindClosestEnemy();

        if(target != null && isPlayAni == false)
        {
            isPlayAni = true;
            renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer rl in renderers)
            {
                rl.enabled = false;
            }

            renderers = target.GetComponentsInChildren<Renderer>();
            foreach (Renderer rl in renderers)
            {
                rl.enabled = false;
            }
            if (target.name == "DogPBR")
                pestno = 0;
            else if (target.name == "Slime")
                pestno = 1;
            clone =Instantiate(projectPrefab[pestno], target.transform.position, transform.rotation);

          //  target.GetComponent<Enemy>().currentHP = target.GetComponent<Enemy>().currentHP - 20.0f;
           // target.GetComponent<Blood>().SetBloodScale(target.GetComponent<Enemy>().currentHP / target.GetComponent<Enemy>().maxHP);
        }

        if(isPlayAni== true)
        {
            aniTime = aniTime + Time.deltaTime;
            if (aniTime > 1f)
            {
                Destroy(clone);
                isPlayAni = false;
                aniTime = 0;

                foreach (Renderer rl in renderers)
                {
                    rl.enabled = true;
                }

                renderers = target.GetComponentsInChildren<Renderer>();
                foreach (Renderer rl in renderers)
                {
                    rl.enabled = true;
                }
            }
        }
    }
    
    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");        
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        
        foreach(GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < 10)
            {
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        return closest;
    }     
}
