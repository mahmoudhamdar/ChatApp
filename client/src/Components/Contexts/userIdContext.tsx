import {createContext} from "react";


interface UserIdContextType {
    userId: string | undefined;
    setUserId: (userId: string) => void;
}

export const userIdContext = createContext<UserIdContextType | undefined>(undefined);
