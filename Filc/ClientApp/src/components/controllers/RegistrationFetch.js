const RegistrationFetch = async (data) => {
    const response = await fetch('/', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
        },
      body: JSON.stringify(data)
  })
}

export default RegistrationFetch;