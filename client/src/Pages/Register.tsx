import {useForm} from 'react-hook-form';
import {registerApi} from "../Services/ApiService.tsx";
import {z} from "zod";
import {zodResolver} from "@hookform/resolvers/zod";

export const Register = () => {

    type Values = {
        username: string
        email: string
        password: string
        confirmPassword: string
    }

    const schema = z.object({
        username: z.coerce.string(),
        email: z.coerce.string().email(),
        password: z.coerce.string().min(7).max(30),
        confirmPassword: z.coerce.string().min(7).max(30),
    }).required().refine((data) => data.password === data.confirmPassword,
        {
            message: "Passwords don't match",
            path: ["confirmPassword"],
        }
    )


    const {register, handleSubmit, formState: {errors}} = useForm<Values>({
        resolver: zodResolver(schema)
    });


    const onSubmit = (value: Values) => {
        console.log(value);

        const data = registerApi(value.email, value.username, value.password);
        console.log(data);
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
                <input type={"password"} placeholder={"ConfirmPassword"} {...register("confirmPassword")}  />
                <p>{errors.confirmPassword?.message}</p>
                <input type="submit"/>
            </form>

        </div>


    )


}


