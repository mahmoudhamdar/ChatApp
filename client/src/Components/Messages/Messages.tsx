import {useEffect, useState} from 'react'
import {Message} from "./Message.tsx";

type Message = {
    content: string
    messageId: string
}
export const Messages = (props: { roomId: string }) => {
    {

        const [messages, setMessages] = useState<Message[]>([])
        useEffect(() => {

            // @ts-ignore
            GetMesseges(props.roomId).then((response) => {

                setMessages(response.data)
            })
        }, [])


        return (
            <div>
                {messages.map((message: Message) => {
                    return <Message content={message.content} key={message.messageId} messageId={message.messageId}/>
                })}
            </div>
        )
    }
}
