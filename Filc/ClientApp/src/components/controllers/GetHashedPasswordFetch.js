import React from 'react'

const GetHashedPasswordFetch = async (data) => {
    const response = await fetch('https://localhost:7014/authentication/login', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    return await response;
}

export default GetHashedPasswordFetch;