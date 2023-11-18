import os
import cv2
from os import listdir
from descriptors import haralick_with_mean, glcm, bitdesc

def read_files(path):
    '''
    Print all the files in a given path and
    its subfolders
    '''
    for root, directories, files in os.walk(path):
        for name in files:
            print(os.path.join(root, name), ':', directories)

def read_extract(path):
    '''
    Print all the files in a given path and
    its subfolders
    '''
    for root, directories, files in os.walk(path):
        for name in files:
            print(os.path.join(root, name))
            img = os.path.join(root, name)
            img_gray = cv2.imread(img, 0)
            haralick_feat = haralick_with_mean(img_gray)
            print(haralick_feat)
from paths import kth_path, kth_dir
def feat_extraction():
    
    for kth_type in kth_dir:
        for filename in listdir(kth_path + kth_type + '/'):
            print('Class: %s -- (%s)-> Image: %s'% (kth_type, kth_dir.index(kth_type), filename))
            
    
    
             
def main():
    path = 'datasets/'
    feat_extraction()
if __name__ =='__main__':
    main()