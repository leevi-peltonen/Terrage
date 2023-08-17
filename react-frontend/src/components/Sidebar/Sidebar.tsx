import React from 'react'
import { Drawer, List, ListItem, ListItemText, ListItemButton, ListItemIcon, Divider } from '@mui/material'
import { SidebarMenuOptions } from '../../settings/TemplateVariables'
import { useNavigate } from 'react-router-dom'


interface SidebarProps {
    open: boolean
}

const Sidebar = ({ open }: SidebarProps) => {

    const navigate = useNavigate()

    return (
        <Drawer
            variant="permanent"
            anchor="left"
            sx={{
                width: 240,
                flexShrink: 0,
                '& .MuiDrawer-paper': {
                    width: 240,
                    boxSizing: 'border-box',
                    transform: open ? 'translateX(0)' : 'translateX(-240px)',
                    transition: 'transform 0.3s ease-in-out',
                  }
            }}
        >
            <List>
                {SidebarMenuOptions.map((option, i) => {
                    return (
                        <ListItem key={i}>
                            <ListItemButton onClick={() => navigate(option.path)}>
                                <ListItemText primary={option.name}  />
                            </ListItemButton>
                        </ListItem>
                    )
                })}
            </List>
        </Drawer>
    )
}

export default Sidebar