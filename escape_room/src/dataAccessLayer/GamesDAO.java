package dataAccessLayer;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

public class GamesDAO {

    private GamesDAO() {
    }

    public static void insertGame(String teamName, int score, int playerId) throws  SQLException{
        String query = "INSERT INTO `Games` (`team_name`,`score`,`player_id`) VALUES (?,?,?)";

        Connection connection = null;
        PreparedStatement pstmt = null;

        try {
            connection = DAO.getDataSource().getConnection();
            pstmt = connection.prepareStatement(query);
            pstmt.setString(1, teamName);
            pstmt.setInt(2, score);
            pstmt.setInt(3, playerId);
            pstmt.executeQuery();
        }
        catch (SQLException e){
            e.printStackTrace();
        }
        finally {
            if (connection != null) {
                connection.close();
            }
        }
    }

    public static Map<String, Integer> getTopScorers() throws SQLException {
        Map<String, Integer> scoreBoard = new HashMap();

        String query = "SELECT * FROM `Games` ORDER BY `score` DESC LIMIT 5";

        Connection connection = null;
        PreparedStatement pstmt = null;

        try {
            connection = DAO.getDataSource().getConnection();
            pstmt = connection.prepareStatement(query);
            ResultSet rs = pstmt.executeQuery();


            while (rs.next()) {
                String teamName = rs.getString("team_name");
                int score = rs.getInt("score");

                scoreBoard.put(teamName,score);
            }

            rs.close();
            pstmt.close();
        }
        catch (SQLException e) {
            e.printStackTrace();
        }
        finally {
            if (connection != null) {
                connection.close();
            }
        }
        return scoreBoard;
    }
}
