using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TalkingClock : MonoBehaviour
{
    public GameObject fml;
    public string Message = "Hi, I'm Time and it's test time! \nNavigate the pages using WASD to move, \nuse the mouse to look around. \nDon't spend too much time on a page, \nor you'll fail the entire test.\nPress [R] to reset the test/I'll do it for you when you fail. \nGood luck!\n[Press Space To Send Time Away.]";
    public Text captureMessage;
    public Transform player;
    public float placementReference = 5f;
    public GameObject textBox;
    bool TimreOrThumbs = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((player.position - transform.position).magnitude < placementReference)
        {
            enableTextBox();
            captureMessage.text = Message ;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fml.SetActive(false);
                disableTextBox();
                captureMessage.text = "";
            }

        }
        else
        {
            disableTextBox();
            captureMessage.text = "";
        }
        


    }
    public void enableTextBox()
    {
        textBox.SetActive(true);
    }
    public void disableTextBox()
    {
        textBox.SetActive(false);

    }
}
