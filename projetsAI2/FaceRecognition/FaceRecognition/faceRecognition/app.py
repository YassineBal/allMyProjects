import cv2, numpy as np, face_recognition
# Import signatures
signatures_original = np.load('Signatures.npy')
signatures = signatures_original[ : , 0:-1].astype('float')
names = signatures_original[ : , -1]
print(signatures)
# launch the webcam
cap = cv2.VideoCapture(0)
while True:
    success, img = cap.read()
    print('Capturing ...')
    if success:
        imgS = cv2.resize(img, (0,0),None, 0.25, 0.25)
        imgS = cv2.cvtColor(imgS, cv2.COLOR_BGR2RGB)
        # Find face locations from the webcam
        facesCurrent = face_recognition.face_locations(imgS)
        # Ecode face features
        encodesCurrent = face_recognition.face_encodings(imgS, facesCurrent)
        for encodeFace, faceLoc in zip(encodesCurrent, facesCurrent):
            matches = face_recognition.compare_faces(signatures, encodeFace)
            faceDis = face_recognition.face_distance(signatures, encodeFace)
            matchIndex = np.argmin(faceDis)
            if matches[matchIndex]:
                name = names[matchIndex].upper()
                # print(f'{name} identified!')
                y1, x2, y2, x1 = faceLoc
                y1, x2, y2, x1 = y1*4, x2*4, y2*4, x1*4
                cv2.rectangle(img, (x1, y1), (x2, y2), (0, 255, 0), 2)
                cv2.rectangle(img, (x1, y2-25), (x2, y2), (0, 255, 0), cv2.FILLED)
                cv2.putText(img, name, (x1+10, y2-6), cv2.FONT_HERSHEY_COMPLEX, 1, (255, 255, 255), 2)
                 
            else:
                name = 'Unknown'
                y1, x2, y2, x1 = faceLoc
                y1, x2, y2, x1 = y1*4, x2*4, y2*4, x1*4
                cv2.rectangle(img, (x1, y1), (x2, y2), (0, 255, 0), 2)
                cv2.rectangle(img, (x1, y2-25), (x2, y2), (0, 255, 0), cv2.FILLED)
                cv2.putText(img, name, (x1+10, y2-6), cv2.FONT_HERSHEY_COMPLEX, 1, (255, 255, 255), 2)
        cv2.imshow('Webcam', img)
        cv2.waitKey(1)
        