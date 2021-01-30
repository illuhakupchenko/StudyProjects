import socket
from pymysql import connect

myDB = connect(host="localhost", user="root", passwd="1111", database="kyivcityguide", port=3306)
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

sock = socket.socket()
sock.connect(('93.72.7.182', 9999))

obj = {
    'a': arrDB_name,
    'b': [2, 3],
    'c': {
        'c1': 'abc',
    }
}

print('Send:', obj)

import pickle

data = pickle.dumps(obj)

sock.sendall(data)

print('Close')
sock.close()
