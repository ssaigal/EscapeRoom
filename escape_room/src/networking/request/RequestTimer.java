package networking.request;

// Java Imports
import java.io.IOException;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.TimeUnit;

import configuration.GameServerConf;
// Other Imports
import networking.response.ResponseTimer;
import utility.ConfFileParser;
import utility.Log;

/**
 * The RequestLogin class authenticates the user information to log in. Other
 * tasks as part of the login process lies here as well.
 */
public class RequestTimer extends GameRequest {

    // Responses
    private ResponseTimer responseTimer;
    private String response = "Game is Over";

    public RequestTimer() {
        responses.add(responseTimer = new ResponseTimer());
    }

    @Override
    public void doBusiness() throws Exception {
        Log.printf("Timer Countdown begins:\n");
        
        responseTimer.setStatus((short)0);
    	responseTimer.setResponse(response);
    	
        int i=200;
        int time;
        while(i>0) {
        	time=i*200;
        	System.out.println("Your Life ends in "+ time + " milliseconds");
        	i=i-1;
        	try {
        		TimeUnit.MILLISECONDS.sleep(100);
        		}catch(InterruptedException e) {
        			System.out.println("You cannot escape your destiny");
        		}
        	if(i==0) {
        		System.out.println("Bye-Bye.. Your life is over");
        	}
        }
    }

	@Override
	public void parse() throws IOException {
		// TODO Auto-generated method stub
		System.out.println("I am in ReqTimer CLass");
	}
}
