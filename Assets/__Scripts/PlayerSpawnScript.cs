using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawnScript : MonoBehaviour
{
    public GameObject PlayerObjectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        /*NetworkBehavior
        // Checks to see if this is another player that doesn't belong to the local player. 
        if (isLocalPlayer == false)
        {
            return;
        }
       
        CmdSpawnPlayer();
        */
    }

    // Update is called once per frame
    void Update()
    {
        /* NetworkBehavior
        if(isLocalPlayer == false)
        {
            return;
        }*/
        
    }
    /* NetworkBehavior
    [Command]
    void CmdSpawnPlayer()
    {
        GameObject player = Instantiate(PlayerObjectPrefab);

        // Turns off the camera for other players after they spawn in.
        if (isLocalPlayer == false)
        {
            // Camera is a child of the player object.
            player.GetComponentInChildren<Camera>().enabled = false;
        }
        NetworkServer.SpawnWithClientAuthority(player, connectionToClient);
    }*/
}
