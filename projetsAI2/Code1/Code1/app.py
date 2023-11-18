# Import libraies
import cv2 # openvc-python

path = 'test.png'
def main():
    # Read/load image
    img_bgr = cv2.imread(path)
    img_rgb = cv2.cvtColor(img_bgr, cv2.COLOR_BGR2RGB)
    img_gray = cv2.cvtColor(img_bgr, cv2.COLOR_BGR2GRAY)
    cv2.imshow('BGR', img_bgr)
    cv2.imshow('RGB', img_rgb)
    cv2.imshow('Gray', img_gray)
    cv2.waitKey(0)
    print('Images deplayed!')
    
if __name__ =="__main__":
    main()
    
    
    