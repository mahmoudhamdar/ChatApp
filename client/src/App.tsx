import {Home} from "./Pages/Home.tsx";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import {Login} from "./Pages/Login.tsx";
import {Register} from "./Pages/Register.tsx";
import {Account} from "./Components/Account/Account.tsx";
import "react-toastify/dist/ReactToastify.css";

const App = () => {


    return (
        <BrowserRouter>
            <Routes>
                <Route path={"/"} element={<Home/>}/>
                <Route path="/Login" element={<Login/>}/>
                <Route path="/Register" element={<Register/>}/>
                <Route path="/Account" element={<Account/>}/>


            </Routes>
        </BrowserRouter>
    );
};

export default App;

export interface userContext {
}