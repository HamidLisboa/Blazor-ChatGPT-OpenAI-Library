function scrollToBottom() {
    var chatMessages = document.getElementsByClassName("chat-messages")[0];
    if (chatMessages) {
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }
}

window.setImageModalInvoker = function (dotNetObjRef) {
    window.imageModalInvoker = dotNetObjRef;
}

// This function is used to call the .NET inline method - OpenModal.
window.openModalFromJs = function (imageSrc) {
    if (window.imageModalInvoker) {
        window.imageModalInvoker.invokeMethodAsync('OpenModal', imageSrc);
    }
}