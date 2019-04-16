using UnityEngine;

using System;

public class RequestCreate : NetworkRequest {

	public RequestCreate() {
		request_id = Constants.CMSG_AUTH;
	}
	
	public void send(int id) {
	    packet = new GamePacket(request_id);
		packet.addString(Constants.CLIENT_VERSION);
		packet.addInt32(id);
		//packet.addString(password);
	}
}