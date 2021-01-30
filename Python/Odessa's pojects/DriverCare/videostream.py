# -*- coding: utf-8 -*-

from datetime import datetime, timedelta

from PyQt5 import QtCore, QtGui, QtWidgets
from PyQt5.QtGui import QImage, QIcon, QPixmap
from PyQt5.QtCore import QTimer
from PyQt5.QtWidgets import QWidget
from scipy.spatial import distance as dist
from imutils import face_utils
from threading import Thread
import playsound
import dlib
import cv2


# функція програвання аудіозаписів
def play_audio(path):
    playsound.playsound(path)


# функція визначення погляду
def head_point_calc(left, right, center):
    left_point_calc = abs(left - center)
    right_point_calc = abs(right - center)
    if left_point_calc != 0:
        head_direction = left_point_calc / right_point_calc
    else:
        head_direction = 0
    head_position = head_direction < 0.4 or head_direction > 2.6
    return head_position


# функція визначення стану очей
def earFun(eye):
    # обчислення евклідових відстаней між середніми точками ока
    aver1 = dist.euclidean(eye[1], eye[5])
    aver2 = dist.euclidean(eye[2], eye[4])
    # обчислення евклідової відстані між крайніми точками ока
    left_right = dist.euclidean(eye[0], eye[3])

    # обчислення відношення сторін очей
    ear = (aver1 + aver2) / (2.0 * left_right)
    return ear


# функція визначення положення губ
def marFun(mouth):
    aver1 = dist.euclidean(mouth[2], mouth[10])  # 51, 59
    aver2 = dist.euclidean(mouth[4], mouth[8])  # 53, 57

    left_right = dist.euclidean(mouth[0], mouth[6])  # 49, 55

    mar = (aver1 + aver2) / (2.0 * left_right)
    return mar


# ініціалізація детектору розпізнавення обличчя dlib
detector = dlib.get_frontal_face_detector()
# завантаження попередньо навченої моделі нейронної мережі для розпізнавання 68 ключових точок на обличчі людини
predictor = dlib.shape_predictor("shape_predictor_68_face_landmarks.dat")

# за допомогою бібліотеки face_utils визначаємо індекси точок частин обличчя (від початку до кінця)
(lStart, lEnd) = face_utils.FACIAL_LANDMARKS_IDXS["left_eye"]
(rStart, rEnd) = face_utils.FACIAL_LANDMARKS_IDXS["right_eye"]
(mStart, mEnd) = face_utils.FACIAL_LANDMARKS_IDXS["mouth"]


