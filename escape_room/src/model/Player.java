package model;

// Other Imports
import core.GameClient;

/**
 * The Player class holds important information about the player including, most
 * importantly, the account. Such information includes the username, password,
 * email, and the player ID.
 */
public class Player {

    private static int static_id;
    private int player_id;
    private String username;
    private String password;
    private short level;
    private int money;
    private GameClient client; // References GameClient instance
    private static float posX;
    private static float posZ;

    public Player() {
        this.player_id = ++static_id;
    }

    public Player(int player_id, String username, String password) {
        this.player_id = player_id;
        this.username = username;
        this.password = password;
    }

    public int getID() {
        return player_id;
    }

    public int setID(int player_id) {
        return this.player_id = player_id;
    }

    public String getPassword() {
        return password;
    }

    public String setPassword(String password) {
        return this.password = password;
    }

    public String getUsername() {
        return username;
    }

    public String setUsername(String username) {
        return this.username = username;
    }

    public short getLevel() {
        return level;
    }

    public void setLevel(short level) {
        this.level = level;
    }

    public int getMoney() {
        return money;
    }

    public void setMoney(int money) {
        this.money = money;
    }

    public void setPosX(float posX)
    {
        this.posX= posX;
    }

    public void setPosZ(float posZ)
    {
        this.posX= posZ;
    }

    public GameClient getClient() {
        return client;
    }

    public GameClient setClient(GameClient client) {
        return this.client = client;
    }

    @Override
    public String toString() {
        return "Player{" +
                "player_id=" + player_id +
                ", username='" + username + '\'' +
                ", password='" + password + '\'' +
                ", level=" + level +
                ", money=" + money +
                '}';
    }
}
