package additionalClasses;

public class TableList {
    String id;
    String name;
    String surname;
    String secname;
    String groupname;
    String realID;
    String subject;
    String teacher;
    String hours;
    String exam;
    String subjname;
    String unitnumber;
    String classnumber;
    String studyday;
    String student;
    String theme;

    public String getStudent() {
        return student;
    }

    public void setStudent(String student) {
        this.student = student;
    }

    public String getTheme() {
        return theme;
    }

    public void setTheme(String theme) {
        this.theme = theme;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public void setSecname(String secname) {
        this.secname = secname;
    }

    public void setGroupname(String groupname) {
        this.groupname = groupname;
    }

    public void setRealID(String realID) {
        this.realID = realID;
    }

    public void setSubject(String subject) {
        this.subject = subject;
    }

    public void setTeacher(String teacher) {
        this.teacher = teacher;
    }

    public void setHours(String hours) {
        this.hours = hours;
    }

    public void setExam(String exam) {
        this.exam = exam;
    }

    public String getSubjname() {
        return subjname;
    }

    public void setSubjname(String subjname) {
        this.subjname = subjname;
    }

    public String getUnitnumber() {
        return unitnumber;
    }

    public void setUnitnumber(String unitnumber) {
        this.unitnumber = unitnumber;
    }

    public String getClassnumber() {
        return classnumber;
    }

    public void setClassnumber(String classnumber) {
        this.classnumber = classnumber;
    }

    public String getStudyday() {
        return studyday;
    }

    public void setStudyday(String studyday) {
        this.studyday = studyday;
    }

    public String getSurname() {
        return surname;
    }

    public String getSecname() {
        return secname;
    }

    public String getGroupname() {
        return groupname;
    }

    public String getSubject() {
        return subject;
    }

    public String getTeacher() {
        return teacher;
    }

    public String getHours() {
        return hours;
    }

    public String getExam() {
        return exam;
    }

    public TableList (String id, String name, String surname, String secname, String realID){
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.secname = secname;
        this.realID = realID;
        this.subject = id;
        this.teacher = name;
        this.hours = surname;
        this.exam = secname;
        this.unitnumber = name;
        this.subjname = surname;
        this.classnumber = secname;
        this.studyday = realID;
        this.student = id;
        this.groupname = surname;
        this.theme = secname;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getRealID() {
        return realID;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurName() {
        return surname;
    }

    public void setSurName(String surName) {
        this.surname = surName;
    }

    public String getSecName() {
        return secname;
    }

    public void setSecName(String secName) {
        this.secname = secName;
    }

    public String getGroupName() {
        return groupname;
    }

    public void setGroupName(String groupName) {
        this.groupname = groupName;
    }

}

