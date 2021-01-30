package Java;

import java.sql.ResultSet;
import java.sql.SQLException;

import additionalClasses.*;
import animation.Shake;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class Controller {

    @FXML
    private TextField login_field;

    @FXML
    private TextField password_field;

    @FXML
    private Button sign_IN_btn;

    @FXML
    private Button sign_UP_btn;

    @FXML
    private Button signIN_Student_btn;

    NewScene newScene = new NewScene();
    DatabaseHandler db = new DatabaseHandler();


    @FXML
    void initialize() {
        sign_UP_btn.setOnAction(event -> {
            try {
                if(!db.getDbConnection().isClosed()){
                    sign_UP_btn.getScene().getWindow().hide();
                    newScene.setNewStage((Stage)(sign_UP_btn.getScene().getWindow()));
                    newScene.openNewScene("/layout/sign_up.fxml", "Кафедра | Реєстрація", "0");
                    login_field.clear();
                    password_field.clear();
                }
            } catch (SQLException | NullPointerException | ClassNotFoundException e) {
                newScene.alertWindow("Увага!", "З'єднання з БД не встановлено, спробуйте іншим разом!");
            }

        });

        signIN_Student_btn.setOnAction(event -> {
            try {
                if(!db.getDbConnection().isClosed()){
                    signIN_Student_btn.getScene().getWindow().hide();
                    newScene.setNewStage((Stage)(sign_UP_btn.getScene().getWindow()));
                    newScene.openNewScene("/layout/main_window.fxml", "Кафедра", "0");
                    login_field.clear();
                    password_field.clear();
                }
            } catch (SQLException | NullPointerException |ClassNotFoundException e) {
                newScene.alertWindow("Увага!", "З'єднання з БД не встановлено, спробуйте іншим разом!");
            }
        });

        sign_IN_btn.setOnAction(event -> {
            try {
                if(!db.getDbConnection().isClosed()){
                    System.out.println("yes");
                    String login = login_field.getText().trim();
                    String pass = password_field.getText().trim();

                    if (!login.equals("") && !pass.equals("")) {
                        loginUser(login, pass);
                        login_field.clear();
                        password_field.clear();
                    }
                    else {
                        newScene.alertWindow("Увага!", "Введіть логін та пароль!");
                    }

                }
            } catch (SQLException | NullPointerException | ClassNotFoundException e) {
                newScene.alertWindow("Увага!", "З'єднання з БД не встановлено, спробуйте іншим разом!");
            }
        });

        //test.setItems(FXCollections.observableArrayList(getData()));

       /* lol.setOnAction(event -> {
            test.setValue("hi");
            kek.setText(test.getValue());
        });*/

    }

    // метод для авторизації користувача, викликається getUser(), а потім йде перевірка на наявність користувача
    private void loginUser(String login, String pass) {
        DatabaseHandler dbHandler = new DatabaseHandler();
        User user = new User();
        user.setLogin(login);
        user.setPassword(pass);
        ResultSet res = dbHandler.getUser(user);

        int counter = 0;

        try {
            while (res.next()){
                counter++;
            }
        }
        catch (SQLException e){
            e.printStackTrace();
        }

        Shake userLogAnim = new Shake(login_field);
        Shake userPassAnim = new Shake(password_field);

        if(counter >= 1) {
            sign_IN_btn.getScene().getWindow().hide();
            newScene.setNewStage((Stage)(sign_UP_btn.getScene().getWindow()));
            newScene.openNewScene("/layout/main_window.fxml", "Кафедра", user.getID());
        }
        else {
            userLogAnim.playAnim();
            userPassAnim.playAnim();
        }
    }


}
