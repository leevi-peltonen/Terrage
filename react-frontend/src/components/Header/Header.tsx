import React, { useState } from 'react'
import { AppBar, Box, Toolbar, Typography, Button } from '@mui/material'
import { useNavigate } from 'react-router-dom'
import { useSelector, useDispatch } from 'react-redux'
import { RootState } from '../../features/rootReducer';
import { login } from '../../features/userSlice';
import { EmptyUser } from '../../utils/ModelUtils';
import { logoutSuccess } from '../../features/authSlice';

interface HeaderProps {
    header: string
}

const Header = ({header}: HeaderProps) => {

    const user = useSelector((state: RootState) => state.user.value)
    const dispatch = useDispatch()
    const navigate = useNavigate()

    const handleLogout = () => {
        dispatch(login(EmptyUser))
        dispatch(logoutSuccess())
        navigate('/')
    }

    return (
        <Box sx={{ flexGrow: 1}}>
            <AppBar position="static">
                <Toolbar>
                    <Typography 
                        variant="h6"
                        component="div"
                        sx={{ flexGrow: 1}}
                    >
                        {header}
                    </Typography>
                    {user.id === 0 ? 
                    <>
                        <Button color="inherit" onClick={() => navigate('/register')}>Sign up</Button>
                        <Button color="inherit" onClick={() => navigate('/login')}>Login</Button>
                    </>
                    :
                    <Button color="inherit" onClick={handleLogout} >Logout</Button>
                    }
                </Toolbar>
            </AppBar>
        </Box>
    )
}

export default Header