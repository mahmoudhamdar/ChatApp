
import  {useEffect} from 'react'
import {URL} from "../../Utils/URL.ts";
import axios from "axios";
import {useState} from "react";
import {Message} from "./Message.tsx";

type Message = {
    content:string
    messageId:string
}
export const Messages = (props:{roomId:string}) => {{
    
     const [messages, setMessages] = useState<Message[]>([])
    useEffect(() => {

        axios.get(`${URL}/api/MessageApi/?id=${props.roomId}`).then((response) => {
            console.log(response.data);
            setMessages(response.data)})
    },[])
    
    
    
    return (
        <div>
            {messages.map((message:Message)=>{
             return  <Message content={message.content} key={message.messageId} messageId={message.messageId}/> 
            })}
        </div>
    )
}}
