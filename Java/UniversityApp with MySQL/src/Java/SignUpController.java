package Java;

import additionalClasses.Constants;
import additionalClasses.DatabaseHandler;
import additionalClasses.NewScene;
import additionalClasses.User;
import javafx.fxml.FXML;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ButtonType;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.*;
import java.net.MalformedURLException;
import java.sql.Blob;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Optional;

public class SignUpController {

    @FXML
    public javafx.scene.image.ImageView imgView;

    @FXML
    public ImageView miniImage;

    @FXML
    private TextField surname_field;

    @FXML
    private Button sign_UP_btn;

    @FXML
    private TextField name_field;

    @FXML
    private TextField secname_field;

    @FXML
    private TextField degree_field;

    @FXML
    private TextField position_field;

    @FXML
    private TextField login_field;

    @FXML
    private Button uploadIMG_btn;

    @FXML
    private TextField password_field;

    private Stage stage;

    NewScene newScene = new NewScene();

    // метод викликається в класі NewScene, він встановлює об'єкт для доступу до головного вікна
    public void setStage(Stage stage){
        this.stage = stage;
    }

    public Stage getStage() {
        return stage;
    }

    private PreparedStatement store;
    FileChooser fileChooser;
    File file;
    DatabaseHandler databaseHandler = new DatabaseHandler();
    User user;


    @FXML
    void initialize() {
        sign_UP_btn.setOnAction(event -> sign_UP_newUser());

        uploadIMG_btn.setOnAction(event -> {
            fileChooser = new FileChooser();
            fileChooser.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("Images", "*.jpg", "*.png", "*.jpeg")); //

            file = fileChooser.showOpenDialog(uploadIMG_btn.getScene().getWindow());
            Image image = null;
            try {
                image = new Image(file.toURL().toString());
            } catch (MalformedURLException | NullPointerException e) {
                newScene.alertWindow("Увага", "Файл не вибрано!");
            }
            imgView.setImage(image);
        });
    }

    private void sign_UP_newUser() {
        DatabaseHandler dbHandler = new DatabaseHandler();

        String name = name_field.getText();
        String surname = surname_field.getText();
        String secname = secname_field.getText();
        String degree = degree_field.getText();
        String position = position_field.getText();
        String login = login_field.getText();
        String pass = password_field.getText();
        ResultSet res = dbHandler.checkLogin(login);

        int counter = 0;

        try {
            while (res.next()){
                counter++;
            }
        }
        catch (SQLException e){
            e.printStackTrace();
        }

        if(!name.equals("") && !surname.equals("") && !secname.equals("") && !degree.equals("") && !position.equals("")
                && !login.equals("") && !pass.equals("")) {
            user = new User(name, surname, secname, degree, position, login, pass, "0");

            if(counter==0) {
                dbHandler.signUpUser(user);
                newScene.alertWindow("УВАГА!", "Ви успішно зареєстровані в системі!");
                Stage stagethis = (Stage) sign_UP_btn.getScene().getWindow();
                stagethis.close();
                getStage().show();
                dbHandler.getUserID(user);
                if(file!=null)
                    uploadImg();
            }
            else
                newScene.alertWindow("Увага!", "Користувач з таким логіном вже існує!\nСпробуйте інший!");
        }
        else
            newScene.alertWindow("Увага!", "Заповніть всі поля для реєстрації!");
    }

    public void uploadImg(){

        try {
            String commandINSERT = "INSERT INTO img(image, iduser) VALUES(?, ?)";
            store = databaseHandler.getDbConnection().prepareStatement(commandINSERT);

        } catch (ClassNotFoundException | SQLException e) {
            e.printStackTrace();
        }

        try {
            FileInputStream fileInputStream = new FileInputStream(file);

            store.setBinaryStream(1, fileInputStream, fileInputStream.available());
            store.setString(2, user.getID());
            store.execute();

        }
        catch (SQLException | IOException | NullPointerException ex) {
            ex.printStackTrace();
        }
    }

}
