import cv2
import mahotas.features as ft
from skimage.feature import graycomatrix, graycoprops # scikit-image
from BiT import biodiversity, taxonomy # Bitdesc
import numpy as np
# Define Haralick
def haralick(data):
    all_statistics = ft.haralick(data)
    return all_statistics
def haralick_with_mean(data):
    all_statistics = ft.haralick(data).mean(0)
    return all_statistics

# Define Bitdesc
def bitdesc(data):
    bio = biodiversity(data)
    taxo = taxonomy(data)
    all_statistics = bio + taxo
    return all_statistics

# Gray-Level Co-occurence Matrix
def glcm(data):
    glcm = graycomatrix(data, [2], [0], 256, symmetric=True, normed=True)
    diss = graycoprops(glcm, 'dissimilarity')[0,0]
    cont = graycoprops(glcm, 'contrast')[0,0]
    corr = graycoprops(glcm, 'correlation')[0,0]
    ener = graycoprops(glcm, 'energy')[0,0]
    homo = graycoprops(glcm, 'homogeneity')[0,0]    
    all_statistics = [diss, cont, corr, ener, homo]
    return all_statistics

