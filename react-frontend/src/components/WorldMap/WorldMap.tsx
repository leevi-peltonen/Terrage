import React, { useState, useRef, useEffect } from 'react';
import './WorldMap.css';
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";

const SvgMap = process.env.PUBLIC_URL + '/WorldOfTerrage.svg'


const WorldMap = () => {

 
    return (
      <TransformWrapper>
        <TransformComponent>
          <img src={SvgMap} alt="SVQ" />
        </TransformComponent>
      </TransformWrapper>
      )
}

export default WorldMap;