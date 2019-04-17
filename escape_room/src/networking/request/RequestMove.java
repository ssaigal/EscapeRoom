package networking.request;
import model.Player;
import networking.response.ResponseMove;
import utility.DataReader;

import java.io.IOException;

public class RequestMove extends GameRequest
{
  private ResponseMove responseMove;
  private float posX;
  private float posZ;
  //private Player player;

  public RequestMove() {
    responses.add(responseMove = new ResponseMove());
  }
  @Override
  public void parse() throws IOException
  {
    // Reading data from move request.
      this.posX = DataReader.readInt(dataInput);
      this.posZ = DataReader.readInt(dataInput);
    System.out.printf("Data read to move successfully. X: " + posX + " Z: " + posZ + "\n");
  }

  @Override
  public void doBusiness() throws Exception
  {

    // Passing values over to response to generate response message back to Unity
//    player.setPosX(posX);
 //   player.setPosZ(posZ);
    responseMove.setClient(client);
    responseMove.setPosX(posX);
    responseMove.setPosZ(posZ);
    System.out.println("Move request executed");
  }
}
