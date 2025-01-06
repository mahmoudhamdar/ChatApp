import {ChatWindow} from "../ChatWIndow/ChatWindow.tsx";


export const ChatRoom = ({roomName, roomId}: { roomName: string; roomId: string; }) => {
    return (
        <div>
            <p>{roomName}</p>
            <ChatWindow roomId={roomId} roomName={roomName}/>


        </div>
    )
}








