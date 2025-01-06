import axios from "axios";

import useSWR from "swr";
import {api} from "../../Services/ApiService.tsx"
import {useState} from "react";


export const MessageInput = ({roomId}: { roomId: string }) => {

    const [Message, setMessage] = useState<string>("");
    const {data: userId} = useSWR(`${api}/UserApi/login`
        , async () => {
            return (await axios.post(`${api}/UserApi/login`)).data;
        });

    const sendMessage = (message: string) => {

        // console.log(roomId);
        axios.post(`${URL}/api/MessageApi/`, {
            roomId: roomId,
            message: message,
            createdAt: Date.now(),
            userId: userId.userId
        }).then(r => {
            console.log(r.data);
        });

        console.log("sendMessage");
        console.log(userId);
    }

    return (
        <div>

            <input type="text" onChange={(e) => {
                setMessage(e.target.value);
            }}/>
            <button onClick={() => {
                sendMessage(Message);
            }}>Send
            </button>

        </div>
    )


}