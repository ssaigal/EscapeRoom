using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using UnityEngine.Networking;

public class ResponseCreateEventArgs : ExtendedEventArgs {
		
	public short status { get; set; }
	public int user_id { get; set; }
	public string username { get; set; }
	public int money { get; set; }
	public short level { get; set; }
	public string last_logout { get; set; }
    public GameObject player { get; set; }
    
	
	public ResponseCreateEventArgs() {
		event_id = Constants.SMSG_AUTH;
	}
}

public class ResponseCreate : NetworkResponse {
	
	private short status;
	private int user_id;
	private string username;
	private int money;
	private short level;
	private string last_logout;

	public ResponseCreate() {
	}
	
	public override void parse() {
		status = DataReader.ReadShort(dataStream);
		if (status == 0) {
			user_id = DataReader.ReadInt(dataStream);
		//	username = DataReader.ReadString(dataStream);
		//	money = DataReader.ReadInt(dataStream);
		//	level = DataReader.ReadShort (dataStream);
		//	last_logout = DataReader.ReadString(dataStream);
		}
	}
	
	public override ExtendedEventArgs process() {
		ResponseCreateEventArgs args = null;
		if (status == 0) {
			args = new ResponseCreateEventArgs();
		//	args.status = status;
			args.user_id = user_id;
		//	args.username = username;
		//	args.money = money;
		//	args.level = level;
		//	args.last_logout = last_logout;
            Debug.Log("user id is:" + user_id);
           // EditorUtility.DisplayDialog("Connected", "User Id"+user_id, "Ok");

            //  args.player = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/PlayerObject")as GameObject);

        }

        return args;
	}

    
}