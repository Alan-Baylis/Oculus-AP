import maestro
import serial
import sys
from serial.tools.list_ports import comports
import time
import socket

def findPorts():
    for n, (port, desc, hwid) in enumerate(sorted(comports()), 1):
        if(hwid == "USB VID:PID=1FFB:008B"):
            sys.stderr.write('Servos controller found on {}.\n'.format(port))
            return port

    sys.stderr.write('Servos controller not found.\n')
    exit(1)

def main(argv):
    hostIP = "127.0.0.1"
    hostPort = 9874

    controller = maestro.Controller(ttyStr=findPorts())
    controller.setSpeed(0, 0)
    controller.setSpeed(0, 0)

    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    sock.bind((hostIP, hostPort))
    sock.settimeout(30)

    while True:
        try:
            data, addr = sock.recvfrom(1024)
        except:
            break
        serverRead = data.strip('()').split(', ')

        if int(serverRead[0]) == -1:
            break;

        controller.setTarget(int(serverRead[0]), int(serverRead[1]))

    sock.close()
    controller.close()

    return

main(sys.argv)
