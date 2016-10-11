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
              //Debug.Log("CurTime Before" + curTime);
             curTime -= Time.deltaTime;
             //Debug.Log("Curtime after " + curTime);
           }
         else {
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
     //       platform.GetComponent<Renderer>().material.color = Color.green;


        }
    }

    void ChangeColor(float time, GameObject plat)
    {
        Renderer rend = plat.GetComponent<Renderer>();
        if (time > destroyTime * (2f / 3f))
        {
            Debug.Log(destroyTime + "," + time);
            rend.material.color = new Color(0f, 1f, 0f, 1f);//green
        }
        else if (time > destroyTime * (1f / 3f))
        {
            Debug.Log(destroyTime + "" + time);
            rend.material.color = new Color(1f, 1f, 0f, 1f);//yellow
        }
        else if (time > 0)
        {
            Debug.Log(destroyTime + "" + time);
            rend.material.color = new Color(1f, 0.5f, 0f, 1f);//orange
        }
    }
}
