package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseLogin extends GameResponse {

    private short status;
    private Player player;
    private String userName;
    private int userID;

    public ResponseLogin() {
        responseCode = Constants.SMSG_AUTH;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addShort16(status);
        if (status == 0) {
//            packet.addInt32(player.getID());
//            packet.addString(player.getUsername());
//            packet.addInt32(player.getMoney());
//            packet.addShort16(player.getLevel());
        	System.out.println("Player ID is: " + player.getID());
        	//packet.addString(userName);
          packet.addInt32(player.getID());
        }
        return packet.getBytes();
    }

    public void setStatus(short status) {
        this.status = status;
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}
  public void setUserID(int id) {
    this.userID = id;
  }

}