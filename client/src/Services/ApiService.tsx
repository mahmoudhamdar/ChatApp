import axios from "axios";
import {handleError} from "../Handlers/handleError.tsx";
import {UserProfileToken} from "../Models/User.ts";


export const api = "https://localhost:7058/api"


export const loginApi = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(`${api}/UserApi/login`, {
            username: username,
            password: password,
        })
        return data
    } catch (error) {
        handleError(error)
    }
}
export const loginApiNoParam = async () => {
    try {
        const data = (await axios.post(`${api}/UserApi/login`)).data
        return data
    } catch (error) {
        handleError(error)
    }
}
export const registerApi = async (email: string, username: string, password: string) => {

    try {

        const data = await axios.post<UserProfileToken>(`${api}/UserApi/register`, {
            username: username,
            password: password,
            email: email,
        })
        return data
    } catch (error) {

        handleError(error)
    }

}

export const GetAllChatrooms = async () => {
    try {
        const data = await axios.get(api + "api/ChatRoomApi")
        return data
    } catch (error) {
        handleError(error)
    }


}

export const GetAllAttachment = async () => {
    try {
        const data = await axios.get(api + "/AttachmentApi")
        return data
    } catch (error) {
        handleError(error)
    }

}


export const GetAllMesseges = async () => {
    try {
        const data = await axios.get(api + "/MessageApi")
        return data
    } catch (error) {
        handleError(error)
    }
}

export const GetMessage = async (id: string) => {
    try {
        const data = await axios.get(api + `/MessageApi/${id}`)
        return data
    } catch
        (error) {
        handleError(error)
    }
}

export const GetChatRoom = async (id: string) => {
    try {
        const data = await axios.get(api + `/ChatRoomApi/${id}`)
        return data
    } catch
        (error) {
        handleError(error)
    }
}
export const GetAttachment = async (id: string) => {
    try {
        const data = await axios.get(api + `/AttachmentApi/${id}`)
        return data
    } catch (error) {
        handleError(error)
    }
}



