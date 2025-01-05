


export const Message = ({content,messageId}:{content:string;messageId:string}) => {
    return (
        <div>
            <p>{content}</p>
            <p>{messageId}</p>
        </div>
    )
}