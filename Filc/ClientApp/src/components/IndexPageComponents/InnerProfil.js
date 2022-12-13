import React, {useState, useEffect} from "react";
import {useNavigate} from 'react-router-dom';
import '../../Style/IndexPage/InnerProfil.css'
import '../../Style/IndexPage/SignIn.css'
import bcrypt from 'bcryptjs'
import { useRef } from 'react'
import RegistrationFetch from "../controllers/RegistrationFetch"
import GetHashedPasswordFetch from "../controllers/GetHashedPasswordFetch"
import LoginApiFetch from "../controllers/LoginApiFetch"



const InnerProfil = () => {


    const emailInputRef = useRef();
    const passwordInputRef = useRef();

    const handleRegistration = (e) => {
        e.preventDefault();

        const salt = bcrypt.genSaltSync(10);

        const email = emailInputRef.current.value;
        const password = passwordInputRef.current.value;
        const hashedPassword = bcrypt.hashSync(password, salt);

        var userData = {
            Email: email,
            Username: email,
            Password: hashedPassword,
            Salt: salt,
            Role: "SchoolAdmin"
        };
        console.log(userData);
        RegistrationFetch(userData);
    }

    const handleLogin = async (e) => {
        e.preventDefault();
        
        const email = emailInputRef.current.value;

        const userEmail = {
            Email:email
        }

        const salt = await GetHashedPasswordFetch(userEmail);
        const hashedPassword = bcrypt.hashSync(passwordInputRef.current.value, salt)
        
        var data = {
            Email: email,
            Password: hashedPassword,
            Role: "Teacher"
        };
        LoginApiFetch(data);
            setIsLoggedIn(x=> loggedpage)

    }
    
    const loggedpage = 
    <div className="profile">
    <div className="profile-top">
        <div className="profile-pic">Your picture</div>
        <p className="email-text">Email: {localStorage.getItem("email")}</p>
        <p className="phone-text">Phone number: +1 (202) 686 0605</p>
    </div>
    <div className="profile-details">
        <p className="role-text">Role: {localStorage.getItem("userRole")}</p>
        <p className="school-text">School: Lovely Elementary School</p>
        <p className="grade-text">10.A</p>
        <p className="email-text"></p>
    </div>
    </div>
    
    const isLogged = () => {
        if(localStorage.getItem("AccessToken") === null){
            return true;
        }
        else{
            return false;
        }
    }
    const [IsLoggedIn, setIsLoggedIn] = useState(isLogged() ?
        
    <div className="profile">
        <div className="profile-top">
            <div className="profile-pic">unavailable</div>
            <p className="not-logged-text">You have to login first</p>
        </div>
        <div className="profile-details">
            <div className="sign-in-box">
                <div className="sign-in-box-inner">
                    <form>
                        <div className="form-group email">
                            <label htmlFor="Email">Email</label>
                            <input ref={emailInputRef} id="Email" type="email" className="form-control" />
                        </div>
                            <div className="form-group password">
                                <label htmlFor="Password">Password</label>
                                <input ref={passwordInputRef} id="Password" type="password" className="form-control" />
                            </div>
                            {/* <button type="submit" className="btn btn-primary"
                                onClick={handleRegistration}>Register</button> */}
                            <button type="submit" className="login-btn"
                                onClick={handleLogin}>Login</button>
                        </form>
                    </div>
                </div>
            </div>
        <div className="profile-footer">
        </div>
    </div>
    
    :
    
    loggedpage
    
    );

   
    return(
        
        IsLoggedIn
    )
    
    
        
}

export default InnerProfil