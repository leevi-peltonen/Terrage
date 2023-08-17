import { FormControlLabel, FormGroup, Switch } from '@mui/material'
import React, { useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { changeTheme } from '../features/settingsSlice'
import { RootState } from '../features/rootReducer'

const Settings = () => {
    const dispatch = useDispatch()
    const isDarkTheme = useSelector((state: RootState) => state.settings.value.isDarkTheme)
    const handleThemeChange = () => {
        dispatch(changeTheme({isDarkTheme: !isDarkTheme}))
    }


    return (
        <FormGroup>
            <FormControlLabel 
                control={
                    <Switch
                        value={isDarkTheme} 
                        onChange={handleThemeChange} 
                        checked={isDarkTheme}
                    />
                }
                label="Dark Theme"
            />
        </FormGroup>
    )
}

export default Settings