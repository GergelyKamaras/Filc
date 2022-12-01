import React from 'react';
import jwt from 'jwt-decode'

const LoginApiFetch = (data) => {
    fetch ("https://localhost:7014/authentication/login",{
        method: "POST", headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
            
        },
        body: JSON.stringify(data)
    }).then( (response) => response.json()).then( (result)=>{
        if(result.message === "SUCCESS"){
            alert("You are logged in");

            const Token = result.token;
            const user = jwt(Token);
            const userRole = user["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
            const userEmail = user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
            localStorage.setItem("AccesToken", Token);
            localStorage.setItem("userRole", userRole);
            localStorage.setItem("userEmail", userEmail);
        }else{
            alert("Plese check your login information")
        }
    })

}
export default LoginApiFetch