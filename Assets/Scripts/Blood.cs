using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    Vector3 scale;
    public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
        scale = blood.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        if (player)
            blood.transform.LookAt(player.transform.position);
    }

    public void SetBloodScale(float f)
    {
        f = Mathf.Max(0, f);
        Vector3 curScale = blood.transform.localScale;
        float x = Mathf.Lerp(0, scale.x, f);
        curScale.x = x;
        blood.transform.localScale = curScale;           
    }
}
