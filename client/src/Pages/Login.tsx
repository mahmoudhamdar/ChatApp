

import {useForm} from "react-hook-form";
import axios from "axios";
import {URL} from "../Utils/URL.js";
import * as yup from "yup";
import {yupResolver} from "@hookform/resolvers/yup";
import {useNavigate} from "react-router-dom";

import {userIdContext} from "../Components/Contexts/userIdContext.tsx";
import {useContext} from "react";


type Values ={
           username: string
            password:string
}


export const Login = () => {
    const navigate = useNavigate();
    
   
    const context = useContext(userIdContext) ;   
    
    const schema = yup.object().shape({
        username: yup.string().required(),
        password: yup.string().min(7).max(30).required(),
    });

    const {register, handleSubmit, formState:{errors}} = useForm<Values>({
        resolver: yupResolver(schema),
    });                     
    
    const onSubmit = (values: any) => {
        console.log(values);
        axios.post(`${URL}/api/UserApi/login`, values).then(r => {
            console.log(r.data);
            context?.setUserId(r.data.userId);
        });
        
        navigate("/account");
    };

    return (
        <div>
           
                <form onSubmit={handleSubmit(onSubmit)}>
                    <label>Username</label>
                    <input {...register("username")} />
                    {errors.username && <p>{errors.username?.message}</p>}
                    <label>Password</label>
                    <input {...register("password")} type="password" />
                    {errors.password && <p>{errors.password?.message}</p>}
                    <button type="submit">Login</button>
                </form>
           
        </div>
    );
}





