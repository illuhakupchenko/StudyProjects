package additionalClasses;

// клас для підключення до БД, зчитування/врнесення даних в БД

import java.sql.*;

public class DatabaseHandler extends Configs {
    Connection dbConnection;

    // метод підключення до БД
    public Connection getDbConnection() throws ClassNotFoundException {
        String connectionString = "jdbc:mysql://" + dbHost + ":"
                + dbPort + "/" + dbName + "?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
        Class.forName("com.mysql.cj.jdbc.Driver");
        try {
            dbConnection = DriverManager.getConnection(connectionString, dbUser, dbPass);
        }
        catch (Exception e) {
            System.out.println("no connection");
        }
        return dbConnection;
    }

    // метод внесення даних до БД(реєстрація нового користувача), виклкиається в класі SignUpController
    public void signUpUser(User user) {
        String insert = "INSERT INTO " + Constants.EMPLOYEES_TABLE + " (" + Constants.NAME + "," +
                Constants.SURNAME + "," + Constants.SECNAME + "," + Constants.ACADEMIC_DEGREE +
                "," + Constants.POSITION + "," + Constants.LOGIN + "," +
                Constants.PASSWORD + ")" + " VALUES (?,?,?,?,?,?,?);";
        PreparedStatement prSt;

        try {
            prSt = getDbConnection().prepareStatement(insert);
            prSt.setString(1, user.getFirstName());
            prSt.setString(2, user.getSurName());
            prSt.setString(3, user.getSecName());
            prSt.setString(4, user.getDegree());
            prSt.setString(5, user.getPosition());
            prSt.setString(6, user.getLogin());
            prSt.setString(7, user.getPassword());
            prSt.executeUpdate();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    // метод зчитування даних з БД (авторизація користувача), викликається в класі Controller
    public ResultSet getUser(User user) {
        ResultSet resultSet = null;

        String select = "SELECT * FROM " + Constants.EMPLOYEES_TABLE + " WHERE " + Constants.LOGIN + "=? AND " +
                Constants.PASSWORD + "=?";
        getUserID(user);

        try {
            PreparedStatement prSt = getDbConnection().prepareStatement(select);

            prSt.setString(1, user.getLogin());
            prSt.setString(2, user.getPassword());

            resultSet = prSt.executeQuery();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return resultSet;
    }

    // метод для витягнення даних з БД, викликається в класі MainController
    public ResultSet getResSet(String commandSQL) {
        ResultSet resSet = null;
        try {
            getDbConnection();
            Statement statement = dbConnection.createStatement();
            resSet = statement.executeQuery(commandSQL);
        } catch (ClassNotFoundException | SQLException e) {
            e.printStackTrace();
        }
        return resSet;
    }

    //метод для отримання ID ввійшовшого користувача, викликається в класі Controller
    public void getUserID(User user) {
        try {
            ResultSet res = getResSet("SELECT * FROM " + Constants.EMPLOYEES_TABLE + " WHERE " +
                    Constants.LOGIN + "='" + user.getLogin() + "' AND " + Constants.PASSWORD +
                    "='" + user.getPassword() +"'");
            while (res.next()){
                user.setID(res.getString(Constants.ID));
            }
        }
        catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public ResultSet checkLogin(String login) {
        ResultSet resultSet = null;

        String select = "SELECT * FROM " + Constants.EMPLOYEES_TABLE + " WHERE " + Constants.LOGIN + "=?";

        try {
            PreparedStatement prSt = getDbConnection().prepareStatement(select);

            prSt.setString(1, login);

            resultSet = prSt.executeQuery();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return resultSet;
    }
}
