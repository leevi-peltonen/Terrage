import { createSlice } from '@reduxjs/toolkit'

export const settingsSlice = createSlice({
    name: "settings",
    initialState: { value: {isDarkTheme: true} },
    reducers: {
        changeTheme: (state, action) => {
            state.value = action.payload
        }
    }
 })

export const { changeTheme } = settingsSlice.actions

export default settingsSlice.reducer