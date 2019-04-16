using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomOptions : MonoBehaviour
{
    public void createRoom()
    {
        // Starts a room with the connection manager script 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads scene based off of index scene
      //SceneManager.LoadScene("SceneTwo"); //loads scene based off string "nameofScene"
    }

    public void joinRoom()
    {
        // Supposed to join the room, most likely using another script to connect to host.

    }
}
