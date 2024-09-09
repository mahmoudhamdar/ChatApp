import React, { useEffect, useState } from 'react';
import socket from '../services/socket';

const ChatPage = () => {
    const [messages, setMessages] = useState([]);
    const [message, setMessage] = useState('');

    useEffect(() => {
        // Set up the message listener
        socket.on('receive_message', (newMessage) => {
            setMessages((prevMessages) => [...prevMessages, newMessage]);
        });

        // Clean up the connection when the component unmounts
        return () => {
            socket.off('receive_message');
        };
    }, []);

    const handleSendMessage = () => {
        if (message.trim() !== '') {
            socket.emit('send_message', message);
            setMessage('');
        }
    };

    return (
        <div style={{ padding: '20px' }}>
            <h1>Chat Room</h1>
            <div style={{ border: '1px solid #ccc', padding: '10px', height: '300px', overflowY: 'scroll' }}>
                {messages.map((msg, index) => (
                    <div key={index} style={{ margin: '10px 0' }}>
                        {msg}
                    </div>
                ))}
            </div>
            <input
                type="text"
                value={message}
                onChange={(e) => setMessage(e.target.value)}
                onKeyDown={(e) => {
                    if (e.key === 'Enter') handleSendMessage();
                }}
                style={{ width: '80%', padding: '10px', marginRight: '10px' }}
            />
            <button onClick={handleSendMessage} style={{ padding: '10px 20px' }}>Send</button>
        </div>
    );
};

export default ChatPage;
