package networking.response;

import metadata.Constants;
import model.Player;
import utility.GamePacket;

public class ResponseTimer extends GameResponse{

	private short status;
	private String response;

    public ResponseTimer() {
        responseCode = Constants.SMSG_TIMER;
    }

    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addShort16(status);
        if (status == 0) {
        	System.out.println("I am in responseTimer class for sending response back to client " +response);
        	packet.addString(response);
        }
        return packet.getBytes();
    }
    
	public String getResponse() {
		return response;
	}

	public void setResponse(String response) {
		this.response = response;
	}

	public void setStatus(short status) {
		this.status = status;
	}
}