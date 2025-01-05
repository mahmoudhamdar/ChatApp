import { Link} from "react-router-dom";
import {ChatRooms} from "../Components/ChatRoom/ChatRooms.tsx";


export const Home = () => {

   
    
     return (
         <div>
             <Link to={"/Login"}>Login</Link>
             <Link to={"/Register"} >Register</Link>
            
           
             <div>
                 <ChatRooms />
             </div>
                 
           
             
             
             
         </div>
     )
    
    
    }





