# -*- coding: utf-8 -*-

# http://qaru.site/questions/12589122/kivy-python-passing-parameters-to-fuction-with-button-click
# https://ru.stackoverflow.com/questions/960338/Очистка-экрана-python-kivy
# https://issue.life/questions/55213183
import webbrowser
from functools import partial
from kivy.app import App
from kivy.core.window import Window
from kivy.lang import Builder
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.button import Button
from kivy.uix.floatlayout import FloatLayout
from kivy.uix.gridlayout import GridLayout
from kivy.uix.image import AsyncImage, Image
from kivy.uix.label import Label
from kivy.uix.screenmanager import ScreenManager, Screen
from pymysql import connect

string = """
<MainPage>:
    FloatLayout:
        id: mainPage
        Image:
            source: "kyiv.jpg"
            size: 870, 450 
            size_hint: None, None
            pos: 0, 120
        Label:
            text: 'Вітаємо Вас в місті Київ!' 
            pos: 0, -220
        Button:
            text: 'Обрати маршрут' 
            size: 150, 40 
            size_hint: None, None
            pos: 360, 20
            on_press: 
                root.manager.current = 'routes'
                root.manager.transition.direction='up'

<Routes>:
    BoxLayout:
        ScrollView:
            GridLayout:
                id: routesLayout
                size: root.size
                size_hint: None, None
                pos: 200, 0
                size_hint_y: None
                cols: 2
                row_default_height: root.height*0.55
                height: self.minimum_height    

            # set color for Grid!
                canvas:
                    Color:
                        rgba: .3, .2, .5, .4
                    Rectangle:
                        pos: self.pos
                        size: self.size
            # set color for Grid!
                spacing: 10, 50
                
        BoxLayout
            id: mainLayout
            size_hint: None, None
            size: 0, 0
        
"""

# Window.clearcolor = (.1, .1, .3, .2)
Window.clearcolor = (0.55, 0.3, 0.7, 0.4)
k = 0
try:
    myDB = connect(host="localhost", user="root", passwd="1111", database="kyivcityguide", autocommit=True, port=3306)

    myCursor = myDB.cursor()


    def executeArr(path, var):
        myCursor.execute(path)
        tempArr = []

        for ii in myCursor:
            if var == 'str':
                tempArr.append(str(ii)[2:-3])  # slice syntax of DB
            elif var == 'dig':
                tempArr.append(str(ii)[1:-2])  # slice syntax of DB

        return tempArr


    def execDes(path):
        tempArr = []
        for ii in range(0, len(arrDB_name)):
            tempArr.append(executeArr((path + str(ii + 1)), 'str'))
        return tempArr


    arrDB_name = executeArr("select name from routes", 'str')
    arrDB_description = executeArr("select description from routes", 'str')
    arrDB_image = executeArr("select image from routes", 'str')
    arrDB_maproute = executeArr("select maproute from routes", 'str')
    arrDB_like = executeArr("select likevar from routes", 'dig')
    arrDB_dislike = executeArr("select dislike from routes", 'dig')
    arrDES_name = execDes("select name from sightseens where idcon=", )
    arrDES_description = execDes("select description from sightseens where idcon=")
    arrDES_image = execDes("select image from sightseens where idcon=")

except Exception:
    arrDB_name = ['Помилка!']
    arrDB_image = ['https://www.yelloway.co.uk/wp-content/uploads/2019/05/Oops.png']
    arrDB_description = ['База даних не працює']
    k = 1
Builder.load_string(string)


# Declare both screens
class MainPage(Screen):
    def __init__(self, **kwargs):
        super().__init__(**kwargs)
        if k == 1:
            self.ids.mainPage.clear_widgets()
            self.ids.mainPage.add_widget(Image(source='Oops.png'))
            self.ids.mainPage.add_widget(Label(text='База даних не працює!(\nСпробуйте пізніше!', font_size='25sp',
                                               pos=(130, 20), size_hint=(None, None), size=(200, 100), text_size=(400, 100)))
        else:
            pass

