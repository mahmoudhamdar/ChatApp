
import {Home} from "./Pages/Home.tsx";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import {Login} from "./Pages/Login.tsx";
import {Register} from "./Pages/Register.tsx";


const App = () => {
  


    return (
        <BrowserRouter >
            <Routes>
                <Route path={"/"} element={<Home />} />
                <Route path="/Login" element={<Login />  } />
                <Route path="/Register" element={<Register />} />


            </Routes>
        </BrowserRouter>
    );
};

export default App;

export interface userContext {
}