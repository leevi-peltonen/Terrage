import axios from 'axios'
import { LoginData, RegisterData } from '../models/UserModel'
import { url } from '../utils/ApiUtils'
import { storageSave } from '../utils/storage'


const config = {
    headers: {
        'Content-Type': 'application/json'
    }
}

export const RegisterUser = async (credentials: RegisterData) => {
    const res = await axios.post(url + 'api/Users/Register', credentials, config)
    storageSave('token', res.data.token)
    return res
}

export const LoginUser = async (credentials: LoginData) => {
    const res = await axios.post(url + 'api/Users/Login', credentials, config)
    storageSave('token', res.data.token)
    return res.data
}