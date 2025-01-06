import {useContext, useEffect, useState} from "react";
import axios from "axios";
import {userIdContext} from "../Contexts/userIdContext.tsx";


export  const Profile=()=> {

     const [online, setOnline] = useState("")
     const [lastActive, setLastActive] = useState(Date.now())
     const userId=useContext(userIdContext)                                                   
    useEffect(() => {
      axios.get(`${URL}/api/UserStatusApi/?id=${userId}`).then((response) => {
            console.log(response.data);
            setOnline(response.data.status)
          setLastActive(response.data.lastActive)
        });
    }, []);
    
    return (
        <div>
            <p>{online}</p>
            <p>{lastActive}</p>
        </div>
    )
}

