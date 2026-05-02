function scrollToBottom() {
    var chatMessages = document.getElementsByClassName("chat-messages")[0];
    if (chatMessages) {
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }
}
window.setImageModalInvoker = function (dotNetObjRef) {
    window.setImageModalInvoker = dotNetObjRef;
}
function openModalFromJS = function (imageSrc) {
    if (window.setImageModalInvoker) {
        window.setImageModalInvoker.invokeMethodAsync('OpenModal', imageSrc);
    }
}