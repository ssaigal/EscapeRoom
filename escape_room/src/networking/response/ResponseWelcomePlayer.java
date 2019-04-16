package networking.response;

// Other Imports
import metadata.Constants;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseWelcomePlayer extends GameResponse {

	private short status;
	private String userName;

    public ResponseWelcomePlayer() {
        responseCode = Constants.SMSG_AUTH;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addShort16(status);
        if (status == 0) {
        	System.out.println(userName);
        	packet.addString(userName);
        }
        return packet.getBytes();
    }

    public void setStatus(short status) {
        this.status = status;
    }

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}
}