import { createSlice } from '@reduxjs/toolkit'

export const userSlice = createSlice({
    name: "user",
    initialState: { value: {achievementIDs: [], achievementScore: 0, clanID: null, email: null, friendIDs: [], id: 0, inventoryID: 0, isClanOwner: null, settingsID: 0, username: '', villageID: 0} },
    reducers: {
        login: (state, action) => {
            state.value = action.payload
        }
    }
 })

export const { login } = userSlice.actions

export default userSlice.reducer