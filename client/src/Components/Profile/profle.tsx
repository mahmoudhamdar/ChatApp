import {useEffect, useState} from "react";
import axios from "axios";
import {URL} from "../../Utils/URL.ts";
import useSWR from "swr";


export const Profile = () => {

    const [online, setOnline] = useState("")
    const [lastActive, setLastActive] = useState(Date.now())
    const {data: userId} = useSWR(`userId`
        , async () => {
            return (await axios.post(`${URL}/api/UserApi/login`
            )).data;
        });
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

