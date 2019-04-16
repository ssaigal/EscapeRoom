using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public float timer = 10.0f;
   public  float addTime = 10.0f;
   public bool guiShow = false;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 50, 20), "" + timer.ToString("0"));
        if (guiShow == true)
        {
            GUI.Box(new Rect(65, 10, 50, 20), "+" + addTime.ToString("0"));
            ShowGUI();
        }
    }
    IEnumerator ShowGUI()
    {
         yield return new WaitForSeconds(2);
        guiShow = false;
    }
}