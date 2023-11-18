# Import libraries
import numpy as np
import cv2
import face_recognition
from os import listdir
import os

# Variables globales
path = 'images/'
images = [] # List of images from the folder
classNames = [] # List of images` name
myList = listdir(path)
#print(myList)

# Read images from the folder
for cl in myList:
    #print(f'{path}{cl}')
    curImg = cv2.imread(f'{path}{cl}')
    # Add image to images list
    images.append(curImg)
    classNames.append(os.path.splitext(cl)[0])
#print(classNames)
print('Computing encodings ...')
# Find encodings
def findEncoding(myImgs):
    encodeList = []
    for myImg in myImgs:
        img = cv2.cvtColor(myImg, cv2.COLOR_BGR2RGB)
        encode = face_recognition.face_encodings(img)[0]
        print(encode)
        encodeList.append(encode)
    return encodeList
# Generate featureres from images faces
encodeListFinal = findEncoding(images)
print('Images encoded successfully!')
# Read image from Webcam
cap = cv2.VideoCapture(0)
while True:
    success, img = cap.read()
    if success:
        imgS = cv2.resize(img, (0,0), None, 0.25, 0.25) # Resize image
        imgS = cv2.cvtColor(imgS, cv2.COLOR_BGR2RGB)
        # Find face locations of the webcam
        facesCurFrame = face_recognition.face_locations(imgS)
        # Ecode faces
        encodesCurFrame = face_recognition.face_encodings(imgS, facesCurFrame)
        for encodeFace, faceLoc in zip(encodesCurFrame, facesCurFrame):
            matches = face_recognition.compare_faces(encodeListFinal, encodeFace)
            faceDis = face_recognition.face_distance(encodeListFinal, encodeFace)
            matchIndex = np.argmin(faceDis)
            if matches[matchIndex]==True:
                name = classNames[matchIndex].upper()
                #print(classNames, name, matches, faceDis)
                y1, x2, y2, x1 = faceLoc
                y1, x2, y2, x1 = y1*4, x2*4, y2*4, x1*4
                cv2.rectangle(img,(x1, y1), (x2, y2), (0, 255, 0), 2)
                cv2.rectangle(img, (x1, y2-35), (x2, y2), (0, 255, 0), cv2.FILLED)
                cv2.putText(img, name, (x1+10, y2-6), cv2.FONT_HERSHEY_COMPLEX, 1, (255, 255, 255),2)
        cv2.imshow('Detection', img)
        cv2.waitKey(1)
    else:
        break
        
        