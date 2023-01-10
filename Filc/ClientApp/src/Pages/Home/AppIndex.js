
import '../../Style/IndexPage/IndexPage.css'
import News from './News'
import React, {useEffect} from "react";

const IndexPage = (props) => {
    
    const updateLoginField = (newValue, field) => {
        props.updateLoginForm({ ...props.loginForm, [field]: newValue })
    }
    
    useEffect(() => {
        if(localStorage.getItem("AccessToken") !== null){
            props.updateLoginStatus(false)
        }else{}

    }); 

    
    return (
        <div className="index-parent">
        {props.loginStatus? (
                <div className="login-form">
                    <form>
                        <div className="form-group email">
                            <label htmlFor="email">Email</label>
                            <input defaultValue={props.loginForm?.email ? props.loginForm.email : ""}
                             onChange={(e) => updateLoginField(e.target.value, "email")} id="email" type="email" className="form-control" />
                        </div>
                        <div className="form-group password">
                            <label htmlFor="password">Password</label>
                            <input defaultValue={props.loginForm?.password ? props.loginForm.password : ""}
                             onChange={(e) => updateLoginField(e.target.value, "password")} id="Password" type="password" className="form-control"/>
                        </div>
                        
                    </form>
                </div>

        ):(
                <div className="gov-news">
                    <News/>
                </div>
            
        )}
            
        </div>
    );
};

export default IndexPage;