import axios from "axios";
import React, {useContext} from "react";

import {userContext} from "../../App.tsx";

export interface userContext {
   userId: string;
    
}
export const MessageInput=()=> {

    
    const [userId]:string = useContext(userContext);
    const sendMessage = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        
        axios.post(`${URL}/api/MessageApi/`, {
            message: event.target.toString(),
            userId: userId,
            chatId: 1,
        }).then(r => {
            console.log(r.data);
        });
        
        console.log("sendMessage");
    }
    
    return (
            <div>
                
                <input type="text" />
                <button onClick={(e)=>{sendMessage(e)}}>Send</button>
                    
            </div>
        )



}