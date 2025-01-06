import {useForm} from "react-hook-form";

import {useNavigate} from "react-router-dom";
import {loginApi} from "../Services/ApiService.tsx";

import {z} from "zod"
import {zodResolver} from "@hookform/resolvers/zod";

type Values = {
    username: string
    password: string
}


export const Login = () => {
    const navigate = useNavigate();


    const schema = z.object({
        username: z.string(),
        password: z.string().min(7).max(30),

    }).required()


    const {register, handleSubmit, formState: {errors}} = useForm<Values>({
        resolver: zodResolver(schema),
    });

    const onSubmit = (values: Values) => {
        console.log(values);
        const data = loginApi(values.username, values.password)
        console.log(data)

        navigate(`/account`);
    };

    return (
        <div>

            <form onSubmit={handleSubmit(onSubmit)}>
                <label>Username</label>
                <input {...register("username")} />
                {errors.username && <p>{errors.username?.message}</p>}
                <label>Password</label>
                <input {...register("password")} type="password"/>
                {errors.password && <p>{errors.password?.message}</p>}
                <button type="submit">Login</button>
            </form>

        </div>
    );
}