class Routes(Screen):
    def __init__(self, **kwargs):
        super(Routes, self).__init__(**kwargs)
        Window.bind(on_request_close=self.exit_check)

        self.initRoutes(False, event=1)

    exitVar = True

    def exit_check(self, *args):
        if not self.exitVar:
            self.initRoutes(True, *args)
            return True
        else:
            return False

    def initRoutes(self, sights, event):  # parameter sights to correct work of layout on first init
        self.exitVar = True
        self.ids.routesLayout.clear_widgets()
        if sights:
            self.ids.mainLayout.clear_widgets()
        for i in range(0, len(arrDB_name)):
            b = BoxLayout(padding=(10, 0, 10, 0))
            b.add_widget(AsyncImage(source=arrDB_image[i], size_hint=(None, None), size=(400, 300)))
            self.ids.routesLayout.add_widget(b)
            g = GridLayout(padding=(0, 20, 0, 0), spacing=(0, 20), cols=1, rows=3)
            name = Label(text_size=(400, 30), halign='left', text=arrDB_name[i], size_hint=(None, None), size=(400, 30))
            g.add_widget(name)
            des = Label(text_size=(400, 170), halign='left', valign='top', size_hint=(None, None),
                        size=(400, 170), text=arrDB_description[i])
            g.add_widget(des)
            g1 = GridLayout(cols=3, padding=(0, 0, 30, 20))
            g2 = GridLayout(rows=2, cols=2)

            likeBtn = Button(background_normal='like.png', size_hint=(None, None), size=(40, 40), on_press=partial(
                self.like_dis, 'likevar', i))
            # likeImg = Image(source='like.png', size_hint=(None, None), size=(40, 40), on_press=partial(
            # self.like_dis, 'likevar', i))
            coLike = Label(text=arrDB_like[i])

            # dislikeImg = Image(source='dislike.png', size_hint=(None, None), size=(40, 40), on_touch_down=partial(
            # self.like_dis, 'dislike', i))
            dislikeBtn = Button(background_normal='dislike.png', size_hint=(None, None), size=(40, 40),
                                on_press=partial(
                                    self.like_dis, 'dislike', i))

            coDis = Label(text=arrDB_dislike[i])
            g2.add_widget(likeBtn)
            g2.add_widget(dislikeBtn)
            g2.add_widget(coLike)
            g2.add_widget(coDis)

            g1.add_widget(g2)

            b = Button(text="Детальніше про маршрут", size_hint=(None, None), size=(200, 30), on_press=partial(
                self.initSights, i, 0))
            g1.add_widget(b)
            g.add_widget(g1)
            self.ids.routesLayout.add_widget(g)

    keyLike = []  # arrays for system of like/dislike
    keyDis = []
    for i in range(0, len(arrDB_image)):
        keyLike.append(False)
        keyDis.append(False)

    def like_dis(self, action, idRoute, event):
        if action == 'likevar' and self.keyDis[idRoute]:
            myCursor.execute(
                "update routes set " + action + "=" + str(int(arrDB_like[idRoute]) + 1) + " where id=" + str(idRoute
                                                                                                             + 1))
            arrDB_like[idRoute] = str(int(arrDB_like[idRoute]) + 1)
            self.keyLike[idRoute] = True
            myCursor.execute(
                "update routes set dislike=" + str(int(arrDB_dislike[idRoute]) - 1) + " where id=" + str(idRoute
                                                                                                                + 1))
            arrDB_dislike[idRoute] = str(int(arrDB_dislike[idRoute]) - 1)
            self.keyDis[idRoute] = False
        elif action == 'likevar' and not self.keyLike[idRoute] and not self.keyDis[idRoute]:
            myCursor.execute(
                "update routes set " + action + "=" + str(int(arrDB_like[idRoute]) + 1) + " where id=" + str(idRoute
                                                                                                             + 1))
            arrDB_like[idRoute] = str(int(arrDB_like[idRoute]) + 1)
            self.keyLike[idRoute] = True

        elif action == 'likevar' and self.keyLike[idRoute]:
            myCursor.execute(
                "update routes set " + action + "=" + str(int(arrDB_like[idRoute]) - 1) + " where id=" + str(idRoute
                                                                                                             + 1))
            arrDB_like[idRoute] = str(int(arrDB_like[idRoute]) - 1)
            self.keyLike[idRoute] = False
        #  *************
        elif action == 'dislike' and self.keyLike[idRoute]:
            myCursor.execute(
                "update routes set " + action + "=" + str(int(arrDB_dislike[idRoute]) + 1) + " where id=" + str(idRoute
                                                                                                                + 1))
            arrDB_dislike[idRoute] = str(int(arrDB_dislike[idRoute]) + 1)
            self.keyDis[idRoute] = True
            myCursor.execute(
                "update routes set likevar=" + str(int(arrDB_like[idRoute]) - 1) + " where id=" + str(idRoute
                                                                                                             + 1))
            arrDB_like[idRoute] = str(int(arrDB_like[idRoute]) - 1)
            self.keyLike[idRoute] = False
        elif action == 'dislike' and not self.keyDis[idRoute] and not self.keyLike[idRoute]:
            myCursor.execute(
                "update routes set " + action + "=" + str(int(arrDB_dislike[idRoute]) + 1) + " where id=" + str(idRoute
                                                                                                                + 1))
            arrDB_dislike[idRoute] = str(int(arrDB_dislike[idRoute]) + 1)
            self.keyDis[idRoute] = True

        elif action == 'dislike' and self.keyDis[idRoute]:
            myCursor.execute(
                "update routes set " + action + "=" + str(int(arrDB_dislike[idRoute]) - 1) + " where id=" + str(idRoute
                                                                                                                + 1))
            arrDB_dislike[idRoute] = str(int(arrDB_dislike[idRoute]) - 1)
            self.keyDis[idRoute] = False
        myDB.commit()
        self.initRoutes(True, 1)

    def initSights(self, k, currImg, event):
        self.exitVar = False
        self.ids.routesLayout.clear_widgets()
        self.ids.mainLayout.clear_widgets()

        f = FloatLayout()

        nameRoute = Label(text="Маршрут: " + arrDB_name[k], font_size='25sp', pos=(30, 550), halign='left',
                          valign='top', size_hint=(None, None), size=(700, 30), text_size=(700, 30))
        f.add_widget(nameRoute)

        nameSight = Label(text="Пам'ятка: " + arrDES_name[k][currImg], font_size='20sp', pos=(30, 450), halign='left',
                          valign='top', size_hint=(None, None), size=(400, 50), text_size=(400, 50))
        f.add_widget(nameSight)

        imageKyiv = Image(source='St.Mkhil.png', pos=(750, 410), size_hint=(None, None), size=(100, 200))
        f.add_widget(imageKyiv)

        imageSight = AsyncImage(source=arrDES_image[k][currImg], pos=(30, 70), size_hint=(None, None), size=(450, 400))
        f.add_widget(imageSight)

        describeLbl = Label(text=arrDES_description[k][currImg], halign='left', valign='top', size_hint=(None, None),
                            size=(300, 500), text_size=(300, 500), pos=(520, -80))
        f.add_widget(describeLbl)

        prevBtn = Button(text='<', font_size='45sp', size_hint=(None, None), size=(85, 55), pos=(30, 10),
                         on_release=partial(self.nextSight, k, currImg - 1))
        f.add_widget(prevBtn)

        mapBtn = Button(text='Маршрут на карті', size_hint=(None, None), size=(155, 35), pos=(177, 20),
                        on_press=lambda *args: webbrowser.open(arrDB_maproute[k]))
        f.add_widget(mapBtn)

        nextBtn = Button(text='>', font_size='45sp', size_hint=(None, None), size=(85, 55), pos=(395, 10),
                         on_release=partial(self.nextSight, k, currImg + 1))
        f.add_widget(nextBtn)

        self.ids.mainLayout.add_widget(f)

    def nextSight(self, k, curr, event):
        self.ids.mainLayout.clear_widgets()
        if curr < 0:
            curr = len(arrDES_name) - 1
        elif curr > len(arrDES_name) - 1:
            curr = 0

        self.initSights(k, curr, event=1)


# Create the screen manager
sm = ScreenManager()
sm.add_widget(MainPage(name='mainpage'))
if k == 0:
    sm.add_widget(Routes(name='routes'))


class TestApp(App):

    def build(self):
        self.title = "Мобільний гід по Києву"
        self.icon = "guide.ico"
        return sm


if __name__ == '__main__':
    TestApp().run()
