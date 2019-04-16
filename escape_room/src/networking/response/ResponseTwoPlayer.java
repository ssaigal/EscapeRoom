package networking.response;

import core.GameServer;
import metadata.Constants;
import utility.GamePacket;

public class ResponseTwoPlayer extends GameResponse{

	
	private short status;
	private String response;

    public ResponseTwoPlayer() {
        responseCode = Constants.SMSG_PLAYER_JOIN;
    }

    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addShort16(status);
        if (status == 0) {
          packet.addString(response);
        	System.out.println(response);
        	
        }
        return packet.getBytes();
    }
    
	public String getNumberOfPlayerResponse() {
		return response;
	}

	public void setNumberOfPlayerResponse(String response) {
		// TODO Auto-generated method stub
		this.response = response;
	}


	public short getStatus() {
		return status;
	}


	public void setStatus(short status) {
		this.status = status;
	}
}
