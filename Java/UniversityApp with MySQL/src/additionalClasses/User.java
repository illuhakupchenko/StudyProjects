package additionalClasses;

// клас користувача

public class User {
    private String firstName;
    private String surName;
    private String secName;
    private String degree;
    private String position;
    private String login;
    private String password;
    private String ID;

    private String supervisor;
    private String sci_direction;
    private String theme;
    private String telephone;

    public void setSupervisor(String supervisor) {
        this.supervisor = supervisor;
    }

    public void setSci_direction(String sci_direction) {
        this.sci_direction = sci_direction;
    }

    public void setTheme(String theme) {
        this.theme = theme;
    }

    public String getTelephone() {
        return telephone;
    }

    public void setTelephone(String telephone) {
        this.telephone = telephone;
    }

    public User(){}

    public String getSupervisor() {
        return supervisor;
    }

    public String getSci_direction() {
        return sci_direction;
    }

    public String getTheme() {
        return theme;
    }

    // конструктор для аспірантів і робітників
    public User(String firstName, String surName, String secName, String supervisor, String sci_direction, String theme, String ID) {
        this.firstName = firstName;
        this.surName = surName;
        this.secName = secName;
        this.supervisor = supervisor;
        this.sci_direction = sci_direction;
        this.theme = theme;
        this.ID = ID;
        this.position = supervisor;
        this.degree = sci_direction;
        this.telephone = theme;
    }

    // конструктор для реєстрації
    public User(String firstName, String surName, String secName, String degree, String position, String login, String password, String ID) {
        this.firstName = firstName;
        this.surName = surName;
        this.secName = secName;
        this.degree = degree;
        this.position = position;
        this.login = login;
        this.password = password;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getSurName() {
        return surName;
    }

    public void setSurName(String surName) {
        this.surName = surName;
    }

    public String getSecName() {
        return secName;
    }

    public void setSecName(String secName) {
        this.secName = secName;
    }

    public String getDegree() {
        return degree;
    }

    public void setDegree(String degree) {
        this.degree = degree;
    }

    public String getPosition() {
        return position;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
    }
}
