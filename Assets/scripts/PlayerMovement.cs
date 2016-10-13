using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    CharacterController cController;
    float jumpTimer;
    public float jumpDist = 5f;

    // Use this for initialization
    void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");


        cController.SimpleMove(transform.forward * inputY * 5f);
        cController.SimpleMove(transform.right * inputX * 5f);

        // transform.Rotate(0f, mouseX * 5f, 0f);
        transform.Rotate(0f, 0f, mouseX * 5f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            cController.Move(transform.up * jumpDist);
           jumpTimer = Time.time + 1f;
        }
        if (Time.time < jumpTimer)
        {
            cController.Move(transform.up * 0.1f);
        }

        if (this.transform.position.y < -5)
        {
            this.transform.position = new Vector3(0, .33f, 0);
        }
    }

     void Jump()
    {

    }
    void OnDrawGizmos()
    {
        //front box
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(
            new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z+2f), 
            new Vector3(1f,1f,1f)
            );
        //side box
        Gizmos.color = Color.red; 
        Gizmos.DrawWireCube(new Vector3(this.transform.position.x+2f, this.transform.position.y, this.transform.position.z),
            new Vector3(1f,1f,1f));
        //up box
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(this.transform.position.x, this.transform.position.y+2f, this.transform.position.z),
            new Vector3(1f, 1f, 1f));
    }

}
