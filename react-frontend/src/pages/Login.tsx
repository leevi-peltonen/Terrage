import { Grid, TextField, Button } from '@mui/material'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useDispatch } from 'react-redux'
import { login } from '../features/userSlice'
import { loginSuccess } from '../features/authSlice'
import { LoginUser } from '../api/UserApi'

const Login = () => {
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    


    const dispatch = useDispatch()
    const navigate = useNavigate()

    const handleLogin = async () => {
        const response = await LoginUser({
            username,
            password
        })

        dispatch(login(response.user))
        dispatch(loginSuccess(response.token))
        navigate('/')
    }

    return (
        <Grid 
            container 
            direction="column" 
            spacing={2}
        >
            <Grid item>
                <TextField 
                    label="Username" 
                    value={username} 
                    onChange={(e) => setUsername(e.target.value)}
                    autoComplete='off'
                    autoFocus
                />
            </Grid>
            <Grid item>
                <TextField 
                    label="Password" 
                    type="password" 
                    value={password} 
                    onChange={(e) => setPassword(e.target.value)}
                />
            </Grid>
            <Grid item>
                <Button 
                    color="primary" 
                    variant="contained" 
                    fullWidth 
                    onClick={handleLogin}
                >
                    Login
                </Button>
            </Grid>
        </Grid>
    )
}

export default Login