import React from 'react'

const RegistrationFetch = async (data) => {
    const response = await fetch('https://localhost:7014/authentication/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
        },
      body: JSON.stringify(data)
  })
}

export default RegistrationFetch;