class Ui_VideoStream(QWidget):
    COUNTER_EYES = 0
    COUNTER_MOUTH_TIME = 0
    COUNTER_HEAD_DIR_TIME = 0
    COUNTER_MOUTH_TIMES = 0
    ALARM_ON = False  # змінна для програвання аудіозаписів
    checkContour = False  # змінна для малювання контурів

    def __init__(self):
        super().__init__()
        self.window = None
        self.VideoM = None
        self.centralwidget = None
        self.videoLabel = None
        self.exitBtn = None
        self.helloLabel = None
        self.timerLabel = None
        self.startBtn = None
        self.timeNameLabel = None
        self.eyesPositionLabel = None
        self.showBtn = None
        self.timer = None
        self.cap = None
        self.flag = None
        self.seconds_timer = None
        self.timer1 = None

    def setup(self, VideoStream_W, main_w):
        self.window = main_w
        self.VideoM = VideoStream_W

        VideoStream_W.setObjectName("VideoStream")
        VideoStream_W.resize(950, 480)
        VideoStream_W.setMinimumSize(QtCore.QSize(950, 480))
        VideoStream_W.setMaximumSize(QtCore.QSize(950, 480))
        VideoStream_W.setCursor(QtGui.QCursor(QtCore.Qt.ArrowCursor))
        VideoStream_W.setStyleSheet("background-color: #364a65;")
        self.centralwidget = QtWidgets.QWidget(VideoStream_W)
        self.centralwidget.setObjectName("centralwidget")
        self.videoLabel = QtWidgets.QLabel(self.centralwidget)
        self.videoLabel.setGeometry(QtCore.QRect(0, 0, 680, 480))
        self.videoLabel.setText("")
        self.videoLabel.setObjectName("videoLabel")
        self.videoLabel.setPixmap(QtGui.QPixmap("images/video.png"))

        self.exitBtn = QtWidgets.QPushButton(self.centralwidget)
        self.exitBtn.setGeometry(QtCore.QRect(850, 432, 75, 31))
        font = QtGui.QFont()
        font.setPointSize(10)
        font.setBold(True)
        font.setWeight(75)
        self.exitBtn.setFont(font)
        self.exitBtn.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.exitBtn.setStyleSheet("QPushButton {    \n"
                                   "    background: none;\n"
                                   "    background-color: #db0935;\n"
                                   "    color: #d7e7ec;    \n"
                                   "    border-radius: 10px;\n"
                                   "}\n"
                                   "QPushButton:hover {color: #364a65;};")
        self.exitBtn.setObjectName("exitBtn")
        self.helloLabel = QtWidgets.QLabel(self.centralwidget)
        self.helloLabel.setGeometry(QtCore.QRect(700, 40, 231, 41))
        font = QtGui.QFont()
        font.setPointSize(12)
        font.setBold(True)
        font.setWeight(75)
        self.helloLabel.setFont(font)
        self.helloLabel.setStyleSheet("color: #fff;\n")
        self.helloLabel.setLineWidth(2)
        self.helloLabel.setTextFormat(QtCore.Qt.AutoText)
        self.helloLabel.setScaledContents(False)
        self.helloLabel.setAlignment(QtCore.Qt.AlignLeading | QtCore.Qt.AlignLeft | QtCore.Qt.AlignTop)
        self.helloLabel.setWordWrap(True)
        self.helloLabel.setOpenExternalLinks(False)
        self.helloLabel.setObjectName("nameLabel")
        self.timerLabel = QtWidgets.QLabel(self.centralwidget)
        self.timerLabel.setGeometry(QtCore.QRect(840, 170, 81, 16))
        font = QtGui.QFont()
        font.setPointSize(13)
        font.setBold(True)
        font.setWeight(75)
        self.timerLabel.setFont(font)
        self.timerLabel.setStyleSheet("color: #fff;\n"
                                      "")
        self.timerLabel.setObjectName("timerLabel")
        self.showBtn = QtWidgets.QPushButton(self.centralwidget)
        self.showBtn.setGeometry(QtCore.QRect(700, 100, 161, 41))
        sizePolicy = QtWidgets.QSizePolicy(QtWidgets.QSizePolicy.Preferred, QtWidgets.QSizePolicy.Preferred)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.showBtn.sizePolicy().hasHeightForWidth())
        self.showBtn.setSizePolicy(sizePolicy)
        font = QtGui.QFont()
        font.setFamily("MS Shell Dlg 2")
        font.setPointSize(10)
        font.setBold(True)
        font.setWeight(75)
        self.showBtn.setFont(font)
        self.showBtn.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.showBtn.setLayoutDirection(QtCore.Qt.LeftToRight)
        self.showBtn.setStyleSheet("QPushButton {    \n"
                                   "background: none;\n"
                                   "    background-color: #0bb2e8;\n"
                                   "    color: #d7e7ec;    \n"
                                   "    border-radius: 10px;\n"
                                   "    padding: 10px;\n"
                                   "}\n"
                                   "QPushButton:hover {color: #364a65;};")
        self.showBtn.setObjectName("showBtn")
        self.timeNameLabel = QtWidgets.QLabel(self.centralwidget)
        self.timeNameLabel.setGeometry(QtCore.QRect(710, 170, 111, 16))
        font = QtGui.QFont()
        font.setPointSize(13)
        font.setBold(True)
        font.setWeight(75)
        self.timeNameLabel.setFont(font)
        self.timeNameLabel.setStyleSheet("color: #fff;")
        self.timeNameLabel.setObjectName("label")
        self.eyesPositionLabel = QtWidgets.QLabel(self.centralwidget)
        self.eyesPositionLabel.setGeometry(QtCore.QRect(710, 210, 190, 16))
        font = QtGui.QFont()
        font.setPointSize(13)
        font.setBold(True)
        font.setWeight(75)
        self.eyesPositionLabel.setFont(font)
        self.eyesPositionLabel.setStyleSheet("color: #fff;")
        self.startBtn = QtWidgets.QPushButton(self.centralwidget)
        self.startBtn.setGeometry(QtCore.QRect(710, 432, 101, 31))
        font = QtGui.QFont()
        font.setPointSize(10)
        font.setBold(True)
        font.setWeight(75)
        self.startBtn.setFont(font)
        self.startBtn.setCursor(QtGui.QCursor(QtCore.Qt.PointingHandCursor))
        self.startBtn.setStyleSheet("QPushButton {    \n"
                                    "    background: none;\n"
                                    "    background-color: #00ff30;\n"
                                    "    color: #058a21;    \n"
                                    "    border-radius: 10px;\n"
                                    "}\n"
                                    "QPushButton:hover {color: #364a65;};")
        self.startBtn.setObjectName("startBtn")
        VideoStream_W.setCentralWidget(self.centralwidget)

        self.retranslateUi(VideoStream_W)
        QtCore.QMetaObject.connectSlotsByName(VideoStream_W)

        try:
            # start/stop timer
            # create a timer
            self.timer = QTimer()
            self.timer1 = QTimer()

            # set timer timeout callback function
            self.timer.timeout.connect(self.viewCam)
            # set control_bt callback clicked  function
            self.startBtn.clicked.connect(self.controlTimer)
            self.showBtn.clicked.connect(self.showContours)
            self.exitBtn.clicked.connect(self.exitFun)
            self.flag = False
            self.seconds_timer = 0
            self.timer1.timeout.connect(self.showTime)
            self.timer1.start(1000)
        except Exception:
            error_dialog = QtWidgets.QErrorMessage()
            error_dialog.showMessage('Oh no!')

    # функція відліку таймера
    def showTime(self):
        if self.flag:
            timevar = datetime.fromtimestamp(self.seconds_timer)
            finaltime = timevar - timedelta(hours=2)
            self.timerLabel.setText(finaltime.strftime("%H:%M:%S"))

            self.seconds_timer += 1

    def retranslateUi(self, VideoStream):
        _translate = QtCore.QCoreApplication.translate
        VideoStream.setWindowTitle(_translate("VideoStream", "DriverCare"))
        VideoStream.setWindowIcon(QIcon('images/icon.png'))
        self.exitBtn.setText(_translate("VideoStream", "Вихід"))
        self.helloLabel.setText(_translate("VideoStream", "Вітаємо водій!"))
        self.timerLabel.setText(_translate("VideoStream", "00:00:00"))
        self.showBtn.setText(_translate("VideoStream", "Відобразити контури"))
        self.timeNameLabel.setText(_translate("VideoStream", "Час поїздки:"))
        self.eyesPositionLabel.setText(_translate("VideoStream", "Кількість позіхань: 0"))
        self.startBtn.setText(_translate("VideoStream", "Розпочати"))

    def viewCam(self):
        min_possible_eyes = 0.20  # граничне допустиме значення відношення сторін очей, якщо менше 0.20 - закриті
        eyes_time = 50
        max_possible_mouth = 0.79  # граничне значення закритості рота

        # ініціалізація фрейму для відопотоку
        ret, image = self.cap.read()

        # конвертація зображення в RGB формат (кольоровий)
        image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
        height, width, channel = image.shape
        step = channel * width

        gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

        # виявлення облич
        rects = detector(gray, 0)

        for rect in rects:
            # визначення точок на обличчі
            shape = predictor(gray, rect)
            shape = face_utils.shape_to_np(shape)

            # точки на обличчі для розпізнавання повороту голови 0, 16, 33
            head_points = predictor(gray, rect)

            left_head_point = head_points.part(0).x
            right_head_point = head_points.part(16).x
            center_head_point = head_points.part(33).x

            # перевірка попороту голови
            if head_point_calc(left_head_point, right_head_point, center_head_point):
                self.COUNTER_HEAD_DIR_TIME += 1
                if self.COUNTER_HEAD_DIR_TIME >= 70:
                    head_thread = Thread(target=play_audio("audio/alarm_head.wav"))
                    head_thread.daemon = True
                    head_thread.start()
                    self.COUNTER_HEAD_DIR_TIME = 0
            else:
                self.COUNTER_HEAD_DIR_TIME = 0

            # масиви, що містять координати точок очей
            leftEye = shape[lStart:lEnd]
            rightEye = shape[rStart:rEnd]

            # обчислення відношення сторін кожного ока
            leftEAR = earFun(leftEye)
            rightEAR = earFun(rightEye)

            # середнє відношення сторін очей
            ear = (leftEAR + rightEAR) / 2.0

            # масив, що містить координати точок рота
            mouth = shape[mStart:mEnd]

            # обчислення відношення сторін рота
            mouthMAR = marFun(mouth)

            # малювання контурів очей так рота
            leftEyeHull = cv2.convexHull(leftEye)
            rightEyeHull = cv2.convexHull(rightEye)
            mouthHull = cv2.convexHull(mouth)

            if self.checkContour:
                cv2.drawContours(image, [leftEyeHull], -1, (0, 255, 0), 1)
                cv2.drawContours(image, [rightEyeHull], -1, (0, 255, 0), 1)

                cv2.drawContours(image, [mouthHull], -1, (0, 255, 0), 1)

                cv2.circle(image, (head_points.part(0).x, head_points.part(0).y), 3, (255, 0, 0), -1)
                cv2.circle(image, (head_points.part(16).x, head_points.part(16).y), 3, (255, 0, 0), -1)
                cv2.circle(image, (head_points.part(33).x, head_points.part(33).y), 3, (255, 0, 0), -1)

            self.eyesPositionLabel.setText("Кількість позіхань: {}".format(self.COUNTER_MOUTH_TIMES))

            # перевірка відкритості рота
            if mouthMAR > max_possible_mouth:
                ear = 21  # щоб не спрацьовувала сигналізація для очей
                self.COUNTER_MOUTH_TIME += 1
                if self.COUNTER_MOUTH_TIME == 30:
                    self.COUNTER_MOUTH_TIMES += 1
                    if self.COUNTER_MOUTH_TIMES >= 5:
                        mouth_thread = Thread(target=play_audio("audio/mouth.wav"))
                        mouth_thread.daemon = True
                        mouth_thread.start()
                        self.seconds_timer += 6
                        self.COUNTER_MOUTH_TIMES = 0
            else:
                self.COUNTER_MOUTH_TIME = 0

            # перевірка чи ear менше встановленого значення min_possible_eyes
            if ear < min_possible_eyes:
                self.COUNTER_EYES += 1

                # якщо очі закриті достатньо часу, то лунає сигналізація
                if self.COUNTER_EYES >= eyes_time:
                    if not self.ALARM_ON:
                        # запускається поток для програвання аудіозапису
                        eye_thread = Thread(target=play_audio("audio/alarm.wav"))
                        eye_thread.daemon = True
                        eye_thread.start()
            else:
                self.COUNTER_EYES = 0
                self.ALARM_ON = False

        qImg = QImage(image.data, width, height, step, QImage.Format_RGB888)

        self.videoLabel.setPixmap(QPixmap.fromImage(qImg))

    def showContours(self):
        if self.checkContour:
            self.showBtn.setText('Відобразити контури')
            self.checkContour = False
        else:
            self.showBtn.setText('Сховати контури')
            self.checkContour = True

    def exitFun(self):
        self.timer.stop()
        if self.startBtn.text() != "Розпочати":
            self.cap.release()

        self.window.show()
        self.VideoM.close()

    def controlTimer(self):
        if not self.timer.isActive():
            self.timer.start()
            if self.startBtn.text() == "Розпочати":
                self.cap = cv2.VideoCapture(0)

            self.startBtn.setText("Стоп")
            self.flag = True
        else:
            self.timer.stop()

            self.startBtn.setText("Старт")
            self.flag = False
