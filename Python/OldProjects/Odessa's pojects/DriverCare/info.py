# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'info.ui'
#
# Created by: PyQt5 UI code generator 5.13.0
#
# WARNING! All changes made in this file will be lost!


from PyQt5 import QtCore, QtGui, QtWidgets
from PyQt5.QtGui import QIcon


class DialogInfo(object):

    def __init__(self):
        super().__init__()
        self.label = None
        self.describeProgram = None
        self.coreTechnologies = None
        self.instruction = None
        self.principleWork = None

    def setupUi(self, Dialog):
        Dialog.setObjectName("Dialog")
        Dialog.resize(640, 430)
        Dialog.setMinimumSize(QtCore.QSize(640, 430))
        Dialog.setMaximumSize(QtCore.QSize(640, 430))
        self.label = QtWidgets.QLabel(Dialog)
        self.label.setGeometry(QtCore.QRect(0, 0, 640, 430))
        self.label.setText("")
        self.label.setPixmap(QtGui.QPixmap("images/info.png"))
        self.label.setObjectName("label")
        self.describeProgram = QtWidgets.QLabel(Dialog)
        self.describeProgram.setGeometry(QtCore.QRect(30, 25, 581, 51))
        font = QtGui.QFont()
        font.setFamily("Bahnschrift SemiBold")
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.describeProgram.setFont(font)
        self.describeProgram.setStyleSheet("color: #fff;\n"
                                           "")
        self.describeProgram.setWordWrap(True)
        self.describeProgram.setObjectName("label_2")
        self.coreTechnologies = QtWidgets.QLabel(Dialog)
        self.coreTechnologies.setGeometry(QtCore.QRect(30, 85, 581, 51))
        font = QtGui.QFont()
        font.setFamily("Bahnschrift SemiBold")
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.coreTechnologies.setFont(font)
        self.coreTechnologies.setStyleSheet("color: #fff;\n"
                                            "")
        self.coreTechnologies.setWordWrap(True)
        self.coreTechnologies.setObjectName("label_3")
        self.instruction = QtWidgets.QLabel(Dialog)
        self.instruction.setGeometry(QtCore.QRect(30, 155, 581, 91))
        font = QtGui.QFont()
        font.setFamily("Bahnschrift SemiBold")
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.instruction.setFont(font)
        self.instruction.setStyleSheet("color: #fff;\n"
                                       "")
        self.instruction.setWordWrap(True)
        self.instruction.setObjectName("label_4")
        self.principleWork = QtWidgets.QLabel(Dialog)
        self.principleWork.setGeometry(QtCore.QRect(30, 265, 581, 131))
        font = QtGui.QFont()
        font.setFamily("Bahnschrift SemiBold")
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.principleWork.setFont(font)
        self.principleWork.setStyleSheet("color: #fff;\n"
                                         "")
        self.principleWork.setWordWrap(True)
        self.principleWork.setObjectName("label_5")

        self.retranslateUi(Dialog)
        QtCore.QMetaObject.connectSlotsByName(Dialog)

    def retranslateUi(self, Dialog):
        _translate = QtCore.QCoreApplication.translate
        Dialog.setWindowTitle(_translate("Dialog", "Довідка"))
        Dialog.setWindowIcon(QIcon('images/icon.png'))
        self.describeProgram.setText(_translate("Dialog",
                                                "DriverCare - це додаток, призначенням якого слугує допомога водію "
                                                "під час "
                                                "керування транспортним засобом."))
        self.coreTechnologies.setText(_translate("Dialog",
                                                 "Дана програма працює на основі заздалегідь навченої моделі "
                                                 "нейронної мережі "
                                                 "для розпізнавання частин обличчя."))
        self.instruction.setText(_translate("Dialog",
                                            "При натисканні на кнопку \"старт\" починається відеострім з веб-камери, "
                                            "запускається таймер, при натисканні кнопки \"стоп\" відеострім "
                                            "призупиняється разом із таймером.\n"
                                            "Є можливість наглядно побачити, як розпізнаються очі та рот людини, "
                                            "натиснувши кнопку \"відобразити контури\"."))
        self.principleWork.setText(_translate("Dialog",
                                              "Принцип роботи: якщо очі знаходяться в закритому стані "
                                              "або погляд відведено в бік більше 3 секунд спрацьовує сигнал "
                                              "сигналізації.\n\n"
                                              "Також передбачено розпізнавання позіхань — відкритий рот більше 2.5 "
                                              "секунд (мінімальний час позіхання людини).\n"
                                              "Після 5 позіхань водієві озвучується рекомендація зупинити автомобіль "
                                              "та "
                                              "перепочити."))
