import {useEffect, useState} from "react";
import axios from "axios";
import {URL} from "src/Utils/URL.js";
export const Users = () => {

    const [users, setUsers] = useState([])
    useEffect(() => {
        axios.get(`${URL}/api/UserApi/`).then(response => {
            setUsers(response.data)
            console.log(response.data)
        })
            .catch(error => console.error(error))
    }, []);    
    
    return (
        <>
            {users.map((user,index) => {
                return <ul >
                    <li key={index} className={"user-name"}>{user.username}</li>
                </ul>
            })}
        </>
    );
};

