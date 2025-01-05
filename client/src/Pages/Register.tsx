



import {useForm} from 'react-hook-form';
import {URL} from "../Utils/URL.js";
import axios from "axios";
import * as yup from "yup"; 
import   {yupResolver} from "@hookform/resolvers/yup"

    export const Register = () => {
    
    type Values={
          username:string
          email:string
          password:string
          confirmpassword:string
    }
        
        const schema=yup.object().shape({
            username: yup.string().required(),
            email: yup.string().email().required(),
            password: yup.string().min(7).max(30).required(),
            confirmpassword: yup.string().oneOf([yup.ref('password'),""]).required(),

        })
     const {register, handleSubmit,formState:{errors}} = useForm<Values>({
         resolver: yupResolver(schema)
     });
    
    
     const onSubmit = (value:any) => {
         console.log(value);
        
         axios.post(`${URL}/api/UserApi/register`, value).then(r =>console.log(r.data))
     }
 
       
        return (
        <div>
          <form onSubmit={handleSubmit(onSubmit)}>
              
              <input type={"text"} placeholder={"UserName"} {...register("username")}  />
             <p>{errors.username?.message}</p>                                 
             <input type={"text"} placeholder={"Email"} {...register("email")}  />
              <p>{errors.email?.message}</p>
              <input type={"password"} placeholder={"Password"} {...register("password")}  />
              <p>{errors.password?.message}</p>
              <input type={"password"} placeholder={"ConfirmPassword"} {...register("confirmpassword")}  />
              <p>{errors.confirmpassword?.message}</p>
              <input type="submit" />
            </form>
            
        </div>
        
        
    )
    
    
    }


