import React from "react";
import {useNavigate} from 'react-router-dom';
import '../../Style/IndexPage/InnerProfil.css'



const InnerProfil = ({logged}) => {
    const navigate = useNavigate();

    const navigateLogin = () => {
        navigate('/login')
    }

    if(logged === true){

    }
    else{
        return(
            <div className="profile">
                <div className="profile-top">
                    <div className="profile-pic">unavailable</div>
                    <p className="not-logged-text">You have to login first</p>

                </div>
                <div className="profile-details">

                </div>
                <div className="profile-footer">
                    <button className="login-btn" onClick={navigateLogin}> Login </button>
                </div>
               
            </div>
        )
    }
}

export default InnerProfil