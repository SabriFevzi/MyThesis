#Code used to combine c sharp and python codes
import socket

def SendData(value):
    for i in range(0,1):
        host = "127.0.0.1"
        port = 3029
        s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        s.connect((host, port))
        s.sendall(bytes(str(value), encoding='utf-8'))
        data = s.recv(1024)
        s.close()
        s.release()

        return repr(data)

