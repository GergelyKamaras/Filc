import React from 'react';

const LoginApiFetch = (data) => {
    fetch ("https://localhost:7014/authentication/login",{
        method: "POST", headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then((response) => response.json()).then((result)=>{
        if(result.message === "SUCCESS"){
            alert("You are logged in");

        }else{
            alert("Plese check your login information")
        }
    })

}
export default LoginApiFetch