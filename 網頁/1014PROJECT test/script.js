document.addEventListener('DOMContentLoaded', () => {
    const messageForm = document.getElementById('message-form');
    const messageList = document.getElementById('message-list');

    messageForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const username = document.getElementById('username').value;
        const message = document.getElementById('message').value;

        const response = await fetch('/submit-message', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, message }),
        });

        const result = await response.json();
        if (result.success) {
            // 清空輸入框並重新載入留言列表
            document.getElementById('message').value = '';
            loadMessages();
        }
    });

    async function loadMessages() {
        const response = await fetch('/get-messages');
        const messages = await response.json();

        messageList.innerHTML = '';
        messages.forEach((msg) => {
            const listItem = document.createElement('div');
            listItem.classList.add('message');
            listItem.innerHTML = `
                <strong>${msg.username}:</strong>
                <p>${msg.content}</p>
            `;
            messageList.appendChild(listItem);
        });
    }

    loadMessages();
});