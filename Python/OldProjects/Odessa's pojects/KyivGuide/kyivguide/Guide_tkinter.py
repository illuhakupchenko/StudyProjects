import tkinter as tk
from io import BytesIO
import requests
from PIL import ImageTk, Image
from pymysql import connect
from cefpython3 import cefpython as cef
import ctypes
import platform
import logging as _logging


# Fix for PyCharm hints warnings

WindowUtils = cef.WindowUtils()

# Platforms
WINDOWS = (platform.system() == "Windows")
LINUX = (platform.system() == "Linux")
MAC = (platform.system() == "Darwin")

# Globals
logger = _logging.getLogger("tkinter_.py")


myDB = connect(host="localhost", user="root", passwd="1111", database="kyivcityguide", port=3306)

myCursor = myDB.cursor()

arrDB_name = []
arrDB_description = []
arrDB_image = []
arrDB_maproute = []

arrDES_name = []
arrDES_description = []
arrDES_image = []


def executeArr(path):
    myCursor.execute(path)
    tempArr = []
    for ii in myCursor:
        tempArr.append(str(ii)[2:-3])  # slice syntax of DB
    return tempArr


def execDes(path):
    tempArr = []
    for ii in range(0, len(arrDB_name)):
        tempArr.append(executeArr(path + str(ii + 1)))
    return tempArr


class Main(tk.Frame):
    def __init__(self, root1):
        super().__init__(root1)
        self.init_main()

    def init_main(self):
        mainlabel = tk.Label(text="Вітаємо Вас у місті Київ!", font=("Ubuntu", 14, "bold"), fg='green')
        mainlabel.configure(background="#03C7DE")
        mainlabel.place(relx=.5, rely=0.85, anchor="c", bordermode=tk.OUTSIDE)  # sw/se

        load = Image.open("kyiv.jpg")

        render = ImageTk.PhotoImage(load)
        img = tk.Label(image=render, width=880, height=450)
        img.image = render
        img.place(x=8, y=8)

        chooseroute = tk.Button(root, text="Обрати маршрут", command=self.open_ch_route, font=("Poppins", 15, "bold"),
                                fg='red', bg='pink')
        chooseroute.place(x=355, y=535)

    def open_ch_route(self):
        Choose_Route(0)
        root.withdraw()  # hide main window on opening another


class Choose_Route(tk.Toplevel):
    def __init__(self, d):
        super().__init__(root)
        self.init_choose_route(d)
        self.update()
        self.protocol("WM_DELETE_WINDOW", self.on_closing)  # method to show main window

    def on_closing(self):
        self.destroy()
        root.update()
        root.deiconify()

    k = 0  # var counter for slides switching

    def init_choose_route(self, d):
        self.title("Обрати маршрут")
        self.configure(background="#03C7DE")
        self.k = d  # d - var which init Choose_Route on current slide

        # loading images with url

        # loading images with url

        img = tk.Label(self)
        set_img(arrDB_image[self.k], 300, 500, 400, img)

        img.pack(side="bottom", fill="both", expand="yes")
        img.place(x=10, y=10)

        name = tk.Label(self)
        description = tk.Label(self)
        set_labels(self.k, 0, name, description, "Routes")
        description.place(x=30, y=380)
        name.place(x=560, y=30)

        load = Image.open("St.Mkhil.png")
        render = ImageTk.PhotoImage(load)
        imgEmblema = tk.Label(self, image=render, width=200, height=280, bg="#03C7DE")
        imgEmblema.image = render
        imgEmblema.place(x=600, y=130)

        nextBtn = tk.Button(self, text=">", command=lambda: self.changeRoute(0, img, name, description),
                            font=("Poppins", 15), fg='green', bg='yellow')
        nextBtn.place(x=805, y=535)
        prevBtn = tk.Button(self, text="<", command=lambda: self.changeRoute(1, img, name, description),
                            font=("Poppins", 15), fg='green', bg='yellow')
        prevBtn.place(x=700, y=535)

        mapBtn = tk.Button(self, text="Переглянути на карті", command=lambda: self.openMap(self.k))
        mapBtn.place(x=700, y=470)

        sightBtn = tk.Button(self, text="Переглянути пам'ятки", command=lambda: self.detInfo(arrDB_name[self.k],
                                                                                             self.k))
        sightBtn.place(x=700, y=500)

        set_center(self, 870, 600)

        self.iconbitmap('guide.ico')
        self.resizable(False, False)

        self.focus_set()

    # method to switch routes
    def changeRoute(self, d, img, name, des):
        #  if d = 0 - next, else - prev
        if d == 0:
            self.k += 1
        elif d == 1:
            self.k -= 1

        if self.k > len(arrDB_name) - 1:
            self.k = 0
        if self.k < 0:
            self.k = len(arrDB_name) - 1

        set_img(arrDB_image[self.k], 300, 500, 400, img)
        set_labels(self.k, 0, name, des, "Routes")  # zero for sightseens class!

    def detInfo(self, title, k):
        chooseR = self
        Sightseens(title, k, chooseR)
        self.withdraw()  # hide main window on opening another

    def openMap(self, k):
        chooseR = self
        self.destroy()
        goMap(arrDB_maproute[k], k, chooseR)


