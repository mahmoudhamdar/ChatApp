import React, {ReactNode, useState} from "react";
import { userIdContext } from "./userIdContext";


interface MyProviderProps {
    children:ReactNode;
}
export const MyProvider:React.FC<MyProviderProps> = ({children}: MyProviderProps) => {
    const [userId, setUserId] = useState<string>();

return (
    <userIdContext.Provider value={{userId, setUserId}}>

        {children}

    </userIdContext.Provider>
    
);

}