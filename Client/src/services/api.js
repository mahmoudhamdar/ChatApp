import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7058/api', // Your API base URL
});

export const loginUser = (credentials) => api.post('/auth/login', credentials);
export const registerUser = (userData) => api.post('/auth/register', userData);
export const fetchMessages = () => api.get('/messages');
export const sendMessage = (messageData) => api.post('/messages', messageData);
export const fetchUsers = () => api.get('/users');

export default api;
