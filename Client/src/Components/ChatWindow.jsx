import React, { useState, useEffect } from 'react';
import MessageList from './MessageList';
import MessageInput from './MessageInput';
import { fetchMessages, sendMessage } from '../services/api';
import { receiveMessage } from '../services/socket';

const ChatWindow = () => {
    const [messages, setMessages] = useState([]);

    useEffect(() => {
        fetchMessages().then((response) => setMessages(response.data));
        receiveMessage((message) => setMessages((prev) => [...prev, message]));
    }, []);

    const handleSendMessage = (text) => {
        const newMessage = { text, sender: 'currentUser' }; // Replace with actual user
        sendMessage(newMessage).then((response) => {
            setMessages((prev) => [...prev, response.data]);
        });
    };

    return (
        <div className="chat-window">
            <MessageList messages={messages} />
            <MessageInput onSend={handleSendMessage} />
        </div>
    );
};

export default ChatWindow;
