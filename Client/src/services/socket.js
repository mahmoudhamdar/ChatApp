import { io } from 'socket.io-client';

const socket = io('https://localhost:7058');

export const sendMessage = (message) => {
    socket.emit('send_message', message);
};

export const receiveMessage = (callback) => {
    socket.on('receive_message', callback);
};

export default socket;
