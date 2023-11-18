# Import libraries
import cv2
import pyautogui
import numpy as np
import time

yellow_lower = np.array([25, 100, 100])
yellow_upper = np.array([30, 255, 255])

red_lower = np.array([0, 100, 100])
red_upper = np.array([10, 205, 205])
# Set initial y position
previous_y = 0
# Instantiate camera
cap = cv2.VideoCapture(0)
while True:
    success, frame = cap.read()
    # Convert frame into HSV
    hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
    # Create mask for discriminate specific color
    mask = cv2.inRange(hsv, red_lower, red_upper)
    # Find contour
    contours, _ = cv2.findContours(mask, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    for c in contours:
        area = cv2.contourArea(c)
        if area >  59701:
            print(f'Area is: {area}')
            x, y, w, h = cv2.boundingRect(c)
            cv2.rectangle(frame, (x, y), (x+w, y+h), (75, 100, 138), 4)
            if y < previous_y:
                print(f'Vers le haut : {y, previous_y} - Area: {area}')
                pyautogui.scroll(50)
                #pyautogui.press('pageup')
                #pyautogui.hotkey('alt', 'left')
                #time.sleep(0.05)
            elif y > previous_y: 
                print(f'Vers le bas : {y, previous_y} - Area: {area} ')
                pyautogui.scroll(-50)
                #pyautogui.press('pagedown')
                #pyautogui.hotkey('alt', 'right')
                #time.sleep(0.05)
            else: continue
                
            previous_y = y    
    cv2.imshow('Object', frame)
    cv2.waitKey(1)
    
    