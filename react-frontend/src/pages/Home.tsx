import React from "react"
import { useSelector } from 'react-redux'
import { RootState } from '../features/rootReducer'

const Home = () => {

    const user = useSelector((state: RootState) => state.user.value)

    return (
        <>
        </>
    )
}

export default Home