import cv2
import os
import glob
import numpy as np
import pandas as pd
from typing import List
from skimage.feature import graycomatrix, graycoprops
from sklearn.preprocessing import MinMaxScaler
from BiT import bio_taxo
from mahotas.features import haralick

def fct_haralick(data):
    return haralick(data).mean(0)

def fct_BiT(data):
    return bio_taxo(data)

def fct_GLCM(data):
    glcm = graycomatrix(data, [2], [0], 256, symmetric=True, normed=True)
    glcm_props = graycoprops(glcm, prop_names=("dissimilarity", "contrast", "correlation", "energy", "homogeneity"))
    return glcm_props

def change_class(cls_name):
    class_mapping = {
        "01_TUMOR": "TUMOR",
        "02_STROMA": "STROMA",
        "03_COMPLEX": "COMPLEX",
        "04_LYMPHO": "LYMPHO",
        "05_DEBRIS": "DEBRIS",
        "06_MUCOSA": "MUC",
        "07_ADIPOSE": "ADIP"
    }
    return class_mapping.get(cls_name, cls_name)

def convert_class(cls_name):
    return 0 if cls_name == 'Saudave1' else 1

def save_to_csv(features, output_path):
    df = pd.DataFrame(features)
    df.to_csv(output_path, index=False)

def process_images(image_directory, subfolders):
    features = []
    count = 0
    for image_type in subfolders:
        image_paths = glob.glob(os.path.join(image_directory, image_type, "*"))
        for image_path in image_paths:
            img = cv2.imread(image_path)
            R, G, B = cv2.split(img)
            
            R_feat = fct_BiT(R)
            G_feat = fct_GLCM(G)
            B_feat = fct_haralick(B)

            if image_directory == "REFUGE":
                cls = convert_class(image_type)
            else:
                cls = change_class(image_type)
            feature = np.hstack([R_feat, G_feat, B_feat, cls])
            features.append(feature)
            count += 1
            print(f'Feature Extracted {count} --> {image_type}')
    return features

def normalize(features, output_path):
    X = np.array([row[:-1] for row in features])
    Y = np.array([row[-1] for row in features])
    scaler = MinMaxScaler()
    XN = scaler.fit_transform(X)
    normalized_data = np.hstack((XN, Y.reshape(-1, 1)))
    normalized_df = pd.DataFrame(normalized_data)
    normalized_df.to_csv(output_path, index=False)

def main():
    crc_path = r'D:\DEC\Ete2023\420-1AB-TT IA 2  VISION ARTIFICIELLE ET RECONNAISSANCE\env\labo1\datasets/CRC'
    crc_dir = os.listdir(crc_path)
    crc_features = process_images(crc_path, crc_dir)

    crc_output_path = './crc.csv'
    save_to_csv(crc_features, crc_output_path)

    normalized_output_path = './Normalized_CRC.csv'
    normalize(crc_features, normalized_output_path)

if __name__ == "__main__":
    main()
