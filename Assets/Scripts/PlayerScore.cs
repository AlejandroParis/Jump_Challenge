using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score = 0;
    public float time = 0;
    bool playGame = true;
    public Text timeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playGame)
        {
            time += Time.deltaTime;
            int minute = (int)time / 60;
            timeText.text = minute.ToString() + ":" + (((int)(time-(minute * 60))).ToString());
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Gem")
        {
            Score += 1;
            Destroy(collision.gameObject);
        }else if(collision.transform.tag == "Door")
        {
            if(Score >= 4)
                Destroy(collision.gameObject);
        }else if(collision.transform.tag == "End")
        {
            playGame = false;
        }
    }
}
