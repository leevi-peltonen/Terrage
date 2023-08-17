import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface AuthState {
    token: string | null
}

const initialState: AuthState = {
    token: null
}

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        loginSuccess: (state, action: PayloadAction<string>) => {
            state.token = action.payload
        },
        logoutSuccess: (state) => {
            state.token = null
        }
    }
})

export const { loginSuccess, logoutSuccess } = authSlice.actions

export default authSlice.reducer