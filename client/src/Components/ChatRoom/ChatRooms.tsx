import {useEffect, useState} from 'react';

import {ChatRoom} from "./ChatRoom.tsx";
import {GetAllChatrooms} from "../../Services/ApiService.tsx";

type ChatRoom = {
    roomName: string;
    roomId: string;
}
export const ChatRooms = () => {

    const [chatRooms, setChatRooms] = useState<ChatRoom[]>([]);
    useEffect(() => {

        GetAllChatrooms().then((response) => {

            // @ts-ignore
            setChatRooms(response.data)
        })

    }, [])

    return (

        <div>
            {chatRooms.map((chatroom) => {
                return <ChatRoom roomName={chatroom.roomName} key={chatroom.roomId} roomId={chatroom.roomId}/>
            })}

        </div>

    )


}

