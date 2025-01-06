import {MessageInput} from "../Messages/MessageInput.tsx";
import {Messages} from "../Messages/Messages.tsx";


export const ChatWindow = ({roomId,roomName}:{roomId:string;roomName:string}) => {
    
    
    
    return (
        <div>
            <div>
                {roomName}
            </div>
            <div>
            <Messages roomId={roomId}/>
            <MessageInput/>
            </div>
        </div>
    )
    
}
