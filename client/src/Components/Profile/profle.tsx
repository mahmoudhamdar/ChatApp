import {useEffect, useState} from "react";
import axios from "axios";


export  const Profile=()=> {

     const [online, setOnline] = useState("")
     const [lastActive, setLastActive] = useState(Date.now())
                                                         
    useEffect(() => {
      axios.get(`${URL}/api/UserStatusApi/`).then((response) => {
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

