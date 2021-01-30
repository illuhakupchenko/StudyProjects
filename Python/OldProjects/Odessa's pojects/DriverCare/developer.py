# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'rozr.ui'
#
# Created by: PyQt5 UI code generator 5.13.0
#
# WARNING! All changes made in this file will be lost!
import webbrowser

from PyQt5 import QtCore, QtGui, QtWidgets
from PyQt5.QtGui import QIcon


class DialogDeveloper(object):

    def __init__(self):
        super().__init__()
        self.img = None
        self.developerText = None
        self.gitBtn = None

    def openGit(self):
        webbrowser.open('https://github.com/illuhakupchenko/Python/tree/master/DriverCare', new=2)

    def setupUi(self, Dialog):
        Dialog.setObjectName("Dialog")
        Dialog.resize(640, 430)
        Dialog.setMinimumSize(QtCore.QSize(640, 430))
        Dialog.setMaximumSize(QtCore.QSize(640, 430))
        self.img = QtWidgets.QLabel(Dialog)
        self.img.setGeometry(QtCore.QRect(0, 0, 641, 441))
        self.img.setText("")
        self.img.setPixmap(QtGui.QPixmap("images/dvlpr.png"))
        self.img.setObjectName("img")
        self.developerText = QtWidgets.QLabel(Dialog)
        self.developerText.setGeometry(QtCore.QRect(110, 100, 431, 191))
        font = QtGui.QFont()
        font.setFamily("Bahnschrift SemiBold")
        font.setPointSize(20)
        font.setBold(True)
        font.setWeight(75)
        self.developerText.setFont(font)
        self.developerText.setStyleSheet("color: #fff;\n"
                                         "")
        self.developerText.setWordWrap(True)
        self.developerText.setObjectName("label_2")
        self.gitBtn = QtWidgets.QPushButton(Dialog)
        self.gitBtn.setGeometry(QtCore.QRect(110, 350, 91, 31))
        font = QtGui.QFont()
        font.setFamily("Microsoft YaHei UI")
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.gitBtn.setFont(font)
        self.gitBtn.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.gitBtn.setStyleSheet("border-radius: 5px;\n"
                                  "background: #8a0399;\n"
                                  "color: #fff;\n"
                                  "")
        self.gitBtn.setObjectName("pushButton")
        self.gitBtn.clicked.connect(self.openGit)

        self.retranslateUi(Dialog)
        QtCore.QMetaObject.connectSlotsByName(Dialog)

    def retranslateUi(self, Dialog):
        _translate = QtCore.QCoreApplication.translate
        Dialog.setWindowTitle(_translate("Dialog", "Розробник"))
        Dialog.setWindowIcon(QIcon('images/icon.png'))
        self.developerText.setText(_translate("Dialog",
                                              "Програму розробив студент 4-го курсу Одеської національної академії "
                                              "зв\'язку "
                                              "ім. О.С. Попова, група ІПЗ-4.2.03\n"
                                              "Купченко Ілля Сергійович"))
        self.gitBtn.setText(_translate("Dialog", "GitHub"))
