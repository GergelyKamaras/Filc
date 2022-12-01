import RegistrationFetch from "../controllers/RegistrationFetch"
import GetHashedPasswordFetch from "../controllers/GetHashedPasswordFetch"
import LoginApiFetch from "../controllers/LoginApiFetch"
import bcrypt from 'bcryptjs'
import { useRef } from 'react'
import '../../Style/IndexPage/SignIn.css'

const SignInBox = (setLogin) => {
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
        };

        LoginApiFetch(data);
        setLogin();
    }

    return (
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
    )
}

export default SignInBox