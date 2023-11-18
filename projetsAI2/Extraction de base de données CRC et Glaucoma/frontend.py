import streamlit as st
import cv2
import numpy as np
from PIL import Image
from BiT import bio_taxo
from mahotas.features import haralick
from skimage.feature import graycomatrix, graycoprops
from sklearn.preprocessing import MinMaxScaler
import os
import glob

toutes_caracteristiques = [] 
# Fonctions pour extraire les caractéristiques des images
def fct_haralick(data):
    return haralick(data).mean(0)

def fct_BiT(data):
    return bio_taxo(data)

def fct_GLCM(data):
    glcm = graycomatrix(data, [2], [0], 256, symmetric=True, normed=True)
    diss = graycoprops(glcm, 'dissimilarity')[0, 0]
    cont = graycoprops(glcm, 'contrast')[0, 0]
    corr = graycoprops(glcm, 'correlation')[0, 0]
    ener = graycoprops(glcm, 'energy')[0, 0]
    homo = graycoprops(glcm, 'homogeneity')[0, 0]
    all_statistics = [diss, cont, corr, ener, homo]
    return all_statistics

# Fonction pour trouver des images similaires en fonction des caractéristiques calculées
def trouver_images_similaires(caracteristiques_selectionnees, toutes_caracteristiques, top_n=5):
    distances = np.linalg.norm(toutes_caracteristiques - caracteristiques_selectionnees, axis=1)
    
    indices = np.argsort(distances)[:top_n]
    return indices

# Fonction pour charger une image et la convertir en format compatible avec Streamlit
def charger_image(image_data):
    img = Image.open(image_data)
    img_rgb = img.convert("RGB")
    return img_rgb

# Fonction pour calculer les caractéristiques à partir d'une image
def calculer_caracteristiques(image_data):
    img = np.array(image_data)
    B, G, R = img[:, :, 2], img[:, :, 1], img[:, :, 0]
    R_feat = fct_BiT(R)
    G_feat = fct_GLCM(G)
    B_feat = fct_haralick(B)
    combined_features = np.hstack([R_feat, G_feat, B_feat])
    return combined_features

# Chargement des caractéristiques et chemins d'images (à remplacer avec vos valeurs réelles)
# toutes_les_chemins_des_images = ...

# Application principale Streamlit
def main():
    st.title("Analyse de Similarité d'Images")
    
    uploaded_file = st.file_uploader("Choisissez une image...", type=["jpg", "jpeg", "png", "tiff", "tif"])
    
    if uploaded_file is not None:
        image = charger_image(uploaded_file)
        st.image(image, caption='Image Téléchargée', use_column_width=True)
        st.write("")
        
        # Ici vous pouvez utiliser uploaded_file pour extraire le contenu binaire de l'image
        caracteristiques_selectionnees = calculer_caracteristiques(image)
        
        indices_similaires = trouver_images_similaires(caracteristiques_selectionnees, toutes_caracteristiques)  # Remplacez par vos caractéristiques
        
        st.subheader("Images Similaires :")
        for index in indices_similaires:
            # Ici vous devez utiliser les chemins d'images de votre ensemble de données
            # chemin_image_similaire = toutes_les_chemins_des_images[index]
            # image_similaire = charger_image(chemin_image_similaire)
            # st.image(image_similaire, caption=f'Image Similaire {index}', use_column_width=True)
            pass
        
if __name__ == "__main__":
    main()
