import React, { useEffect, useState } from 'react';

export default function ImagesList() {
    const [images, setImages] = useState([]);

    useEffect(() => {
        fetch("https://localhost:7030/api/images?size=big").then(res => res.json()).then(
            result => {
                setImages(result)
            }
        )
    }, []);



    return (
        <>
            {images.map(tur => (
                <img src={tur} alt="test"></img>
            ))}
        </>
    )
}