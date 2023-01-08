
import jwt from "jwt-decode";
import React, { useEffect } from "react";
import '../../Style/IndexPage/InnerProfil.css'
import '../../Style/IndexPage/SignIn.css'


const InnerProfil = ({loginStatus, updateLoginStatus, loginForm, updateLoginForm, handleLogin}) => {

    const getUserToken = () => {
        console.log(jwt(localStorage?.AccessToken))
        return jwt(localStorage?.AccessToken);
    }

    const getUserId = () => {
        return getUserToken()["userId"]
    }

    const getUserName = () => {
        return `${getUserToken()["userFirstName"]} ${getUserToken()["userLastName"]}`
    }
    
    const getUserEmail = () => {
        return getUserToken()["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]
    }

    const getUserBirthDate = () => {
        return getUserToken()["userBithDate"]
    }

    const updateLoginField = (newValue, field) => {
        updateLoginForm({ ...loginForm, [field]: newValue })
        
    }

    useEffect(() => {

        if(localStorage.getItem("AccessToken") !== null){
            updateLoginStatus(false)
        }else{}

    }); 

    return(
    <div>
        {loginStatus ?(
        <form>
            <div className="form-group email">
                <label htmlFor="email">Email</label>
                <input defaultValue={loginForm?.email ? loginForm.email : ""} onChange={(e) => updateLoginField(e.target.value, "email")} id="email" type="email" className="form-control" />
            </div>
            <div className="form-group password">
                <label htmlFor="password">Password</label>
                <input defaultValue={loginForm?.password ? loginForm.password : ""} onChange={(e) => updateLoginField(e.target.value, "password")} id="Password" type="password" className="form-control"/>
            </div>
            
            <button type="submit" className="login-btn"
                onClick={handleLogin}>Login</button>
            </form>
        ):(
        
        <div>
            <p className="userId">
                ID number: <strong> {getUserId()} </strong>
            </p>

            <p className="userName">
                Name: <strong> {getUserName()} </strong>
            </p>
            <p className="userEmail">
                Email: <strong> {getUserEmail()}</strong>
            </p>
            <p className="userBirthDate">
                Birth Date: <strong> {getUserBirthDate()}</strong>
            </p>
        </div>
        )
        }
    </div>        
    )    
}

export default InnerProfil