package networking.response;

import metadata.Constants;
import model.Player;
import utility.GamePacket;

public class ResponseAuthentication extends GameResponse  {
	private short status;
    private Player player;

    public ResponseAuthentication() {
        responseCode = Constants.SMSG_LOGIN;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addShort16(status);
        if (status == 0) {
            packet.addInt32(player.getID());
            packet.addString(player.getUsername());
        }
        return packet.getBytes();
    }

    public void setStatus(short status) {
        this.status = status;
    }

    public void setPlayer(Player player) {
        this.player = player;
    }
}
