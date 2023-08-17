import { combineReducers } from "@reduxjs/toolkit";
import authReducer from '../features/authSlice'
import userReducer from '../features/userSlice'
import settingsReducer from '../features/settingsSlice'

const rootReducer = combineReducers({
    auth: authReducer,
    user: userReducer,
    settings: settingsReducer
})

export default rootReducer

export type RootState = ReturnType<typeof rootReducer>