#pip install openai streamlit streamlit-chat

import openai
import streamlit as st
from streamlit_chat import message
st.set_page_config(page_title="GPT",page_icon=":books:",layout="wide")

st.title(' :gear: :red[Chatbot: GPT] :-1:')


openai.api_key = 'OpenAi key'





def generate_response(user_input):
    completions = openai.Completion.create(
        engine='text-davinci-003',
        prompt=user_input,
        max_tokens=1024,
        n=1,
        stop=None,
        temperature =0.5, 
    )
    message = completions.choices[0].text    # .text c'est ToString()
    return message

if 'past_response'  not in st.session_state: 
    st.session_state.past_response =[]
if 'past_input' not in st.session_state:
    st.session_state['past_input'] = []


def get_input():
    input_text = st.text_input("You:","Hello, how the world has been treating you?",key='input')
    return input_text

user_input = get_input()
if user_input: 
    output= generate_response(user_input)
    st.session_state.past_input.append(user_input)
    st.session_state.past_response.append(output)

if st.session_state.past_response:
   for i in range(len(st.session_state.past_response)):
    message(st.session_state.past_input[i], is_user=True, key=f'{i}_user')
    message(st.session_state.past_response[i], key=str(i))
 


