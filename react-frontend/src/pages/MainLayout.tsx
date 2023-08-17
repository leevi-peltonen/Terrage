import { CssBaseline, Container, Grid } from '@mui/material';
import React, { ReactNode, useState, useEffect } from 'react'
import Header from '../components/Header/Header';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { HeaderMenuOptions, HeaderText, Theme } from '../settings/TemplateVariables';
import Sidebar from '../components/Sidebar/Sidebar';
import { useSelector } from 'react-redux';
import { RootState } from '../features/rootReducer';

interface MainLayoutProps {
    children: ReactNode;
}

const darkTheme = createTheme({
    palette: {
        mode: Theme
    }
})

const MainLayout = ({ children }: MainLayoutProps) => {

    const [isSidebarOpen, setIsSidebarOpen] = useState(false)

    const user = useSelector((state: RootState) => state.user.value)

    useEffect(() => {
        if(user.id !== 0) {
            setIsSidebarOpen(true)
        }
        else {
            setIsSidebarOpen(false)
        }
    }, [user])

    return (
        <ThemeProvider theme={darkTheme}>
            <CssBaseline />
            <Container maxWidth="xl">
            <Header 
                header={HeaderText}
                menuOptions={HeaderMenuOptions}
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