import React, { useEffect } from "react";
import '../../Style/IndexPage/InnerProfil.css'
import '../../Style/IndexPage/SignIn.css'


const InnerProfil = ({loginStatus, updateLoginStatus, loginForm, updateLoginForm, handleLogin}) => {


    const updateLoginField = (newValue, field) => {
        updateLoginForm({ ...loginForm, [field]: newValue })
        
    }

    useEffect(() => {

        if(localStorage.getItem("AccessToken") !== null){
            updateLoginStatus(false)
        }else{updateLoginStatus(true)}

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
            sajt
        </div>
        )
        }
    </div>        
    )    
}

export default InnerProfil