import React from 'react'
import CharacterCard from '../components/Battle/CharacterCard'
import { Grid } from '@mui/material'

const Battle = () => {
    return (
        <Grid container spacing={10}>
            <Grid item>
                <CharacterCard character={{
                    name: "Stetu",
                    health: 100,
                    maxHealth: 100
                    }} 
                    isPlayer={true}
                />
            </Grid>

            <Grid item>
                <CharacterCard character={{
                    name: "Goblin",
                    health: 50,
                    maxHealth: 50
                    }} 
                    isPlayer={false}
                />
            </Grid>
        </Grid>
    )
}

export default Battle