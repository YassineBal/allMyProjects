import streamlit as st
import cv2, os, time
import numpy as np
from PIL import Image
from descriptors import bitdesc
import pandas as pd
from scipy.spatial import distance
from distances import distance_selection
from upload import upload_file

def main():
    print("App launched!")
    # Enter number of results
    input_value = st.sidebar.number_input("Enter a value", min_value=1, max_value=500, value=10, step=1)
    # Display input value
    st.sidebar.write(f"You entered {input_value}")
    # Define distances
    options = ["Euclidean", "Canberra", "Manhattan", "Chebyshev", "Minkowsky"]
    distance_option = st.sidebar.selectbox("Select a distance", options)
    st.sidebar.write(f"You chose {distance_option}")
    # Import off-line database (signatures)
    signatures = np.load('cbir_signatures_v1.npy', allow_pickle=True)
    # Define a list for computed distances
    distanceList = list()
    # Upload image
    is_image_uploaded = upload_file()
    if is_image_uploaded:
        st.write('''
                 # Search Results
                 ''')
        # Retrieve query image
        query_image = 'uploaded_images/query_image.png'
        # Read image as gray-scale
        img = cv2.imread(query_image, 0)
        # Get signatures (extract features) of query image/Compute Bitdesc
        bit_feat = bitdesc(img)
        # Compute Similarity distance
        for sign in signatures:
            # Remove the last two columns ('subfolder', 'path')
            sign = np.array(sign)[0:-2].astype('float')
            # Convert numpy to list
            sign = sign.tolist()
            # Call distance function
            dist = distance_selection(distance_option, bit_feat, sign)
            distanceList.append(dist)
        print("Distance computed successfully")
        # Compute n min distances
        minDistances =list()
        for i in range(input_value):
            array = np.array(distanceList)
            # Get index of min value from distance list and add to minDistances list
            index_min = np.argmin(array)
            minDistances.append(index_min)
            # Grab max value
            max_val = array.max()
            # Overwrite the min value with max value
            distanceList[index_min] = max_val
        print(minDistances)
        # Display bar chart
        st.write('### Bar Chart - Class Frequencies')
        # Retrieve classes/types of most similar images using their distances
        classes = [signatures[small][-2] for small in minDistances]
        classes = np.array(classes)
        # Get unique values of types and count all
        unique_values, counts = np.unique(classes, return_counts=True)
        # Create pandas DataFrame with the unique values and their counts
        df = pd.DataFrame({"Value": unique_values, "Frequency": counts})
        st.bar_chart(df.set_index("Value"))
        # Display most similar images
        st.write('### Most Similar Images')
        for small in minDistances:
            class_name, img_path = signatures[small][-2], signatures[small][-1]
            img = Image.open(img_path)
            # Resize the image to a smaller size
            img.thumbnail((200,200))
            st.image(img, caption=f'Class: {class_name}', use_column_width=50)

    else:
        st.write("Welcome! Please upload an image to get started ...")

if __name__ == "__main__":
    main()