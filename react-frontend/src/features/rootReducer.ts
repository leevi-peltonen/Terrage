import { combineReducers } from "@reduxjs/toolkit";
import authReducer from '../features/authSlice'
import userReducer from '../features/userSlice'

const rootReducer = combineReducers({
    auth: authReducer,
    user: userReducer
})

export default rootReducer

export type RootState = ReturnType<typeof rootReducer>