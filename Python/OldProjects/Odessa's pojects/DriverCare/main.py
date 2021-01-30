from PyQt5 import QtCore, QtGui, QtWidgets
from PyQt5.QtCore import Qt
from PyQt5.QtGui import QIcon

from videostream import Ui_VideoStream
from developer import DialogDeveloper
from info import DialogInfo


class Ui_MainWindow(object):
    def __init__(self):
        self.ui = Ui_VideoStream()
        self.startBtn = None
        self.cetralwidget = None
        self.label = None
        self.referenceBtn = None
        self.nameIMG = None
        self.developerBtn = None

    def openMainW(self):
        try:
            window = QtWidgets.QMainWindow()
            self.ui.setup(window, MainWindow)
            window.show()
            MainWindow.hide()
        except Exception:
            error_dialog = QtWidgets.QErrorMessage()
            error_dialog.showMessage('Oh no!')

    def openDeveloper(self):
        Dialog = QtWidgets.QDialog()
        uiDvlpr = DialogDeveloper()
        uiDvlpr.setupUi(Dialog)
        Dialog.show()
        Dialog.setWindowFlags(Qt.CustomizeWindowHint | Qt.WindowCloseButtonHint | Qt.WindowStaysOnTopHint)
        Dialog.exec_()

    def openInfo(self):
        Dialog = QtWidgets.QDialog()
        uiInfo = DialogInfo()
        uiInfo.setupUi(Dialog)
        Dialog.show()
        Dialog.setWindowFlags(Qt.CustomizeWindowHint | Qt.WindowCloseButtonHint | Qt.WindowStaysOnTopHint)
        Dialog.exec_()

    def setupUi(self, MainWindowObj):
        MainWindowObj.setObjectName("MainWindow")
        MainWindowObj.setWindowModality(QtCore.Qt.WindowModal)
        MainWindowObj.setEnabled(True)
        MainWindowObj.resize(1000, 650)
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Fixed, QtWidgets.QSizePolicy.Fixed)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(MainWindowObj.sizePolicy().hasHeightForWidth())
        MainWindowObj.setSizePolicy(sizePolicy)
        MainWindowObj.setMinimumSize(QtCore.QSize(1000, 650))
        MainWindowObj.setMaximumSize(QtCore.QSize(1000, 650))
        MainWindowObj.setContextMenuPolicy(QtCore.Qt.NoContextMenu)
        MainWindowObj.setAutoFillBackground(False)
        MainWindowObj.setStyleSheet("background-color: #364a65;\n"
                                    "background-image: url(:/newPrefix/main.png);")
        self.cetralwidget = QtWidgets.QWidget(MainWindowObj)
        self.cetralwidget.setObjectName("cetralwidget")
        self.label = QtWidgets.QLabel(self.cetralwidget)
        self.label.setGeometry(QtCore.QRect(0, 0, 1000, 650))
        self.label.setText("")
        self.label.setPixmap(QtGui.QPixmap("images/main.png"))
        self.label.setObjectName("label")
        self.referenceBtn = QtWidgets.QPushButton(self.cetralwidget)
        self.referenceBtn.setEnabled(True)
        self.referenceBtn.setGeometry(QtCore.QRect(879, 600, 91, 31))
        font = QtGui.QFont()
        font.setFamily("MS Shell Dlg 2")
        font.setPointSize(10)
        font.setBold(True)
        font.setWeight(75)
        self.referenceBtn.setFont(font)
        self.referenceBtn.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.referenceBtn.setLayoutDirection(QtCore.Qt.LeftToRight)
        self.referenceBtn.setStyleSheet("QPushButton {\n"
                                        "background: none;\n"
                                        "\n"
                                        "    background-color: #949494;\n"
                                        "    color: #000;    \n"
                                        "    border-radius: 10px;\n"
                                        "    padding: 0px;    \n"
                                        "}\n"
                                        "QPushButton:hover {color: #364a65; font-size: 15px;};")
        self.referenceBtn.setObjectName("referenceBtn")
        self.referenceBtn.clicked.connect(self.openInfo)
        self.startBtn = QtWidgets.QPushButton(self.cetralwidget)
        self.startBtn.setGeometry(QtCore.QRect(750, 300, 191, 41))
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Preferred)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.startBtn.sizePolicy().hasHeightForWidth())
        self.startBtn.setSizePolicy(sizePolicy)
        font = QtGui.QFont()
        font.setFamily("MS Shell Dlg 2")
        font.setPointSize(15)
        font.setBold(True)
        font.setWeight(75)
        self.startBtn.setFont(font)
        self.startBtn.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.startBtn.setLayoutDirection(QtCore.Qt.LeftToRight)
        self.startBtn.setStyleSheet("QPushButton {    \n"
                                    "background: none;\n"
                                    "    background-color: #0bb2e8;\n"
                                    "    color: #d7e7ec;    \n"
                                    "    border-radius: 10px;\n"
                                    "}\n"
                                    "QPushButton:hover {color: #364a65;};")
        self.startBtn.setObjectName("startBtn")
        self.startBtn.clicked.connect(self.openMainW)
        self.nameIMG = QtWidgets.QLabel(self.cetralwidget)
        self.nameIMG.setGeometry(QtCore.QRect(49, 280, 381, 81))
        self.nameIMG.setLayoutDirection(QtCore.Qt.LeftToRight)
        self.nameIMG.setStyleSheet("background: none;")
        self.nameIMG.setText("")
        self.nameIMG.setPixmap(QtGui.QPixmap("images/Name.png"))
        self.nameIMG.setAlignment(QtCore.Qt.AlignLeading | QtCore.Qt.AlignLeft | QtCore.Qt.AlignVCenter)
        self.nameIMG.setObjectName("nameIMG")
        self.developerBtn = QtWidgets.QPushButton(self.cetralwidget)
        self.developerBtn.setGeometry(QtCore.QRect(749, 600, 101, 31))
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Preferred)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.developerBtn.sizePolicy().hasHeightForWidth())
        self.developerBtn.setSizePolicy(sizePolicy)
        self.developerBtn.clicked.connect(self.openDeveloper)

        font = QtGui.QFont()
        font.setFamily("MS Shell Dlg 2")
        font.setPointSize(10)
        font.setBold(True)
        font.setWeight(75)
        self.developerBtn.setFont(font)
        self.developerBtn.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.developerBtn.setLayoutDirection(QtCore.Qt.LeftToRight)
        self.developerBtn.setStyleSheet("QPushButton {    \n"
                                        "background: none;\n"
                                        "    background-color: #949494;\n"
                                        "    color: #000;    \n"
                                        "    border-radius: 10px;\n"
                                        "    padding: 0px;    \n"
                                        "}\n"
                                        "QPushButton:hover {color: #364a65; font-size: 15px;};")
        self.developerBtn.setObjectName("developerBtn")
        MainWindowObj.setCentralWidget(self.cetralwidget)

        self.retranslateUi(MainWindowObj)
        QtCore.QMetaObject.connectSlotsByName(MainWindowObj)

    def retranslateUi(self, MainWindowObj):
        _translate = QtCore.QCoreApplication.translate
        MainWindowObj.setWindowTitle(_translate("MainWindow", "DriverCare"))
        MainWindowObj.setWindowIcon(QIcon('images/icon.png'))
        self.referenceBtn.setText(_translate("MainWindow", "Довідка"))
        self.startBtn.setText(_translate("MainWindow", "Розпочати"))
        self.developerBtn.setText(_translate("MainWindow", "Розробник"))


if __name__ == "__main__":
    import sys

    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())
