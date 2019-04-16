package networking.request;

// Java Imports
import java.io.IOException;

import networking.response.ResponsePlayers;
// Other Imports
import networking.response.ResponseTwoPlayer;
import utility.DataReader;
import utility.Log;

/**
 * The RequestLogin class authenticates the user information to log in. Other
 * tasks as part of the login process lies here as well.
 */
public class RequestTwoPlayer extends GameRequest {

    // Data
    private String version;
    private String user_id;
    private static int count=0;
    private String err_response = "You are the only player in the room";
    private String success_response = "Congratulations.. You got the match to play ";
   
    // Responses
    private ResponseTwoPlayer responseTwoPlayer;

    public RequestTwoPlayer() {
    	responses.add(responseTwoPlayer = new ResponseTwoPlayer());
    }
 
    @Override
    public void parse() throws IOException {
    	System.out.println("I am in RequestTwoPlayer Class");
    	version = DataReader.readString(dataInput).trim();
        user_id = DataReader.readString(dataInput).trim();
        System.out.println("Version: "+ version);
        System.out.println("UserID "+user_id);
    }

    @Override
    public void doBusiness() throws Exception {
        Log.printf("User '%s' is connecting...", user_id);
        client.setUserName(user_id);
        count++;
        int countPlayer=count;
        System.out.println(count);
        if(count <= 1) {
        	responseTwoPlayer.setNumberOfPlayerResponse(err_response);
        	System.out.println("Response sent");
        }
        if(countPlayer == 2) {
        	responseTwoPlayer.setStatus((short)0);
    		responseTwoPlayer.setNumberOfPlayerResponse(success_response);
    		count=0;
    	}
    }
}
