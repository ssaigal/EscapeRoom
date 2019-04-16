package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import networking.response.ResponseWelcomePlayer;
import utility.DataReader;
import utility.Log;

/**
 * The RequestLogin class authenticates the user information to log in. Other
 * tasks as part of the login process lies here as well.
 */
public class RequestWelcomePlayer extends GameRequest {

    // Data
    private String user_id;
    // Responses
    private ResponseWelcomePlayer responseWelcomePlayer;

    public RequestWelcomePlayer() {
        responses.add(responseWelcomePlayer = new ResponseWelcomePlayer());
    }

    @Override
    public void parse() throws IOException {
        user_id = DataReader.readString(dataInput).trim();
    }

    @Override
    public void doBusiness() throws Exception {
        Log.printf("User '%s' is connecting...", user_id);
//        Player player = null;
        client.setUserName(user_id);
        
        responseWelcomePlayer.setStatus((short)0);
        responseWelcomePlayer.setUserName(user_id);       
    }
}
