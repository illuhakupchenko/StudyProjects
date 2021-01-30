import socket
import threading
import time
import pickle


key = 8194

shutdown = False
join = False


def receving(name, sock):
    while not shutdown:
        try:
            while True:
                data = sock.recv(65507)
                goG(data)

        except:
            pass


host = socket.gethostbyname(socket.gethostname())

port = 0

server = ("93.72.7.182", 7777)

s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
s.bind((host, 1022))
s.setblocking(False)


rT = threading.Thread(target=receving, args=("RecvThread", s))
rT.start()

if join is False:
    s.sendto(("[user] => join chat ").encode("utf-8"), server)
    join = True
'''else:
    try:
        message = input()

        if message != "":
            s.sendto(("[" + alias + "] :: " + message).encode("utf-8"), server)

        time.sleep(0.2)
    except:
        s.sendto(("[" + alias + "] <= left chat ").encode("utf-8"), server)
        shutdown = True'''





def goG(dat):
    global obj
    obj = pickle.loads(dat)
    global arrDB_name
    global arrDB_description
    global arrDB_image
    global arrDB_maproute
    global arrDB_like
    global arrDB_like
    global arrDB_dislike
    global arrDES_name
    global arrDES_description
    global arrDES_image
    arrDB_name = obj.get('arrDB_name')
    arrDB_description = obj.get('arrDB_description')
    arrDB_image = obj.get('arrDB_image')
    arrDB_maproute = obj.get('arrDB_maproute')
    arrDB_like = obj.get('arrDB_like')
    arrDB_dislike = obj.get('arrDB_dislike')
    arrDES_name = obj.get('arrDES_name')
    arrDES_description = obj.get('arrDES_description')
    arrDES_image = obj.get('arrDES_image')

time.sleep(0.2)
shutdown = True

print('hello')
print(arrDB_name)
print(obj)

while True:
    pass