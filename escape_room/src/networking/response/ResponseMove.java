package networking.response;

import core.GameClient;
import metadata.Constants;
import utility.GamePacket;

public class ResponseMove extends GameResponse
{
  // May not need to implement, player is already moving in Unity?
  private float posX;
  private float posZ;
  private GameClient client;
  public ResponseMove() {
    responseCode = Constants.SMSG_MOVE;
  }

  @Override
  public byte[] constructResponseInBytes()
  {
    GamePacket packet = new GamePacket(responseCode);

    packet.addInt32(client.getPlayer().getID());
    packet.addFloat(posX);
    packet.addFloat(posZ);
    System.out.println("Creating packet of coordinates to move player: " + client.getPlayer().getID());
    return packet.getBytes();
  }
  public void setPosX(float posX)
  {
    this.posX = posX;
  }
  public void setPosZ(float posZ)
  {
    this.posZ = posZ;
  }
  public void setClient(GameClient client)
  {
    this.client = client;
  }
}
