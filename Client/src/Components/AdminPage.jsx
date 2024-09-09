import React, { useEffect, useState } from 'react';
import axios from 'axios';
import socket from '../services/socket';

const AdminPage = () => {
    const [users, setUsers] = useState([]);
    const [messages, setMessages] = useState([]);

    useEffect(() => {
        // Fetch all users and messages on mount
        const fetchData = async () => {
            const usersResponse = await axios.get('https://localhost:7058/api/users');
            const messagesResponse = await axios.get('https://localhost:7058/api/messages');
            setUsers(usersResponse.data);
            setMessages(messagesResponse.data);
        };

        fetchData();

        // Set up the message listener for real-time updates
        socket.on('receive_message', (newMessage) => {
            setMessages((prevMessages) => [...prevMessages, newMessage]);
        });

        // Clean up the connection when the component unmounts
        return () => {
            socket.off('receive_message');
        };
    }, []);

    return (
        <div style={{ padding: '20px' }}>
            <h1>Admin Dashboard</h1>

            <h2>Users</h2>
            <ul style={{ listStyle: 'none', padding: '0' }}>
                {users.map((user) => (
                    <li key={user.id} style={{ margin: '5px 0' }}>
                        {user.userName} - {user.email}
                    </li>
                ))}
            </ul>

            <h2>Messages</h2>
            <div style={{ border: '1px solid #ccc', padding: '10px', height: '300px', overflowY: 'scroll' }}>
                {messages.map((msg, index) => (
                    <div key={index} style={{ margin: '10px 0' }}>
                        {msg}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default AdminPage;
