using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
    ConnectionManager cManager;
    MessageQueue msgQueue;
    List<GameObject> players = new List<GameObject>();

    void Awake() {
        //DontDestroyOnLoad(gameObject);
        NetworkRequestTable.init();
        NetworkResponseTable.init();

        
        gameObject.AddComponent<MessageQueue>();
		gameObject.AddComponent<ConnectionManager>();
		
		
	}
	
	// Use this for initialization
	void Start () {

        
        cManager = gameObject.GetComponent<ConnectionManager>();
        msgQueue = gameObject.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_AUTH, ResponseCreate);
        //msgQueue.AddCallback(Constants.SMSG_PLAYERS, responsePlayers);
        //msgQueue.AddCallback(Constants.SMSG_TEST, responseTest);

        Debug.Log("Starting Coroutine");
		StartCoroutine(RequestHeartbeat(1f));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Function to be called after processing a message.
    // Function callbacks used to show what is received or what happens to the client
    // after the request is done processing from the connection manager. 
    public void ResponseCreate(ExtendedEventArgs eventArgs)
    {
        // if eventArgs.playertag == 1 or eventArgs.playertag == 2 to tell them to spawn in different areas
        GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/PlayerObject"));
        players.Add(player);
        if (players.Count == 1)
        {  
            Debug.Log("Added first player in list.");
        }
        
        if(players.Count > 1)
        {
            Debug.Log("Adding subsequent players that join.");
            
            
            // Turn off all children associated with the new player object that joins.
            for (int i = 0; i < player.transform.childCount; i++)
            {
                GameObject child = player.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }
            // Turn off all movement and camera objects so that one input doesn't move both player objects.
            player.GetComponent<FPMovement>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<MouseLook>().enabled = false;
           
        }
        Debug.Log("Successfully created player in callback function.");
    }

	public IEnumerator RequestHeartbeat(float time) {

        Debug.Log("In Coroutine");
		ConnectionManager cManager = gameObject.GetComponent<ConnectionManager>();

		
			RequestHeartbeat request = new RequestHeartbeat();
			request.send();
		
			cManager.send(request);

        yield return new WaitForSeconds(time);
        StartCoroutine(RequestHeartbeat(1f));
	}
}
