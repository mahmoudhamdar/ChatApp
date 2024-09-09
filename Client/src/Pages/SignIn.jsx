import {useState} from "react";


export const SignIn = () => {

    const [UserName, setUserName] = useState("")
    const [Password, setPassword] = useState("");

    return (
        <div>
            <form>
            <input className={} type={"text"} placeholder={"Username"} onChange={(e) => setUserName(e.target.value)}/>
            <input className={} type={"password"} placeholder={"Password"} onChange={(e) => setPassword(e.target.value)}/>
            <button className={} type={"submit"}>Sign In</button>
            </form>
        
        </div>
    );
};