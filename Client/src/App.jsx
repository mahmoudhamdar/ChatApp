import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ChatPage from './Components/ChatPage';
import LoginPage from './Components/LoginPage';
import AdminPage from './Components/AdminPage';
import {Home} from "./Pages/Home.jsx";

const App = () => {
    const [token, setToken] = useState(null);

    const handleLogin = (token) => {
        setToken(token);
        localStorage.setItem('token', token);
    };

    return (
        <Router>
            <Routes>
                <Route path={"/"} element={<Home/>} />
                <Route path="/login" element={<LoginPage onLogin={handleLogin} />} />
                <Route path="/chat" element={<ChatPage token={token} />} />
                <Route path="/admin" element={<AdminPage token={token} />} />
            </Routes>
        </Router>
    );
};

export default App;
