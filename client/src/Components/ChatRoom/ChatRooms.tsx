
    import  {useEffect, useState} from 'react';
    import {URL} from "../../Utils/URL.ts";
    import axios from "axios";
    import {ChatRoom} from "./ChatRoom.tsx";

    type ChatRoom = {
        roomName: string;
        roomId: string;
    }
    export const ChatRooms = () => {

        const [chatRooms, setChatRooms] = useState<ChatRoom[]>([]);
        useEffect(() => {
            
            axios.get(`${URL}/api/ChatRoomApi/`).then((response) => {
                console.log(response.data);
                setChatRooms(response.data)})
               
        },[])
    
        return (
            
            <div>
                {chatRooms.map((chatroom)=>{
                  return <ChatRoom  roomName={chatroom.roomName} key={chatroom.roomId} roomId={chatroom.roomId} />
                })}
                
            </div>        
            
        )
    
    
    }

