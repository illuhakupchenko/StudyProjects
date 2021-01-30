package additionalClasses;

import Java.Controller;
import Java.MainWindowController;
import Java.SignUpController;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.image.Image;
import javafx.stage.Stage;

import java.io.IOException;

//клас для створення нового вікна(відкриття)

public class NewScene {

    private Stage stage;

    // метод створення вікна діалогу
    public void alertWindow(String title, String text) {
        Alert alert = new Alert(Alert.AlertType.INFORMATION);

        alert.setTitle(title);
        alert.setHeaderText(null);
        alert.setContentText(text);

        alert.showAndWait();
    }

    // метод створення нового вікна(відкриття)
    public void openNewScene(String new_window, String title, String ID) {

        FXMLLoader fxmloader = new FXMLLoader();
        fxmloader.setLocation(getClass().getResource(new_window));

        try {
            fxmloader.load();
        } catch (IOException e) {
            e.printStackTrace();
        }

        Parent root = fxmloader.getRoot();
        Stage stage = new Stage();
        stage.setScene(new Scene(root));
        stage.setTitle(title);
        stage.getIcons().add(new Image("/media/icon.png"));
        stage.setResizable(false);
        stage.setOnCloseRequest( event -> {
            if(!title.equals("Кафедра"))
                getNewStage().show();
        });
        if(title.equals("Кафедра")) {
            MainWindowController mainWindowController = fxmloader.getController();
            mainWindowController.setID(ID); // передача даних в нове вікно
            mainWindowController.setStage(getNewStage()); // передача даних в нове вікно
        }
        if(title.equals("Кафедра | Реєстрація")) {
            SignUpController controller = fxmloader.getController();
            controller.setStage(getNewStage());
        }
        stage.showAndWait();

    }

    // метод для встановлення ідентифікації поточного вікна для подальшого відкриття, викликається в класі Controller
    public void setNewStage(Stage stage) { this.stage = stage; }

    public Stage getNewStage() { return stage; }
}
