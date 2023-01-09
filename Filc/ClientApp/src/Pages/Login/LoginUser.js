import React, {useState} from "react";
import FetchHashedPassword from "./FetchHashedPassword"
import FetchLogin from "./FetchLogin"
import bcrypt from 'bcryptjs'
import InnerProfil from "../Home/InnerProfil";
import '../../Style/IndexPage/InnerProfil.css'

const LoginForm = ({loginStatus, updateLoginStatus}) => {
    
    
    const [loginForm, updateLoginForm] = useState({});

    async function handleLogin(e)  {
        e.preventDefault();

        const email = loginForm["email"]
        const salt = await FetchHashedPassword({"Email": email});
    
        const data = {
            "Email": email,
            "Password": bcrypt.hashSync(loginForm["password"], salt),
            "RememberMe": false
        }; 

        await FetchLogin(data);
        updateLoginStatus(false);
    
    }
    
    

    return (
        
        <div className="profile">
            <div className="profile-top">
                <div className="profile-pic">unavailable</div>
                {loginStatus ?
                    (<p className="not-logged-text">You have to login first</p>)
                    : 
                    (<p className="profile-name"> {loginForm["email"]} </p>)
                }
            </div>
            <div className="profile-details">
                <div className="sign-in-box">
                    <div className="sign-in-box-inner"> 
                        <InnerProfil loginStatus={loginStatus} updateLoginStatus={updateLoginStatus} updateLoginForm={updateLoginForm} loginForm={loginForm} handleLogin={handleLogin} />
                    </div>
                </div>
            </div>
            <div className="profile-footer">
            </div>
        </div>
        )
    }


export default LoginForm