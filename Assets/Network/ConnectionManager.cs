using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;
using System.Threading;

public class ConnectionManager : MonoBehaviour {
	
	private GameObject mainObject;
	private TcpClient mySocket;
	private NetworkStream theStream;
	private bool socketReady = false;
    private List<TcpClient> sockets = new List<TcpClient>();
    private int id;
    ConnectionManager c;


    void Awake() {
		mainObject = GameObject.Find("Heartbeat");
	}
	
	// Use this for initialization
	void Start () {
        c = GetComponent<ConnectionManager>();
        id = UnityEngine.Random.Range(0, 100);
        setupSocket();

    }

	public void setupSocket() {
		if (socketReady) {
			Debug.Log("Already Connected");
			return;
		}
		try {
            mySocket = new TcpClient (Constants.REMOTE_HOST, Constants.REMOTE_PORT);
            sockets.Add(mySocket);
			theStream = mySocket.GetStream();
			socketReady = true;
            //Thread newThread = new Thread(Update);
            //newThread.Start();
            Debug.Log("Connected locally");

            // Must be paired with a request to send through the connection
            // manager to send requests to the server
            
            c.send(spawnThis(id));
            

            Debug.Log("Sent request");
		} catch (Exception e) {
			Debug.Log("Socket error: " + e);
		}
	}

    public void readSocket()
    {
        if (!socketReady)
        {
            return;
        }
        int count = 0;
        while (count < sockets.Count) { 
            try
            {
                theStream = sockets[count].GetStream();
                if (theStream != null && theStream.DataAvailable)
                {
                    byte[] buffer = new byte[2];
                    theStream.Read(buffer, 0, 2);
                    short bufferSize = BitConverter.ToInt16(buffer, 0);
                    buffer = new byte[bufferSize];
                    theStream.Read(buffer, 0, bufferSize);
                    MemoryStream dataStream = new MemoryStream(buffer);
                    short response_id = DataReader.ReadShort(dataStream);
                    NetworkResponse response = NetworkResponseTable.get(response_id);
                    if (response != null)
                    {
                        response.dataStream = dataStream;
                        response.parse();
                        ExtendedEventArgs args = response.process();
                        if (args != null) {
                            MessageQueue msgQueue = mainObject.GetComponent<MessageQueue>();
                            msgQueue.AddMessage(args.event_id, args);
                        }
                    }
                }
            }
            catch (Exception e)
            { 
            Debug.Log("Stream error: " + e);
            }
            count++;
        }
	}

    // May have do a bunch of these to be able to send correctly
    public RequestCreate spawnThis(int id)
    {
        RequestCreate spawn = new RequestCreate();
        spawn.send(id);
        return spawn;
    }

	public void closeSocket() {
		if (!socketReady) {
			return;
		}
		mySocket.Close();
		socketReady = false;
	}
	
	public void send(NetworkRequest request) {
		if (!socketReady) {
			return;
		}
		GamePacket packet = request.packet;
		byte[] bytes = packet.getBytes();
		theStream.Write(bytes, 0, bytes.Length);
		if (request.request_id != Constants.CMSG_HEARTBEAT) {
			Debug.Log("Sent Request No. " + request.request_id + " [" + request.ToString() + "]");
		}
	}
	
	// Update is called once per frame
	void Update () {
		readSocket();
	}

}