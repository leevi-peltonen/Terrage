import { CssBaseline, Container, Grid } from '@mui/material';
import React, { ReactNode, useState, useEffect } from 'react'
import Header from '../components/Header/Header';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { HeaderMenuOptions, HeaderText } from '../settings/TemplateVariables';
import Sidebar from '../components/Sidebar/Sidebar';
import { useSelector } from 'react-redux';
import { RootState } from '../features/rootReducer';

interface MainLayoutProps {
    children: ReactNode;
}

const darkTheme = createTheme({
    palette: {
        mode: 'dark'
    }
})

const lightTheme = createTheme({
    palette: {
        mode: 'light'
    }
})


const MainLayout = ({ children }: MainLayoutProps) => {
    const settings = useSelector((state: RootState) => state.settings.value)
    const user = useSelector((state: RootState) => state.user.value)

    const [isSidebarOpen, setIsSidebarOpen] = useState(false)

    useEffect(() => {
        if(user.id !== 0) {
            setIsSidebarOpen(true)
        }
        else {
            setIsSidebarOpen(false)
        }
    }, [user])

    return (
        <ThemeProvider theme={settings.isDarkTheme ? darkTheme : lightTheme}>
            <CssBaseline />
            <Container maxWidth="xl">
            <Header 
                header={HeaderText}
            />
                <Grid
                    container
                    spacing={8}
                    direction="column"
                    alignItems="center"
                    justifyContent="center"
                    sx={{ minHeight: '100vh' }}
                >
                    <Grid item xs={3}>
                        {children}
                    </Grid>
                </Grid>
                <Sidebar open={isSidebarOpen} />
            </Container>
        </ThemeProvider>
    )
}

export default MainLayout