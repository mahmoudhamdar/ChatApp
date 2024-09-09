import React from 'react';

const MessageList = ({ messages }) => {
    return (
        <div className="message-list">
            {messages.map((message, index) => (
                <div key={index} className={`message ${message.sender === 'currentUser' ? 'sent' : 'received'}`}>
                    <p>{message.text}</p>
                </div>
            ))}
        </div>
    );
};

export default MessageList;