class Sightseens(tk.Toplevel):
    def __init__(self, title, k, chooseR):
        super().__init__(root)
        self.init_det_info(title, k)
        self.protocol("WM_DELETE_WINDOW", lambda: self.on_closing(chooseR, k))  # method to show main window

    def on_closing(self, chooseR, k):
        self.destroy()
        chooseR.destroy()
        Choose_Route(k)

    def init_det_info(self, title, k):
        self.title(title + " (пам'ятки)")
        self.configure(background="#03C7DE")

        img = tk.Label(self)
        set_img(arrDES_image[k][self.a], 280, 450, 280, img)
        img.pack(side="bottom", fill="both", expand="yes")
        img.place(x=8, y=5)

        name = tk.Label(self)
        description = tk.Label(self)
        set_labels(self.a, k, name, description, "Sights")
        name.place(x=10, y=320)
        description.place(x=10, y=365)

        nextBtn = tk.Button(self, text=">", command=lambda: self.changeSight(0, k, img, name, description),
                            font=("Poppins", 15), fg='green', bg='yellow')
        nextBtn.place(x=400, y=565, width=50, height=30)
        prevBtn = tk.Button(self, text="<", command=lambda: self.changeSight(1, k, img, name, description),
                            font=("Poppins", 15), fg='green', bg='yellow')
        prevBtn.place(x=350, y=565, width=50, height=30)

        set_center(self, 470, 600)

        self.iconbitmap('guide.ico')
        self.resizable(False, False)

        self.focus_set()

    a = 0

    def changeSight(self, d, k, img, name, description):
        #  if d = 0 - next, else - prev
        if d == 0:
            self.a += 1
        elif d == 1:
            self.a -= 1

        if self.a > len(arrDES_name) - 1:
            self.a = 0
        if self.a < 0:
            self.a = len(arrDES_name) - 1

        set_img(arrDES_image[k][self.a], 280, 450, 280, img)
        set_labels(self.a, k, name, description, "Sights")


# method which displays images by url adress

def set_img(url, height, width, height2, imageUrl):
    #  loading images using URL
    img_url = url
    response = requests.get(img_url)
    img_data = response.content
    img12 = Image.open(BytesIO(img_data))
    size = width, height2
    img12.thumbnail(size)
    img = ImageTk.PhotoImage(img12)
    imageUrl.configure(image=img, width=width, height=height, bg="#03C7DE")
    img.image = img


# method to display labels

def set_labels(txt, k, name, description, window):
    if window == "Routes":
        name.configure(background="#03C7DE", text=arrDB_name[txt], font=("Ubuntu", 18, "bold"), fg='green',
                       wraplength=300)

        description.configure(background="#03C7DE", text=arrDB_description[txt], font=("Ubuntu", 12, "bold"), fg='red',
                              wraplength=500, justify="left", anchor='n')
    if window == "Sights":
        name.configure(background="#03C7DE", text=arrDES_name[k][txt], font=("Ubuntu", 13, "bold"), fg='green',
                       wraplength=300)
        description.configure(background="#03C7DE", text=arrDES_description[k][txt], font=("Ubuntu", 10, "bold"),
                              fg='red', wraplength=450, justify="left", anchor='n')


# method which displays window in the center of the screen

def set_center(self, width, height):
    #  center center window position

    width1 = width
    frm_width1 = self.winfo_rootx() - self.winfo_x()
    win_width1 = width1 + 2 * frm_width1
    height1 = height
    titlebar_height1 = self.winfo_rooty() - self.winfo_y()
    win_height1 = height1 + titlebar_height1 + frm_width1
    x1 = self.winfo_screenwidth() // 2 - win_width1 // 2
    y1 = self.winfo_screenheight() // 2 - win_height1 // 2
    self.geometry('{}x{}+{}+{}'.format(width1, height1, x1, y1))

    #  center center window position


'''
*************************
*************************
*************************
DISPLAYING GOOGLE MAPS
*************************
*************************
*************************
'''


