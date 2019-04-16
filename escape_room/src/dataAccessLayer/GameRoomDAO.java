package dataAccessLayer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

public class GameRoomDAO {

    public static boolean checkGameRoomAvailability(int gameId) throws SQLException {
        boolean available = true;
        String query = "SELECT * FROM `GameUsers` where `game_id`="+gameId;
        Connection connection = null;
        PreparedStatement pstmt = null;

        try {
            connection = DAO.getDataSource().getConnection();
            pstmt = connection.prepareStatement(query);
            ResultSet rs = pstmt.executeQuery();

            while (rs.next()) {
                int player1 = rs.getInt("player1_id");
                int player2 = rs.getInt("player2_id");

                if(player1 > 0 && player2 > 0){
                        available = false;
                }
            }
            rs.close();
            pstmt.close();
        }
        catch (SQLException e) {
            e.printStackTrace();
        }finally {
            if (connection != null) {
                connection.close();
            }
        }
        return available;
    }

}
