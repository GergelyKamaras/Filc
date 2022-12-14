import React, {useState} from "react";
import FetchHashedPassword from "./FetchHashedPassword"
import FetchLogin from "./FetchLogin"
import bcrypt from 'bcryptjs'
import InnerProfil from "../Home/InnerProfil";
import '../../Style/IndexPage/InnerProfil.css'

const LoginForm = () => {
    
    const [loginStatus, updateLoginStatus] = useState(true);
    const [loginForm, updateLoginForm] = useState({});
    const [role, updateRole] = useState("")

    async function handleLogin(e)  {
        e.preventDefault();

        const email = loginForm["email"]
        const salt = await FetchHashedPassword({"Email": email});
    
        const data = {
            "Email": email,
            "Password": bcrypt.hashSync(loginForm["password"], salt),
            "RememberMe": false,
            "Role": role,
        }; 

        FetchLogin(data);
        updateLoginStatus(false)
    }
    
    function handleChange(event) {
        updateRole(event.target.value);
    }

    return (
        
        <div className="profile">
            <div className="profile-top">
                <div className="profile-pic">unavailable</div>
                <p className="not-logged-text">You have to login first</p>
            </div>
            <div className="profile-details">
                <div className="sign-in-box">
                    <div className="sign-in-box-inner"> 
                        <InnerProfil loginStatus={loginStatus} updateLoginStatus={updateLoginStatus} updateLoginForm={updateLoginForm} loginForm={loginForm} handleLogin={handleLogin} handleChange = {handleChange} />
                    </div>
                </div>
            </div>
            <div className="profile-footer">
            </div>
        </div>
        )
    }


export default LoginForm