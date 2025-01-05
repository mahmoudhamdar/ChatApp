import  {Messages} from "../Messages/Messages.tsx";


export const ChatRoom = ({roomName,roomId}: { roomName: string; roomId: string; }) =>{
    return (
        <div>
            <p>{roomName}</p>
            <Messages roomId={roomId} />
            
        </div>
    )
   }








