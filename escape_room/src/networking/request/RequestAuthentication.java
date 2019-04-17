package networking.request;

//Java Imports
import java.io.IOException;
import java.util.List;

//Other Imports
import core.GameClient;
import core.GameServer;
import dataAccessLayer.UsersDAO;
import metadata.Constants;
import model.Player;
import networking.response.ResponseAuthentication;
import utility.DataReader;
import utility.Log;


public class RequestAuthentication extends GameRequest{
	 private String version;
	    private String user_id;
	    private String password;
	    // Responses
	    private ResponseAuthentication responseLogin;

	    public RequestAuthentication() {
	        responses.add(responseLogin = new ResponseAuthentication());
	    }

	    @Override
	    public void parse() throws IOException {
	        version = DataReader.readString(dataInput).trim();
	        user_id = DataReader.readString(dataInput).trim();
	        password = DataReader.readString(dataInput).trim();
	    }

	    @Override
	    public void doBusiness() throws Exception {
	        Log.printf("User '%s' is connecting...", user_id);
	        Player player = null;
	        // Checks if the connecting client meets the minimum version required
	        if (version.compareTo(Constants.CLIENT_VERSION) >= 0) {
	            if (!user_id.isEmpty()) {
	                // Verification Needed
	                player = UsersDAO.getUserFromDbIfCredentialsAreValid(user_id, password);
	            }
	            if (player == null) {
	                responseLogin.setStatus((short) 1); // User info is incorrect
	                Log.printf("User '%s' has failed to log in.", user_id);
	            } else {
	                player.setClient(client);
	                if (client.getPlayer() == null || player.getID() != client.getPlayer().getID()) {
	                    GameClient thread = GameServer.getInstance().getThreadByPlayerID(player.getID());
	                    // If account is already in use, remove and disconnect the client
	                    if (thread != null) {
	                        responseLogin.setStatus((short) 2); // Account is in use
	                        thread.removePlayerData();
	                        thread.newSession();
	                        Log.printf("User '%s' account is already in use.", user_id);
	                    } else {
	                        // Continue with the login process
	                        GameServer.getInstance().setActivePlayer(player);
	                        player.setClient(client);
	                        // Pass Player reference into thread
	                        client.setPlayer(player);
	                        // Set response information
	                        responseLogin.setStatus((short) 0); // Login is a success
	                        responseLogin.setPlayer(player);
	                        Log.printf("User '%s' has successfully logged in.", player.getUsername());
	                    }
	                }
	            }
	        } else {
	            responseLogin.setStatus((short) 3); // Client version not compatible
	            Log.printf("User '%s' has failed to log in. (v%s)", player.getUsername(), version);
	        }
	    }

}
