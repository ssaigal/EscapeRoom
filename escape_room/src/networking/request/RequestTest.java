package networking.request;

import networking.response.ResponseTest;
import utility.DataReader;
import utility.Log;

import java.io.IOException;

public class RequestTest extends GameRequest {

    private ResponseTest responseTest;

    private String arithmeticOperator;
    private int testNum;

    public RequestTest() {
        this.responses.add(responseTest = new ResponseTest());
    }

    @Override
    public void parse() throws IOException {
        this.arithmeticOperator = DataReader.readString(dataInput);
        this.testNum = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        int newTestVar = this.client.getNewTestVar();
        Log.printf("Received Request to perform " + newTestVar + "(curr val of newTestVar) " + arithmeticOperator + " " + testNum);
        switch (arithmeticOperator) {
            case "+":
                newTestVar = newTestVar + testNum;
                break;
            case "*":
                newTestVar = newTestVar * testNum;
                break;
        }
        this.client.setNewTestVar(newTestVar);
        Log.printf("New Value of newTestVar = " + this.client.getNewTestVar());
    }

}
