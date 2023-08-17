import React, { useState } from "react"
import { Avatar, LinearProgress, Grid, Button, Typography } from '@mui/material'
import { Character } from "../../models/CharacterModel"

interface CharacterDisplayProps {
    character: Character
    isPlayer: boolean
}

const CharacterCard = ({character, isPlayer}: CharacterDisplayProps) => {

    const [health, setHealth] = useState(Math.floor(Math.random()*100))

    return (
        <Grid sx={{width: 150}} container spacing={3} direction="column">
            <Grid item sx={{display:"flex", justifyContent:"space-around"}}>
                <Avatar>{character.name.charAt(0)}</Avatar>
                <Typography>{character.name}</Typography>
            </Grid>
            <Grid item>
                <Typography>Health</Typography>
                <LinearProgress variant="determinate" value={health} />
            </Grid>
            {isPlayer && 
                <Grid item>
                    <Button  variant="contained">Attack</Button>
                </Grid>
            }
        </Grid>
    )
}
export default CharacterCard