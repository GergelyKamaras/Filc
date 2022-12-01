import React from 'react'

const RegistrationFetch = (data) => {
     fetch ("https://localhost:7014/authentication/register",{
      method: "POST",
      headers: {
          'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    }).then((response) => response.json()).then((result)=>{
      if(result.message === "SUCCESS"){
          alert("You are logged in.");

      }else{
          alert("Please check your login information.")
      }
  })
}

export default RegistrationFetch;