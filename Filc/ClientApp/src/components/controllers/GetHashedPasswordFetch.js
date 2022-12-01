
import React from 'react'
import { resultingClientExists } from 'workbox-core/_private';

const GetHashedPasswordFetch = (data) => {
    const myresponse = fetch('https://localhost:7014/authentication/loginsalt', {
        method: 'POST',
        headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)

    }).then((response) => response.json()).then(result =>{
        return result.message; 
  }) 
  return myresponse
}

export default GetHashedPasswordFetch;