class MapGoog(tk.Frame):

    def __init__(self, root1, url, k, chooseR):
        self.browser_frame = None
        self.navigation_bar = None

        # Root
        set_center(root1, 870, 600)
        root1.title("Карта")
        root1.iconbitmap('guide.ico')
        root1.resizable(False, False)
        root1.protocol("WM_DELETE_WINDOW", lambda: self.on_closing(chooseR, k))  # method to show main window

        tk.Grid.rowconfigure(root1, 0, weight=1)
        tk.Grid.columnconfigure(root1, 0, weight=1)

        # MainFrame
        tk.Frame.__init__(self, root1)
        # BrowserFrame
        self.browser_frame = BrowserFrame(url, self, self.navigation_bar)
        self.browser_frame.grid(row=1, column=0,
                                sticky=(tk.N + tk.S + tk.E + tk.W))
        tk.Grid.rowconfigure(self, 1, weight=1)
        tk.Grid.columnconfigure(self, 0, weight=1)

        # Pack MainFrame
        self.pack(fill=tk.BOTH, expand=tk.YES)

    def on_closing(self, chooseR, k):
        self.on_close()
        chooseR.destroy()
        Choose_Route(k)

    def on_root_configure(self, _):
        logger.debug("MainFrame.on_root_configure")
        if self.browser_frame:
            self.browser_frame.on_root_configure()

    def on_configure(self, event):
        logger.debug("MainFrame.on_configure")
        if self.browser_frame:
            width = event.width
            height = event.height
            if self.navigation_bar:
                height = height - self.navigation_bar.winfo_height()
            self.browser_frame.on_mainframe_configure(width, height)

    def on_close(self):
        self.master.destroy()

    def get_browser(self):
        if self.browser_frame:
            return self.browser_frame.browser
        return None

    def get_browser_frame(self):
        if self.browser_frame:
            return self.browser_frame
        return None


class BrowserFrame(tk.Frame):
    link = ''

    def __init__(self, url, master, navigation_bar=None):
        self.navigation_bar = navigation_bar
        self.closing = False
        self.browser = None
        tk.Frame.__init__(self, master)
        self.bind("<FocusIn>", self.on_focus_in)
        self.bind("<FocusOut>", self.on_focus_out)
        self.bind("<Configure>", self.on_configure)
        self.focus_set()
        self.link = url

    def embed_browser(self):
        window_info = cef.WindowInfo()
        rect = [0, 0, self.winfo_width(), self.winfo_height()]
        window_info.SetAsChild(self.get_window_handle(), rect)
        self.browser = cef.CreateBrowserSync(window_info, url=self.link)
        self.message_loop_work()

    def get_window_handle(self):
        if self.winfo_id() > 0:
            return self.winfo_id()
        elif MAC:
            import NSApp
            import objc
            return objc.pyobjc_id(NSApp.windows()[-1].contentView())
        else:
            raise Exception("Couldn't obtain window handle")

    def message_loop_work(self):
        cef.MessageLoopWork()
        self.after(10, self.message_loop_work)

    def on_configure(self, _):
        if not self.browser:
            self.embed_browser()

    def on_root_configure(self):
        # Root <Configure> event will be called when top window is moved
        if self.browser:
            self.browser.NotifyMoveOrResizeStarted()

    def on_mainframe_configure(self, width, height):
        if self.browser:
            if WINDOWS:
                ctypes.windll.user32.SetWindowPos(
                    self.browser.GetWindowHandle(), 0, 0, 0, width, height, 0x0002)
            elif LINUX:
                self.browser.SetBounds(0, 0, width, height)
            self.browser.NotifyMoveOrResizeStarted()

    def on_focus_in(self, _):
        logger.debug("BrowserFrame.on_focus_in")
        if self.browser:
            self.browser.SetFocus(True)

    def on_focus_out(self, _):
        logger.debug("BrowserFrame.on_focus_out")
        if self.browser:
            self.browser.SetFocus(False)


def goMap(link, k, chooseR):
    try:
        root1 = tk.Tk()
        app1 = MapGoog(root1, link, k, chooseR)
        # Tk must be initialized before CEF otherwise fatal error (Issue #306)
        cef.Initialize()

        app1.mainloop()
        cef.Shutdown()
    except:
        pass

'''
*************************
*************************
*************************
DISPLAYING GOOGLE MAPS
*************************
*************************
*************************
'''


if __name__ == "__main__":
    arrDB_name = executeArr("select name from routes")
    arrDB_description = executeArr("select description from routes")
    arrDB_image = executeArr("select image from routes")
    arrDB_maproute = executeArr("select maproute from routes")
    arrDES_name = execDes("select name from sightseens where idcon=")
    arrDES_description = execDes("select description from sightseens where idcon=")
    arrDES_image = execDes("select image from sightseens where idcon=")

    root = tk.Tk()
    app = Main(root)
    app.pack()
    root.title("Мобільний гід по Києву")
    root.configure(background="#03C7DE")

    set_center(root, 900, 600)

    root.iconbitmap('guide.ico')
    root.resizable(False, False)
    root.mainloop()
