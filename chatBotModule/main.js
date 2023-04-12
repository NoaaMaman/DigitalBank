const chatBox = document.querySelector('.chat-box');
const inputField = chatBox.querySelector('input[type="text"]');
const button = chatBox.querySelector('button');



button.addEventListener("click",sendMessage);
inputField.addEventListener('keypress',function(event){
    if(event.key == 'Enter'){
        sendMessage();
    }
});

function sendMessage(){
    const message = inputField.value;
    inputField.value = '';
    chatBoxBody.innerHTML += '<div class="chat-box-message">${message}</div>'

}