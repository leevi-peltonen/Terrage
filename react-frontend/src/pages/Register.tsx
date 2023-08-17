import React, { useState, useEffect } from 'react'
import { Grid, TextField, Button } from '@mui/material'
import { RegisterUser } from '../api/UserApi'
import { useNavigate } from 'react-router-dom'
import { useDispatch } from 'react-redux'
import { login } from '../features/userSlice'
import { loginSuccess } from '../features/authSlice'

const Register = () => {
    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [repeatPassword, setRepeatPassword] = useState('')
    const [unequalPasswords, setUnequalPasswords] = useState(false)
    const [incorrectLength, setIncorrectLength] = useState(false)

    const dispatch = useDispatch()
    const navigate = useNavigate()

    const handleRegister = async () => {
        if(password !== repeatPassword) return

        const response = await RegisterUser({
            username: username,
            email: email,
            password: password
        })

        if(response.status === 200) {
            dispatch(login(response.data.user))
            dispatch(loginSuccess(response.data.token))
            navigate('/')
        }

        console.log(response)
    }


    // Password validation warnings
    useEffect(() => {
        if(password !== repeatPassword && repeatPassword.length === password.length) {
            setUnequalPasswords(true)
        } else {
            setUnequalPasswords(false)
        }

        if(repeatPassword.length !== password.length) {
            setIncorrectLength(true)
        } else {
            setIncorrectLength(false)
        }

    }, [password, repeatPassword])

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
                    type='email'
                    label="Email" 
                    value={email} 
                    onChange={(e) => setEmail(e.target.value)}
                    autoComplete='off'
                />
            </Grid>
            <Grid item>
                <TextField 
                    error={unequalPasswords}
                    color={incorrectLength ? 'warning' : 'primary'}
                    focused={incorrectLength}
                    label="Password" 
                    type="password" 
                    value={password} 
                    onChange={(e) => setPassword(e.target.value)}
                />
            </Grid>
            <Grid item>
                <TextField 
                    error={unequalPasswords}
                    color={incorrectLength ? 'warning' : 'primary'}
                    focused={incorrectLength}
                    label="Repeat Password" 
                    type="password" 
                    value={repeatPassword} 
                    onChange={(e) => setRepeatPassword(e.target.value)}
                />
            </Grid>
            <Grid item>
                <Button 
                    color="primary" 
                    variant="contained" 
                    fullWidth 
                    onClick={handleRegister}
                >
                    Sign up
                </Button>
            </Grid>
        </Grid>
    )
}

export default Register