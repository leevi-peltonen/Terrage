import React, { useState } from 'react'
import { AppBar, Box, Toolbar, Typography, Button, IconButton, Menu, MenuItem, bottomNavigationActionClasses } from '@mui/material'
import MenuIcon from '@mui/icons-material/Menu';
import ListItemIcon from '@mui/material/ListItemIcon';
import { useNavigate } from 'react-router-dom'
import { useSelector, useDispatch } from 'react-redux'
import { RootState } from '../../features/rootReducer';
import { login } from '../../features/userSlice';
import { EmptyUser } from '../../utils/ModelUtils';
import { logoutSuccess } from '../../features/authSlice';

interface HeaderProps {
    header: string
    menuOptions: menuOption[]
}

interface menuOption {
    name: string
    path: string
}

const Header = ({header, menuOptions}: HeaderProps) => {

    const user = useSelector((state: RootState) => state.user.value)
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);
    const handleMenuClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget)
    }
    const handleMenuItemClick = (path: string) => {
        navigate(path)
        handleClose()
    }

    const handleClose = () => {
        setAnchorEl(null)
    }
    const handleLogout = () => {
        dispatch(login(EmptyUser))
        dispatch(logoutSuccess())
        navigate('/')
    }

    return (
        <Box sx={{ flexGrow: 1}}>
            <AppBar position="static">
                <Toolbar>
                {user.id !== 0 && 
                <>
                    <IconButton
                        size="large"
                        edge="start"
                        color="inherit"
                        aria-label="menu"
                        sx={{ mr: 2 }}
                        onClick={handleMenuClick}
                    >
                        <MenuIcon />
                    </IconButton>

                    <Menu
                        anchorEl={anchorEl}
                        open={open}
                        onClose={handleClose}
                        onClick={handleClose}
                    >
                        {menuOptions.map((option, i) => {
                            return (
                                <MenuItem key={i} onClick={() => handleMenuItemClick(option.path)}>
                                    <ListItemIcon>

                                    </ListItemIcon>
                                    {option.name}
                                </MenuItem>
                            )
                        })}

                    </Menu></>}

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