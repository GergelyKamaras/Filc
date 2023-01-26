
const GetHashedPasswordFetch = (data) => {
    const myresponse = fetch('/authentication/loginsalt', {
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