import RegistrationFetch from "../components/controllers/RegistrationFetch"
import { useState } from 'react'


const SignInBox = () => {
    const [emailState, setEmailState] = useState("");
    const [passwordState, setPasswordState] = useState("");

    const handleInputChange = (e) => {
        const { id, value } = e.target;
        if (id === "Email") {
            setEmailState(value);
        }
        if (id === "Password") {
            setPasswordState(value);
        }
    }

  const SendUser = (e) => {
      e.preventDefault();

      var userData = {};
      userData["Email"] = emailState;
      userData["Password"] = passwordState;
     
      var json = JSON.stringify(userData);
      console.log(userData);
      RegistrationFetch(json);
    }

    return (
        <div>
            <h3>Sign In</h3>
            <div className="col-md-12">
                <form method="POST" action="/api/registration" onSubmit={SendUser}>
                    <div className="form-group">
                        <label htmlFor="Email">Email</label>
                        <input value={emailState} onChange={(e)=>handleInputChange(e)} id="Email" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label htmlFor="Password">Password</label>
                        <input value={passwordState} onChange={(e) => handleInputChange(e)} id="Password" className="form-control" />
                    </div>
                    {/*<div className="form-group">*/}
                    {/*    <div className="checkbox">*/}
                    {/*        <label htmlFor="RememberMe">Remember Me</label>*/}
                    {/*        <input id="RememberMe" type="checkbox" />*/}
                    {/*    </div>*/}
                    {/*</div>*/}
                    <button type="submit" className="btn btn-primary">Login</button>
                </form>
            </div>
        </div>
    )
}

export default SignInBox