# Import libraies
import cv2 # openvc-python
from descriptors import haralick_with_mean, bitdesc, glcm

path = 'test.png'
def main():
    # Read/load image
    img_gray = cv2.imread(path, 0)
    print(img_gray.shape)    
    print('Haralick features: ')
    haralick_feat = haralick_with_mean(img_gray)
    print(haralick_feat)    
    print('Bitdesc features: ')
    bitdesc_feat = bitdesc(img_gray)
    print(bitdesc_feat)
    print('GLCM features: ')
    glcm_feat = glcm(img_gray)
    print(glcm_feat)
    
if __name__ =="__main__":
    main()
    
    