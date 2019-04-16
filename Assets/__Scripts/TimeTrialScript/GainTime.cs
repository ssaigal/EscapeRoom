
using UnityEngine;
using System.Collections;

public class GainTime : MonoBehaviour
{
    private TimeControl timerScript;

    void Start()
    {
        timerScript = GameObject.Find("PlayerObject").GetComponent<TimeControl>();
    }
    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Player")
        {
            timerScript.timer += 10;
            timerScript.guiShow = true;
            Destroy(gameObject);
        }
    }
}
