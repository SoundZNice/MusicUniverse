import React from 'react'

export const Image = props => (
    <img src={`data:image/${props.format};base64,${props.content}`} alt={props.name}/>
)