using UnityEngine;
using System.Collections;

public class FallingPlatforms : MonoBehaviour {
    public GameObject platform;
    public float destroyTime = 3f;
    public float curTime = 3f;
    public bool selfDestruct = false;
    void Update()
    {
        if(selfDestruct){ 
         if (curTime > 0)
           {
    
             ChangeColor(curTime, platform);
             curTime -= Time.deltaTime;
           }
         else {
                Destroy(this);
                Destroy(platform);
            }
        
     }
    }
    
    //float timer;
    void OnTriggerEnter(Collider activator)
    {
        //Debug.Log("CurTime is Set " + curTime);
        if (activator.gameObject.tag == "Player")
        {
            selfDestruct = true;
        }
    }

    void ChangeColor(float time, GameObject plat)
    {
        Renderer rend = plat.GetComponent<Renderer>();

        if (time > destroyTime * .75f)
        {
            rend.material.color = new Color(0f, 1f, 0f, 1f);//green
        }
        else if (time > destroyTime * .5f)
        {
            rend.material.color = new Color(1f, 1f, 0f, 1f);//yellow
        }
        else if (time > destroyTime * .25f) 
        {
            rend.material.color = new Color(1f, 0.5f, 0f, 1f);//orange
        }
        else
        {
            rend.material.color = new Color(1f, 0f, 0f, 1f);//red
        }
    }
}
