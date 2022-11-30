import RegistrationFetch from "../components/controllers/RegistrationFetch"
import GetHashedPasswordFetch from "../components/controllers/GetHashedPasswordFetch"
import LoginApiFetch from "../components/controllers/LoginApiFetch"
import bcrypt from 'bcryptjs'
import { useRef } from 'react'
import React from 'react'


const SignInBox = () => {
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

        window.localStorage.setItem('login', JSON.stringify({ email, hashedPassword })); // load into session
    }

    const handleLogin = (e) => {
        e.preventDefault();

        var data = {};
        data["Email"] = emailInputRef;
        data["Username"] = emailInputRef;
       
        var salt = GetHashedPasswordFetch(data);
        const hashedPassword = bcrypt.hashSync(passwordInputRef, salt)
        data["Password"] = hashedPassword;

        LoginApiFetch(data);
    }

    return (
        <div>
            <h3>Registration/Sign In</h3>
            <div className="col-md-12">
                <form>
                    <div className="form-group">
                        <label htmlFor="Email">Email</label>
                        <input ref={emailInputRef} id="Email" type="email" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Password">Password</label>
                        <input ref={passwordInputRef} id="Password" type="password" className="form-control" />
                    </div>
                    {/*<div className="form-group">*/}
                    {/*    <div className="checkbox">*/}
                    {/*        <label htmlFor="RememberMe">Remember Me</label>*/}
                    {/*        <input id="RememberMe" type="checkbox" />*/}
                    {/*    </div>*/}
                    {/*</div>*/}
                    <button type="submit" className="btn btn-primary"
                        onClick={handleRegistration}>Register</button>
                    <button type="submit" className="btn btn-primary"
                        onClick={handleLogin}>Login</button>
                </form>
            </div>
        </div>
    )
}

export default SignInBox